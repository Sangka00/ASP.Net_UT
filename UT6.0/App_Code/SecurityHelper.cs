using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Threading.Tasks;

/// <summary>
/// SecurityHelper의 요약 설명입니다.
/// </summary>
namespace aSIMS
{
    public class SecurityHelper
    {
        public SecurityHelper()
        {
            //
            // TODO: 여기에 생성자 논리를 추가합니다.
            //
        }
        /// <summary>
        /// AES 256 암호화
        /// </summary>
        /// <param name="InputText">암호화할 문자열</param>
        /// <param name="Password">비밀번호</param>
        /// <returns>암호화된 문자열</returns>
        public static string AES256Encrypt(string Input, string Key)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(Key.Substring(0, 16));

            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }

                xBuff = ms.ToArray();
            }

            String Output = Convert.ToBase64String(xBuff);

            return Output;
        }

        /// <summary>
        /// AES 256 복호화
        /// </summary>
        /// <param name="InputText">복호화할 문자열</param>
        /// <param name="Password">비밀번호</param>
        /// <returns>복호화된 문자열</returns>
        public static string AES256Decrypt(string Input, string Key)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(Key.Substring(0, 16));

            var decrypt = aes.CreateDecryptor();
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Convert.FromBase64String(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }

                xBuff = ms.ToArray();
            }

            String Output = Encoding.UTF8.GetString(xBuff);

            return Output;
        }

        /// <summary>
        /// AES 128 암호화
        /// </summary>
        /// <param name="InputText">암호화할 문자열</param>
        /// <param name="Password">비밀번호</param>
        /// <returns>암호화된 문자열</returns>
        public static string AES128Encrypt(string InputText, string Password)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();

            rijndaelCipher.Mode = CipherMode.CBC;

            rijndaelCipher.Padding = PaddingMode.PKCS7;

            rijndaelCipher.KeySize = 128;

            rijndaelCipher.BlockSize = 128;

            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(Password);

            byte[] keyBytes = new byte[16];

            int len = pwdBytes.Length;

            if (len > keyBytes.Length) len = keyBytes.Length;

            System.Array.Copy(pwdBytes, keyBytes, len);

            rijndaelCipher.Key = keyBytes;

            rijndaelCipher.IV = keyBytes;

            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();

            byte[] plainText = Encoding.UTF8.GetBytes(InputText);

            byte[] cipherBytes = transform.TransformFinalBlock(plainText, 0, plainText.Length);

            return Convert.ToBase64String(cipherBytes, Base64FormattingOptions.None);

        }

        /// <summary>
        /// AES 128 복호화
        /// </summary>
        /// <param name="InputText">복호화할 문자열</param>
        /// <param name="Password">비밀번호</param>
        /// <returns>복호화된 문자열</returns>
        public static string AES128Decrypt(string InputText, string Password)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();

            rijndaelCipher.Mode = CipherMode.CBC;

            rijndaelCipher.Padding = PaddingMode.PKCS7;

            rijndaelCipher.KeySize = 128;

            rijndaelCipher.BlockSize = 128;

            byte[] encryptedData = Convert.FromBase64String(InputText);

            byte[] pwdBytes = System.Text.Encoding.UTF8.GetBytes(Password);

            byte[] keyBytes = new byte[16];

            int len = pwdBytes.Length;

            if (len > keyBytes.Length) len = keyBytes.Length;

            System.Array.Copy(pwdBytes, keyBytes, len);

            rijndaelCipher.Key = keyBytes;

            rijndaelCipher.IV = keyBytes;

            ICryptoTransform transform = rijndaelCipher.CreateDecryptor();

            byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);

            return Encoding.UTF8.GetString(plainText);

        }

        /// <summary>
        /// AES 128 암호화
        /// </summary>
        /// <param name="InputText"></param>
        /// <param name="key"></param>
        /// <param name="Mode"></param>
        /// <param name="Padding"></param>
        /// <returns></returns>
        public static string AES128Encrypt(string InputText, string key, CipherMode Mode, PaddingMode Padding)
        {
            StringBuilder sbResult = new StringBuilder();

            byte[] KeyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] EncryptArray = UTF8Encoding.UTF8.GetBytes(InputText);

            RijndaelManaged Rdel = new RijndaelManaged();
            Rdel.Mode = Mode;
            Rdel.Padding = Padding;
            Rdel.Key = KeyArray;

            ICryptoTransform CtransForm = Rdel.CreateEncryptor();
            byte[] ResultArray = CtransForm.TransformFinalBlock(EncryptArray, 0, EncryptArray.Length);

            foreach (byte b in ResultArray)
            {
                sbResult.AppendFormat("{0:x2}", b);
            }

            return sbResult.ToString();
        }

        /// <summary>
        /// AES 128 복호화
        /// </summary>
        /// <param name="InputText"></param>
        /// <param name="key"></param>
        /// <param name="Mode"></param>
        /// <param name="Padding"></param>
        /// <returns></returns>
        public static string AES128Decrypt(string InputText, string key, CipherMode Mode, PaddingMode Padding)
        {
            byte[] KeyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] EncryptArray = HexToByte(InputText);

            RijndaelManaged Rdel = new RijndaelManaged();
            Rdel.Mode = Mode;
            Rdel.Padding = Padding;
            Rdel.Key = KeyArray;

            ICryptoTransform CtransForm = Rdel.CreateDecryptor();
            byte[] ResultArray = CtransForm.TransformFinalBlock(EncryptArray, 0, EncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(ResultArray);
        }

        /// <summary>
        /// SHA 512 해쉬
        /// </summary>
        /// <param name="InputText">해쉬할 문자열</param>
        /// <returns>해쉬된 문자열</returns>
        public static string SHA512Hash(string InputText)
        {
            if (string.IsNullOrEmpty(InputText))
                return string.Empty;

            HashAlgorithm hashAlg = new SHA512CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(InputText);
            byte[] bytHash = hashAlg.ComputeHash(bytValue);

            return Encoding.UTF8.GetString(bytHash);
        }

        /// <summary>
        /// SHA 512 해쉬 후 Base64
        /// </summary>
        /// <param name="InputText">해쉬할 문자열</param>
        /// <returns>해쉬된 문자열(base64)</returns>
        public static string SHA512HashBase64(string InputText)
        {
            if (string.IsNullOrEmpty(InputText))
                return string.Empty;

            HashAlgorithm hashAlg = new SHA512CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(InputText);
            byte[] bytHash = hashAlg.ComputeHash(bytValue);

            return Convert.ToBase64String(bytHash);
        }

        /// <summary>
        /// MD5 hash string
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns></returns>
        public static string MD5Hash(string InputText)
        {
            if (string.IsNullOrEmpty(InputText))
                return string.Empty;

            byte[] pass = Encoding.UTF8.GetBytes(InputText);
            MD5 md5 = new MD5CryptoServiceProvider();

            string result = string.Empty;
            foreach (byte bt in md5.ComputeHash(pass))
            {
                result += string.Format("{0:X2}", bt);
            }
            System.Diagnostics.Debug.WriteLine("[MD5] " + result);

            return result;
        }

        private static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                try
                {
                    comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return comBuffer;
        }
        public static string UrlEncode(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str);
        }

        public static string UrlDecode(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);
        }
    }
}