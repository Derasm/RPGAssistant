using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerRPG.BusinessLogic;
using ServerRPG.Model;
namespace ServerRPG.Server
{

    public class UserService : IUser
    {

        CtrUser userController = new CtrUser();

        public void Create(User entity)
        {
            userController.Create(entity);
            
        }

        public bool Delete(User entity)
        {
            return userController.Delete(entity);
        }

        public User Find(string searcher)
        {
            User user = userController.Find(searcher);
            return user;
        }

        public User FindUserWithPassword(string searcher, string password)
        {
            User user = userController.FindUserWithPassword(searcher, password);
            return user;
        }

        public List<User> GetAll()
        {
            return userController.GetAll().ToList();
        }

        public int Update(User entity)
        {
            return userController.Update(entity);
        }
    }
}
