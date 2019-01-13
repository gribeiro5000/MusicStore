using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Models;
using Simple.Data;
using MusicStore.Entity;

namespace MusicStore.Repository
{
    public class ArtistRepository : BaseRepository
    {
        public List<Artist> GetArtist()
        {
            var chinookDb = Database.OpenConnection(_connectionString);
            List<Artist> artists = chinookDb.artists.All();
            return artists;
        }

        public Artist GetAlbumArtist(int idArtist)
        {
            var chinookDb = Database.OpenConnection(_connectionString);
            Artist artist = chinookDb.artists.Find(chinookDb.artists.ArtistId == idArtist);
            if (artist != null)
            {
                artist.albums = chinookDb.albums.FindAll(chinookDb.albums.ArtistId == artist.ArtistId);
            }
            return artist;
        }
    }
}