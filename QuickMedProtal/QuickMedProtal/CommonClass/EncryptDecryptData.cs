using System.Security.Cryptography;
using System.Text;

namespace QuickMedProtal.CommonClass
{
    public class EncryptDecryptData
    {
            public string Encrypt(string plainText)
            {
                string passwordKey = "b!TS@Remit";
                string salt = "b!TS@Remit";

                return Encrypt(plainText, passwordKey, salt);
            }
            public string Decrypt(string cipherText)
            {
                string passwordKey = "b!TS@Remit";
                string salt = "b!TS@Remit";

                return Decrypt(cipherText, passwordKey, salt);
            }
            private static string Encrypt(string PlainText, string Password, string Salt = "Kosher", string HashAlgorithm = "SHA1", int PasswordIterations = 2, string InitialVector = "OFRna73m*aze01xY", int KeySize = 256)
            {
                if (string.IsNullOrEmpty(PlainText))
                    return "";
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
                byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
                PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
                byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
                RijndaelManaged SymmetricKey = new RijndaelManaged();
                SymmetricKey.Mode = CipherMode.CBC;
                byte[] CipherTextBytes = null;
                using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
                {
                    using (MemoryStream MemStream = new MemoryStream())
                    {
                        using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                        {
                            CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                            CryptoStream.FlushFinalBlock();
                            CipherTextBytes = MemStream.ToArray();
                            MemStream.Close();
                            CryptoStream.Close();
                        }
                    }
                }
                SymmetricKey.Clear();
                return Convert.ToBase64String(CipherTextBytes);
            }

            private static string Decrypt(string cipherText, string password, string salt = "Kosher", string hashAlgorithm = "SHA1", int passwordIterations = 2, string initialVector = "OFRna73m*aze01xY", int keySize = 256)
            {
                if (string.IsNullOrEmpty(cipherText))
                    return "";

                byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIterations);
                byte[] keyBytes = derivedPassword.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int byteCount = 0;

                using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initialVectorBytes))
                {
                    using (MemoryStream memStream = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                        {
                            byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        }
                    }
                }

                symmetricKey.Clear();

                return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
            }


            public string Encode(string plainText)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);

            }
            public string Decode(string base64EncodedData)
            {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            }
        }
}
