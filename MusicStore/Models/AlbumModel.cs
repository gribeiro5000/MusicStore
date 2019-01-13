using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class AlbumModel
    {
        public AlbumModel()
        {
            tracksModel = new List<TrackModel>();
        }

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public List<TrackModel> tracksModel { get; set; }
    }
}