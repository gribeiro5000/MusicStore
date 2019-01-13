using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Data;
using MusicStore.Models;
using MusicStore.Entity;

namespace MusicStore.Repository
{
    public class GenreRepository : BaseRepository
    {
        public List<Genre> GetGenres()
        {
            var chinookDb = Database.OpenConnection(_connectionString);
            List<Genre> genres = chinookDb.genres.All();
            return genres;
        }

        public Genre GetGenreMusic(int idGenre)
        {
            var chinookDb = Database.OpenConnection(_connectionString);
            Genre genre = chinookDb.genres.Find(chinookDb.genres.GenreId == idGenre);
            if(genre != null)
            {
                genre.tracks = chinookDb.tracks.FindAll(chinookDb.tracks.GenreId == idGenre);
            }
            return genre;
        }
    }
}