using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using MusicStore.Repository;
using MusicStore.Models;
using System.Web;
using MusicStore.Entity;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        UserRepository userRepository;
        AlbumRepository albumRepository;
        ArtistRepository artistRepository;
        GenreRepository genreRepository;
        TrackRepository trackRepository;

        public StoreController()
        {
            userRepository = new UserRepository();
            albumRepository = new AlbumRepository();
            artistRepository = new ArtistRepository();
            genreRepository = new GenreRepository();
            trackRepository = new TrackRepository();
        }

        public ActionResult Menu()
        {
            User user = userRepository.GetUser(Request.Cookies["UserData"]["Username"], Request.Cookies["UserData"]["Password"]);
            UserModel userModel = new UserModel();
            userModel.FirstName = user.customer.FirstName;
            return View(userModel);
        }

        public ActionResult Artist()
        {
            List<Artist> artists = artistRepository.GetArtist();
            List<ArtistModel> artistsModel = new List<ArtistModel>();

            for (int i = 0; i < artists.Count(); i++)
            {
                ArtistModel artistModel = new ArtistModel();

                artistModel.ArtistId = artists[i].ArtistId;
                artistModel.Name = artists[i].Name;
                artistsModel.Add(artistModel);
            }
            return View(artistsModel);
        }

        public ActionResult ArtistAlbum(int Id)
        {
            Artist artist = artistRepository.GetAlbumArtist(Id);
            ArtistModel artistModel = new ArtistModel();
            artistModel.ArtistId = artist.ArtistId;
            artistModel.Name = artist.Name;
            for (int i = 0; i < artist.albums.Count(); i++)
            {
                AlbumModel albumModel = new AlbumModel();
                albumModel.AlbumId = artist.albums[i].AlbumId;
                albumModel.Title = artist.albums[i].Title;
                artistModel.albumsModel.Add(albumModel);
            }
            return View(artistModel);
        }

        public ActionResult AlbumTracks(int idAlbum)
        {
            Album album = albumRepository.GetAlbumTracks(idAlbum);
            AlbumModel albumModel = new AlbumModel();
            albumModel.ArtistId = album.ArtistId;
            albumModel.AlbumId = album.AlbumId;
            albumModel.Title = album.Title;
            for (int i = 0; i < album.tracks.Count(); i++)
            {

                TrackModel trackModel = new TrackModel();
                trackModel.Name = album.tracks[i].Name;
                trackModel.TrackId = album.tracks[i].TrackId;
                albumModel.tracksModel.Add(trackModel);
            }
            return View(albumModel);
        }

        public ActionResult Albums()
        {
            List<Album> albums = albumRepository.GetAlbums();
            List<AlbumModel> albumsModel = new List<AlbumModel>();
            for (int i = 0; i < albums.Count(); i++)
            {

                AlbumModel albumModel = new AlbumModel();
                albumModel.AlbumId = albums[i].AlbumId;
                albumModel.Title = albums[i].Title;
                albumsModel.Add(albumModel);
            }
            return View(albumsModel);
        }

        public ActionResult Genres()
        {
            List<Genre> genres = genreRepository.GetGenres();
            List<GenreModel> genresModels = new List<GenreModel>();
            for (int i = 0; i < genres.Count(); i++)
            {
                GenreModel genreModel = new GenreModel();
                genreModel.GenreId = genres[i].GenreId;
                genreModel.Name = genres[i].Name;
                genresModels.Add(genreModel);
            }
            return View(genresModels);
        }

        public ActionResult MusicGenre(int idGenre)
        {
            Genre genre = genreRepository.GetGenreMusic(idGenre);
            GenreModel genreModel = new GenreModel();
            genreModel.Name = genre.Name;
            for (int i = 0; i < genre.tracks.Count(); i++)
            {

                TrackModel trackModel = new TrackModel();
                trackModel.Name = genre.tracks[i].Name;
                trackModel.TrackId = genre.tracks[i].TrackId;
                genreModel.tracksModel.Add(trackModel);
            }
            return View(genreModel);
        }

        public ActionResult Track(int idTrack)
        {
            Track track = trackRepository.getTrack(idTrack);
            TrackModel trackModel = new TrackModel();
            trackModel.TrackId = track.TrackId;
            trackModel.Name = track.Name;
            trackModel.AlbumName = track.Album.Title;
            trackModel.GenreName = track.Genre.Name;
            trackModel.Composer = track.Composer;
            trackModel.MilliSeconds = track.MilliSeconds;
            trackModel.Bytes = track.Bytes;
            trackModel.UnitPrice = track.UnitPrice;
            return View(trackModel);
        }

        public ActionResult Logout()
        {
            Response.Cookies["UserData"].Expires = DateTime.Now.AddHours(-1);
            return RedirectToAction("Index", "Home");
        }
    }
}