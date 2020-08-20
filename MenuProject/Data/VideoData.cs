using MenuProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuProject.Data
{
    class VideoData
    {
        int IdCount = 2;
        List<Video> AllVideos = new List<Video>() 
        {
            new Video{Id = 0, Name = "My video", Description = "best description" },
            new Video{Id = 1, Name = "My other video", Description = "also nice description" }
        };

        public List<Video> GetAllVideos() 
        {
            return AllVideos;
        }

        public void AddVideo(string name, string description) 
        {
            AllVideos.Add(new Video { Id = IdCount, Name = name, Description = description });
            IdCount++;
        }

        public bool RemoveVideo(int id) 
        {
            if (AllVideos.Any(Video => Video.Id == id))
            {
                AllVideos = AllVideos.Where(Video => Video.Id != id).ToList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Video> FindVideoByName(string querry) 
        {
            return AllVideos.Where(Video => Video.Name.ToLower().Contains(querry.ToLower())).ToList();
        }
    }
}
