using MenuProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuProject.Data
{
    class UserData
    {
        int IdCount = 2;
        List<User> AllUsers = new List<User>()
        {
            new User{Id = 0, Name = "Martin Nielsen" },
            new User{Id = 1, Name = "Peter Hansen"}
        };

        public List<User> GetAllUsers() 
        {
            return AllUsers;
        }

        public void AddUser(string name) 
        {
            AllUsers.Add(new User { Id = IdCount, Name = name });
            IdCount++;
        }

        public bool RemoveUSer(int id) 
        {
            if (AllUsers.Any(User => User.Id == id))
            {
                AllUsers = AllUsers.Where(User => User.Id != id).ToList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> FindUserByName(string querry) 
        {
            return AllUsers.Where(User => User.Name.ToLower().Contains(querry.ToLower())).ToList();
        }
    }
}
