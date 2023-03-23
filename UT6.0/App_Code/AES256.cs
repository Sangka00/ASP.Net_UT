using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;


using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// AES256의 요약 설명입니다.
/// </summary>
public class AES256
{
    static string PWD = "nfactor!planemo!nfactor!planemo!";
    static string PWD2 = "nfactor!planemo!nfactor!planemo!";
    public AES256()
    {
        //
        // TODO: 여기에 생성자 논리를 추가합니다.
        //
    }

    /// <summary>
    /// AES 256 암호화
    /// </summary>
    /// <param name="InputText">암호화할 문자열</param>
    /// <returns>암호화된 문자열</returns>
    public static string AES256Encrypt(string Input)
    {
        RijndaelManaged aes = new RijndaelManaged();
        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = Encoding.UTF8.GetBytes(PWD);
        aes.IV = Encoding.UTF8.GetBytes(PWD.Substring(0, 16));

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
    /// <returns>복호화된 문자열</returns>
    /// 

    public static string AES256Encrypt_2(string Input)
    {
        RijndaelManaged aes = new RijndaelManaged();
        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = Encoding.UTF8.GetBytes(PWD2);
        aes.IV = Encoding.UTF8.GetBytes(PWD2.Substring(0, 16));

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
    /// <returns>복호화된 문자열</returns>
    /// 
    public static string AES256Decrypt(string Input)
    {
        try
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(PWD);
            aes.IV = Encoding.UTF8.GetBytes(PWD.Substring(0, 16));

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
        catch
        {
            return string.Empty;
        }
    }



    public static string AES256Decrypt_2(string Input)
    {
        try
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(PWD2);
            aes.IV = Encoding.UTF8.GetBytes(PWD2.Substring(0, 16));

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
        catch
        {
            return string.Empty;
        }
    }
}