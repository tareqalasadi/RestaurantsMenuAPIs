using System.Security.Cryptography;
using System.Text;

namespace RestaurantsMenu.General
{
    public class EncryptionEngine
    {
        private byte[] byKey = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };

        private byte[] IV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };

        public string Decrypt(string strText)
        {
            byte[] array = new byte[strText.Length];
            try
            {
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                array = Convert.FromBase64String(strText);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string Encrypt(string strText)
        {
            try
            {
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(strText);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cryptoStream.Write(bytes, 0, bytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
