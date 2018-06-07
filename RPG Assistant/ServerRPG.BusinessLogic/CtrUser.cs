using ServerRPG.DAL.DBClasses;
using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.BusinessLogic
{
    public class CtrUser : IGenericCrud<User>
    {
        DbUser db = new DbUser();
        public void Create(User entity)
        {
            entity.Salt = HashingHelper.generateSalt();
            entity.HashedPassword = HashingHelper.HashPassword(entity.HashedPassword, entity.Salt);
            db.Create(entity);
        }

        public bool Delete(User entity)
        {
            return db.Delete(entity);
        }
        
        public User Find(string input)
        {
            User user = db.Find(input);
            return user;

        }

        public User FindUserWithPassword(string input, string password)
        {
            User user = db.Find(input);
            if (HashingHelper.CheckPasword(password, user.Salt, user.HashedPassword))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.GetAll();
        }

        public int Update(User entity)
        {
            return db.Update(entity);
        }
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
}

