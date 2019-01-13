using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class ArtistModel
    {
        public ArtistModel()
        {
            albumsModel = new List<AlbumModel>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public List<AlbumModel> albumsModel {get;set;}
    }
}