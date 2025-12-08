using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

public class CAesCrypt
{
    private static readonly byte[] Key = Encoding.ASCII.GetBytes("Nj4ziIVFosrDbIf7FSCRSCWvKBjXzwkw"); // 32 bytes for AES-256
    private static readonly byte[] IV = Encoding.ASCII.GetBytes("ksQHIUqquisJCxun"); // 16 bytes for AES
    public static string EncryptString(string plainText)
    {
        byte[] encrypted;
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }
        return Convert.ToBase64String(encrypted);
    }
    public static string DecryptString(string cipherText)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        string plainText = null;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plainText = srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        return plainText;
    }
    public static string[] FileEncryptString(string[] plainText)
    {
        List<string> encrypted = new List<string>();
        foreach (string text in plainText)
        {
            encrypted.Add(EncryptString(text));
        }
        return encrypted.ToArray();
    }
    public static string[] FileDecryptString(string[] cipherText)
    {
        List<string> decrypted = new List<string>();
        foreach (string text in cipherText)
        {
            decrypted.Add(DecryptString(text));
        }
        return decrypted.ToArray();
    }
}
