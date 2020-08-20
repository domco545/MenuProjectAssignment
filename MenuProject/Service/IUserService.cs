using MenuProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuProject.Service
{
    interface IUserService
    {
        public List<User> GetAllUsers();
        public void AddUser(string name);
        public bool RemoveUSer(int id);
        public List<User> FindUserByName(string querry);
    }
}
