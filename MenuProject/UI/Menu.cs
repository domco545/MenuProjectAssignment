using System;
using System.Collections.Generic;
using System.Text;

namespace MenuProject.UI
{
    class Menu
    {
        public void Start() 
        {
            var videoMenu = new UI.VideoMenu();
            var userMenu = new UI.UserMenu();
            var read = "";

            while (read != "0")
            {
                Console.WriteLine("choose one of the options");
                Console.WriteLine("1 video menu");
                Console.WriteLine("2 user menu");
                Console.WriteLine("0 exit");
                Console.WriteLine("-------------------------------------------------");
                read = Console.ReadLine();

                switch (read)
                {
                    default: Console.WriteLine("option not found try again \n");
                        break;
                    case "0": return;
                    case "1": videoMenu.Menu();
                        break;
                    case "2": userMenu.Menu();
                        break;
                }
            }
            
        }
    }
}
