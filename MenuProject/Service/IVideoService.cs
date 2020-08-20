using MenuProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuProject.Service
{
    interface IVideoService
    {
        public List<Video> GetAllVideos();
        public void AddVideo(string name, string description);
        public bool RemoveVideo(int id);
        public List<Video> FindVideoByName(string querry);
    }
}
