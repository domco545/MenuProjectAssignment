using MenuProject.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuProject.UI
{
    class VideoMenu
    {
        IVideoService VideoService = new VideoService();

        public void Menu()
        {
            var read = "";

            while (read != "0")
            {
                Console.WriteLine("choose one of the options");
                Console.WriteLine("1 list all videos");
                Console.WriteLine("2 add video");
                Console.WriteLine("3 remove video");
                Console.WriteLine("4 find video by name");
                Console.WriteLine("0 exit");
                Console.WriteLine("-------------------------------------------------");

                read = Console.ReadLine();

                switch (read)
                {
                    default:
                        Console.WriteLine("option not found try again \n"); ;
                        break;
                    case "1":
                        ListAllVideos();
                        break;
                    case "2":
                        AddVideo();
                        break;
                    case "3":
                        RemoveVideo();
                        break;
                    case "4":
                        FindVideoByName();
                        break;
                    case "0": return;
                }
            }
        }

        public void ListAllVideos() 
        {
            var AllVideos = VideoService.GetAllVideos();

            foreach (var video in AllVideos)
            {
                Console.WriteLine(video.ToString());
            }

            Console.WriteLine();
        }

        public void AddVideo() 
        {
            var NameReady = false;
            var DescriptionReady = false;
            var Name = "";
            var Description = "";
            Console.WriteLine("please write name of video");
            Console.WriteLine("name must be at least 2 characters and maximum of 30 characters long");

            while (!NameReady)
            {
                Name = Console.ReadLine();
                if (Name.Length < 2 || Name.Length > 30)
                {
                    Console.WriteLine("name is too long or too short");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    NameReady = true;
                    Console.WriteLine("video was added \n");
                }
            }

            Console.WriteLine("please write description of video");
            Console.WriteLine("description must be at least 4 characters and maximum of 30 characters long");

            while (!DescriptionReady)
            {
                Description = Console.ReadLine();
                if (Description.Length < 4 || Description.Length > 30)
                {
                    Console.WriteLine("description is too long or too short");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    DescriptionReady = true;
                }
            }

            VideoService.AddVideo(Name, Description);
        }

        public void RemoveVideo() 
        {
            Console.WriteLine("write id of video you want to delete");
            var ready = false;

            while (!ready)
            {
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("video Id must be a number");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    if (VideoService.RemoveVideo(num))
                    {
                        Console.WriteLine($"video with Id:{num} was deleted\n");
                        ready = true;
                    }
                    else
                    {
                        Console.WriteLine($"video with Id:{num} wasnt found");
                        Console.WriteLine("try again\n");
                    }
                }
            }

        }

        public void FindVideoByName() 
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
                    var found = VideoService.FindVideoByName(read);
                    if (found.Count < 1)
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
