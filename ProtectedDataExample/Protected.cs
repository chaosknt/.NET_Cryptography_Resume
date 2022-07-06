using System;
using System.Security.Cryptography;
using System.Text;

namespace Pluralsight.ProtectedDataExample
{
    public class Protected
    {
        public static string Protect(string stringToEncrypt, string optionalEntropy, DataProtectionScope scope)
        {
            byte[] encryptedData = ProtectedData.Protect(
                    Encoding.UTF8.GetBytes(stringToEncrypt)
                    , optionalEntropy != null ? Encoding.UTF8.GetBytes(optionalEntropy) : null
                    , scope);

            return Convert.ToBase64String(encryptedData);
        }

        public static string Unprotect(string encryptedString, string optionalEntropy, DataProtectionScope scope)
        {
            byte[] decrypted = ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedString)
                    , optionalEntropy != null ? Encoding.UTF8.GetBytes(optionalEntropy) : null
                    , scope);

            return Encoding.UTF8.GetString(decrypted);
        }

        public static byte[] Protect(byte[] stringToEncrypt, byte[] optionalEntropy, DataProtectionScope scope)
        {
            byte[] encryptedData = ProtectedData.Protect(stringToEncrypt
                    , optionalEntropy != null ? optionalEntropy : null
                    , scope);

            return encryptedData;
        }

        public static byte[] Unprotect(byte[] encryptedString, byte[] optionalEntropy, DataProtectionScope scope)
        {
            byte[] decrypted = ProtectedData.Unprotect(encryptedString,
                    optionalEntropy != null ? optionalEntropy : null,
                    scope);

            return decrypted;
        }
    }
}