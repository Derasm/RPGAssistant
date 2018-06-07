using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebRPG.MVC.Controllers
{
    public class HashingHelper
    {

        public static string generateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(salt), 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];

            Array.Copy(Encoding.ASCII.GetBytes(salt), 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPassword = Convert.ToBase64String(hashBytes);

            return savedPassword;
        }

        public static bool CheckPasword(string password, string storedSalt, string saltedHashedPassword)
        {
            string hashedValue = HashPassword(password, storedSalt);

            return hashedValue == saltedHashedPassword;
        }



    }
}