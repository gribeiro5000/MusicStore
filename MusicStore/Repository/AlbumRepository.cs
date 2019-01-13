using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Models;
using Simple.Data;
using MusicStore.Entity;

namespace MusicStore.Repository
{
    public class AlbumRepository : BaseRepository
    {
        public List<Album> GetAlbums()
        {
            var chinookDb = Database.OpenConnection(_connectionString);
            List<Album> albums = chinookDb.albums.All();
            return albums;
        }

        public Album GetAlbumTracks(int idAlbum)
        {
            var chinookDb = Database.OpenConnection(_connectionString);
            Album album = chinookDb.albums.Find(chinookDb.albums.AlbumId == idAlbum);
            if(album != null)
            {
                album.tracks = chinookDb.tracks.FindAll(chinookDb.tracks.AlbumId == idAlbum);
            }
            return album;
        }
    }
}