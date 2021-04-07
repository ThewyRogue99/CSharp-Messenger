using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Manager;

namespace Crypto
{
    class Cipher
    {
        public static byte[] EncryptData(byte[] bytes, string key)
        {
            int[] fileint = Array.ConvertAll(bytes, c => (int)c);
            if (fileint.Length <= key.Length)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    fileint[i] ^= key[i];
                    fileint[i] += key[i];
                }
                return Array.ConvertAll(fileint, c => (byte)c);
            }
            else
            {
                for (int i = 0, x = 0; i < fileint.Length; i++, x++)
                {
                    if (x == key.Length)
                        x = 0;
                    fileint[i] += key[x];
                    fileint[i] ^= key[x];
                }
                return Array.ConvertAll(fileint, c => (byte)c);
            }
        }

        public static byte[] DecryptData(byte[] bytes, string key)
        {
            int[] fileint = Array.ConvertAll(bytes, c => (int)c);
            if (fileint.Length <= key.Length)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    fileint[i] ^= key[i];
                    fileint[i] -= key[i];
                }
                return Array.ConvertAll(fileint, c => (byte)c);
            }
            else
            {
                for (int i = 0, x = 0; i < fileint.Length; i++, x++)
                {
                    if (x == key.Length)
                        x = 0;
                    fileint[i] ^= key[x];
                    fileint[i] -= key[x];
                }
                return Array.ConvertAll(fileint, c => (byte)c);
            }
        }
    }
}