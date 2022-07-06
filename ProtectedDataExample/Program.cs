using System;
using System.Security.Cryptography;
using System.Text;

namespace Pluralsight.ProtectedDataExample
{
    class Program
    {
        static AesGCMEncryption aesGCM = new AesGCMEncryption();

        static void Main(string[] args)
        {
            ProtectedDataTest();

            EncryptAndDecryptWithProtectedKey();
        }

        private static void EncryptAndDecryptWithProtectedKey()
        {
            string original = "Text to encrypt";
            Console.WriteLine("Original Text = ", original);

            // Create a key and nonce. Encrypt our text with AES/
            var gcmKey = aesGCM.GenerateRandomNumber(32);
            var nonce = aesGCM.GenerateRandomNumber(12);
            var result = EncryptText(original, gcmKey, nonce);

            // Create some entropy and protect the AES key.
            var entropy = aesGCM.GenerateRandomNumber(16);
            byte[] protectedKey = Protected.Protect(gcmKey, entropy, DataProtectionScope.CurrentUser);

            // Decrypt the text with AES. First the AES key has to be retrieved with DPAPI.
            string decryptedText = DecryptText(result.encrypted, nonce, result.tag, protectedKey, entropy);
            Console.WriteLine("Decrypted Text = ", decryptedText);
        }

        private static (byte[] encrypted, byte[] tag) EncryptText(string original, byte[] gcmKey, byte[] nonce)
        {
            return aesGCM.Encrypt(Encoding.UTF8.GetBytes(original), gcmKey, nonce, Encoding.UTF8.GetBytes("some metadata"));
        }

        private static string DecryptText(byte[] encrypted, byte[] nonce, byte[] tag, byte[] protectedKey, byte[] entropy)
        {
            byte[] key = Protected.Unprotect(protectedKey, entropy, DataProtectionScope.CurrentUser);

            byte[] decryptedText = aesGCM.Decrypt(encrypted, key, nonce, tag, Encoding.UTF8.GetBytes("some metadata"));

            return Encoding.UTF8.GetString(decryptedText);
        }

        private static void ProtectedDataTest()
        {
            var encrypted = Protected.Protect("Mary had a little lamb", "8wef5juy2389f4", DataProtectionScope.CurrentUser);
            Console.WriteLine(encrypted);

            var decrypted = Protected.Unprotect(encrypted, "8wef5juy2389f4", DataProtectionScope.CurrentUser);
            Console.WriteLine(decrypted);
        }
    }
}