using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class GenreModel
    {
        public GenreModel()
        {
            tracksModel = new List<TrackModel>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<TrackModel> tracksModel { get; set; }
    }
}