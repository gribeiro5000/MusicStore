using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Entity
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public List<Track> tracks { get; set; }
    }
}