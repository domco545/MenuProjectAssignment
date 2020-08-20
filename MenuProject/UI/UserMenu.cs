using MenuProject.Data;
using MenuProject.Service;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MenuProject.UI
{
    class UserMenu
    {
        IUserService UserService = new UserService();

        public void Menu() 
        {
            var read = "";

            while (read != "0")
            {
                Console.WriteLine("choose one of the options");
                Console.WriteLine("1 list all users");
                Console.WriteLine("2 add user");
                Console.WriteLine("3 remove user");
                Console.WriteLine("4 find user by name");
                Console.WriteLine("0 exit");
                Console.WriteLine("-------------------------------------------------");

                read = Console.ReadLine();

                switch (read)
                {
                    default: Console.WriteLine("option not found try again \n"); ;
                        break;
                    case "1": ListAllUsers();
                        break;
                    case "2": AddUser();
                        break;
                    case "3": RemoveUser();
                        break;
                    case "4": FindUserByName();
                        break;
                    case "0": return;
                }

            }

        }

        private void ListAllUsers() 
        {
            var allUsers = UserService.GetAllUsers();

            foreach (var user in allUsers)
            {
                Console.WriteLine(user.ToString());
            }

            Console.WriteLine();
        }

        private void AddUser() 
        {
            var ready = false;
            Console.WriteLine("please write name of the user");
            Console.WriteLine("name must be at least 4 characters and maximum of 20 characters long");
            while (!ready)
            {
                var read = Console.ReadLine();
                if (read == null)
                {
                    Console.WriteLine("name cannot be null");
                    Console.WriteLine("try again\n");
                }
                else
                if (read.Length < 4 || read.Length > 20)
                {
                    Console.WriteLine("name is too long or too short");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    UserService.AddUser(read);
                    Console.WriteLine("user was added\n");
                    ready = true;
                }
            }
            
        }

        public void RemoveUser() 
        {
            Console.WriteLine("write id of user you want to delete");
            var ready = false;

            while (!ready)
            {
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("user Id must be a number");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    if (UserService.RemoveUSer(num))
                    {
                       Console.WriteLine($"user with Id:{num} was deleted\n");
                        ready = true;
                    }
                    else
                    {
                        Console.WriteLine($"User with Id:{num} wasnt found");
                        Console.WriteLine("try again\n");
                    } 
                }
            }
        }

        public void FindUserByName() 
        {
            var ready = false;
            Console.WriteLine("write letters that you want to search with");
            while (!ready)
            {
                var read = Console.ReadLine();
                if (read == null) 
                {
                    Console.WriteLine("search cannot be null");
                    Console.WriteLine("try again\n");
                }
                else
                if (read.Length < 1)
                {
                    Console.WriteLine("you need to type at least one letter");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    var found = UserService.FindUserByName(read);
                    if (found.Count > 1) 
                    {
                        Console.WriteLine($"no results matching {read} \n");
                        ready = true;
                    }
                    else
                    {
                        foreach (var user in found)
                        {
                            Console.WriteLine(user.ToString());
                        }
                        Console.WriteLine();
                        ready = true;
                    }
                }
            }
        }
    }
}
