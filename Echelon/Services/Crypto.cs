using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Echelon.Services;

internal class Crypto
{
    public static byte[] GetHash(string text)
    // takes a password and returns the hash
    // where [0..8] is salt, and [8..32] is hash

    {
        byte[] combinedHash = new byte[32];

        // creates the salt with random bytes
        byte[] salt = new byte[8];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(salt);
        }

        // get the hash
        var key = new Rfc2898DeriveBytes(text, salt, 1000);
        var hash = key.GetBytes(24);
        key.Reset();

        // combine the salt and hash
        Array.Copy(salt, 0, combinedHash, 0, 8);
        Array.Copy(hash, 0, combinedHash, 8, 24);

        return combinedHash;
    }

    public static bool ValidateHash(string input, byte[] combinedHash)
    // takes a password and a hash, and validates their equality

    {
        // return the salt - [0..8]
        byte[] salt = new byte[8];
        Array.Copy(combinedHash, 0, salt, 0, 8);

        // compute the hash on the argument using the salt
        var key = new Rfc2898DeriveBytes(input, salt, 1000);
        var hashInput = key.GetBytes(24);
        key.Reset();

        // compare both
        for (int i = 0; i < 24; i++)
        {
            if (combinedHash[i + 8] != hashInput[i])
            {
                return false;
            }
        }

        return true;
    }

    public static byte[][] NewPrivatePublic(string password)
    // generates a public-private key pair, encrypts the private key with a password
    // where private[0..8] is the salt, and [8..] is scrambled key,
    {
        var keyPair = new byte[2][];
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            rsa.PersistKeyInCsp = false;

            keyPair[0] = rsa.ExportRSAPublicKey();

            // creates a salt
            byte[] salt = new byte[8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(salt);
            }

            // uses the salt with the password to create a secure key
            Rfc2898DeriveBytes passwordKey = new Rfc2898DeriveBytes(password, salt, 10000);

            // encrypts the private key with the password key
            using (Aes aes = Aes.Create())
            {
                aes.Key = passwordKey.GetBytes(32);
                passwordKey.Reset();

                // creates an IV
                byte[] iv = new byte[16];
                using (var generator = RandomNumberGenerator.Create())
                {
                    generator.GetBytes(iv);
                }

                aes.IV = iv;

                // creates the encryptor
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(rsa.ExportRSAPrivateKey(), 0, rsa.ExportRSAPrivateKey().Length);
                        csEncrypt.FlushFinalBlock();

                        var encryptedPrivateKey = msEncrypt.ToArray();

                        // copy the salt, iv, and key into a new array and store that
                        var combinedKey = new Byte[encryptedPrivateKey.Length + 24];

                        Array.Copy(salt, 0, combinedKey, 0, salt.Length);
                        Array.Copy(iv, 0, combinedKey, 8, iv.Length);
                        Array.Copy(encryptedPrivateKey, 0, combinedKey, 24, encryptedPrivateKey.Length);

                        keyPair[1] = combinedKey;
                    }
                }

                aes.Clear();
            }
        }

        return keyPair;
    }

    public static byte[] GetPrivateKey(string password, byte[] combinedKey)
    // takes a password and a scrambled private key and returns the key
    {
        // take the combined private key, get the salt and iv and retrieve the original key
        byte[] salt = new byte[8];
        byte[] iv = new byte[16];
        byte[] scrambledPrivateKey = new byte[combinedKey.Length - 24];
        byte[] decryptedPrivateKey;

        Array.Copy(combinedKey, 0, salt, 0, 8);
        Array.Copy(combinedKey, 8, iv, 0, 16);
        Array.Copy(combinedKey, 24, scrambledPrivateKey, 0, scrambledPrivateKey.Length);

        var passwordKey = new Rfc2898DeriveBytes(password, salt, 10000);

        using (Aes aes = Aes.Create())
        {
            aes.Key = passwordKey.GetBytes(32);
            passwordKey.Reset();
            aes.IV = iv;

            using (MemoryStream decryptionMemoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(decryptionMemoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(scrambledPrivateKey, 0, scrambledPrivateKey.Length);
                    cryptoStream.FlushFinalBlock();

                    decryptedPrivateKey = decryptionMemoryStream.ToArray();
                }
            }

            aes.Clear();
        }

        return decryptedPrivateKey;
    }

    public static byte[] EncryptBytes(byte[] publicKey, byte[] bytes)
    {
        // takes a public key and a sequence of bytes and returns it encrypted

        byte[] encryptedBytes;

        using (RSA rsa = RSA.Create())
        {
            rsa.ImportRSAPublicKey(publicKey, out _);

            encryptedBytes = rsa.Encrypt(bytes, RSAEncryptionPadding.Pkcs1);
            rsa.Clear();
        }

        return encryptedBytes;
    }

    public static byte[] DecryptBytes(byte[] privateKey, byte[] bytes)
    {
        // takes a private key and a sequence of bytes and returns it decrypted

        byte[] decryptedBytes;

        using (RSA rsa = RSA.Create())
        {
            rsa.ImportRSAPrivateKey(privateKey, out _);

            decryptedBytes = rsa.Decrypt(bytes, RSAEncryptionPadding.Pkcs1);
            rsa.Clear();
        }

        return decryptedBytes;
    }

    public static byte[] NewSymmetricKey()
    {
        // creates a new symmetric key, for encrypting large amounts of data e.g. text

        using Aes aes = Aes.Create();
        aes.GenerateKey();

        byte[] iv = new byte[16];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(iv);
        }

        aes.IV = iv;

        return aes.IV.Concat(aes.Key).ToArray();
    }

    public static byte[] EncryptString(byte[] symmetricKey, string plaintext)
    {
        // encrypts a string with a symmetric key

        byte[] encrypted;

        using (Aes aes = Aes.Create())
        {
            aes.IV = symmetricKey[0..16];
            aes.Key = symmetricKey[16..];

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(plaintext);
                    }

                    encrypted = memoryStream.ToArray();
                }
            }

            aes.Clear();
        }

        return encrypted;
    }

    public static string DecryptString(byte[] symmetricKey, byte[] ciphertext)
    {
        // decrypts a string with a symmetric key

        string decrypted;

        using (Aes aes = Aes.Create())
        {
            aes.IV = symmetricKey[0..16];
            aes.Key = symmetricKey[16..];

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(ciphertext))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        decrypted = streamReader.ReadToEnd();
                    }
                }
            }

            aes.Clear();
        }

        return decrypted;
    }
}

