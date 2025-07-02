using System.ComponentModel.DataAnnotations;

namespace ReporterDay.PresentationLayer.Models
{
    public class ProfileViewModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }

        // Şifre değiştirme için ek alanlar
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }



        public string? StatusMessage { get; set; }
    }
}
