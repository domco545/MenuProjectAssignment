using MenuProject.Data;
using MenuProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuProject.Service
{
    class VideoService : IVideoService
    {
        VideoData VideoDb = new VideoData();
        public void AddVideo(string name, string description)
        {
            VideoDb.AddVideo(name, description);
        }

        public List<Video> FindVideoByName(string querry)
        {
            return VideoDb.FindVideoByName(querry);
        }

        public List<Video> GetAllVideos()
        {
            return VideoDb.GetAllVideos();
        }

        public bool RemoveVideo(int id)
        {
            return VideoDb.RemoveVideo(id);
        }
    }
}
