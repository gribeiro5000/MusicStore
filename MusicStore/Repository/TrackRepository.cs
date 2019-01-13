using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Entity;
using Simple.Data;

namespace MusicStore.Repository
{
    public class TrackRepository : BaseRepository
    {
        public Track getTrack(int id)
        {
            Track track = new Track();
            var chinookDb = Database.OpenConnection(_connectionString);
            track = chinookDb.tracks.FindByTrackId(id);
            track.Album = chinookDb.albums.Find(chinookDb.albums.AlbumId == track.AlbumId);
            track.Genre = chinookDb.genres.Find(chinookDb.genres.GenreId == track.GenreId);
            return track;
        }
    }
}