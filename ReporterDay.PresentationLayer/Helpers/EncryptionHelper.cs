using System;
using System.Text;
using System.Security.Cryptography;

namespace ReporterDay.PresentationLayer.Helpers
{
    public class EncryptionHelper
    {

        private static readonly string _key = "SeniBilenBirAnahtar123"; // 16, 24, 32 karakter olmalı (AES için)

        public static string Encrypt(string plainText)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_key.Substring(0, 16));
            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = keyBytes;

            var encryptor = aes.CreateEncryptor();
            byte[] inputBuffer = Encoding.UTF8.GetBytes(plainText);
            byte[] result = encryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

            return Convert.ToBase64String(result)
                         .Replace('+', '-')
                         .Replace('/', '_')
                         .Replace("=", "");
        }

        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace('-', '+').Replace('_', '/');
            switch (cipherText.Length % 4)
            {
                case 2: cipherText += "=="; break;
                case 3: cipherText += "="; break;
            }

            byte[] keyBytes = Encoding.UTF8.GetBytes(_key.Substring(0, 16));
            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = keyBytes;

            var decryptor = aes.CreateDecryptor();
            byte[] inputBuffer = Convert.FromBase64String(cipherText);
            byte[] result = decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

            return Encoding.UTF8.GetString(result);
        }
    }
}
