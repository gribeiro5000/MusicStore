using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class TrackModel
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string AlbumName { get; set; }
        public string GenreName { get; set; }
        public string Composer { get; set; }
        public int MilliSeconds { get; set; }
        public int Bytes { get; set; }
        public double UnitPrice { get; set; }
    }
}