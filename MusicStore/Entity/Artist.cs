using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Entity
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public List<Album> albums { get; set; }
    }
}