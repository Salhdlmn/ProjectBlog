using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.EntityLayer.Entities;
using ReporterDay.PresentationLayer.Helpers;
using System.Net.Http.Headers;
using System.Text;

namespace ReporterDay.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
       
            private readonly ICommentService _commentService;
            private readonly UserManager<AppUser> _userManager;

            public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
            {
                _commentService = commentService;
                _userManager = userManager;
            }
     


    
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> AddComment(Comment comment, string EncryptedArticleId)
        {
            if (string.IsNullOrEmpty(EncryptedArticleId))
            {
                return Json(new { success = false, message = "EncryptedArticleId boş geldi." });
            }

            try
            {
                int decryptedId = int.Parse(EncryptionHelper.Decrypt(EncryptedArticleId));
                comment.ArticleId = decryptedId;
            }
            catch
            {
                return Json(new { success = false, message = "ID çözümlenemedi." });
            }

            var translatedText = await TranslateToEnglish(comment.CommentDetail);

            // 🔁 Zararlı içerik kontrolü
            if (await IsToxicComment(translatedText))
            {
                return Json(new { success = false, message = "Yorumunuzda uygunsuz ifadeler tespit edildi. Lütfen daha nazik bir dil kullanın." });
            }

            comment.CommentDate = DateTime.Now;
            comment.IsValid = true;
            comment.AppUserId = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name)?.Id;

            _commentService.CommentAdd(comment);
            return Json(new { success = true });
        }

        private async Task<string> TranslateToEnglish(string turkishText)
        {

            using var client = new HttpClient();

            string url = $"https://api.mymemory.translated.net/get?q={Uri.EscapeDataString(turkishText)}&langpair=tr|en";
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(result);
            return json.responseData.translatedText;
        }
        private async Task<bool> IsToxicComment(string comment)
        {
            var client =new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
            var content = new StringContent(JsonConvert.SerializeObject(new { inputs = comment }), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api-inference.huggingface.co/models/unitary/toxic-bert", content);
            var result = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(result);
            foreach (var label in json[0])
            {
                string name = label.label.ToString().ToLower();
                float score = float.Parse(label.score.ToString());

                if ((name.Contains("toxic") || name.Contains("insult") || name.Contains("obscene")) && score > 0.6)
                {
                    return true;
                }
            }

            return false;
        }


    }
}
