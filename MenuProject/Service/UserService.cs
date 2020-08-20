using MenuProject.Data;
using MenuProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuProject.Service
{
    class UserService : IUserService
    {
        UserData userDb = new UserData();

        public void AddUser(string name)
        {
            userDb.AddUser(name);
        }

        public List<User> FindUserByName(string querry)
        {
            return userDb.FindUserByName(querry);
        }

        public List<User> GetAllUsers()
        {
            return userDb.GetAllUsers();
        }

        public bool RemoveUSer(int id)
        {
            return userDb.RemoveUSer(id);
        }
    }
}
