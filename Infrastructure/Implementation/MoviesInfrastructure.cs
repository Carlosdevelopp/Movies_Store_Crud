using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class MoviesInfrastructure :IMoviesInfrastructure
    {
        private readonly IMoviesDataAccess _moviesDA;

        public MoviesInfrastructure(IMoviesDataAccess moviesDataAccess) 
        {
            _moviesDA = moviesDataAccess;
        }

        #region GET
        public List<Movies> GetMovies()
        {
            List<Movies> Movies = _moviesDA.GetMovies();

            List<Movies> movies = (from u in Movies
                                   select new Movies
                                   {
                                       Description = u.Description,
                                       Title = u.Title,
                                       Release = u.Release,
                                       RunningTime = u.RunningTime,
                                   }).ToList();

            return movies;
        }
        #endregion

        #region POST
        public void InsertMovie(Movies movie)
        {
            Movies movies = new();
            movie.Title = movie.Title;
            movie.Description = movie.Description;
            movie.Release = movie.Release;
            movie.RunningTime = movie.RunningTime;
            movie.GenreId = movie.GenreId;
            movie.AwardId = movie.AwardId;

            _moviesDA.InsertMovie(movie);
        }
        #endregion

        #region PUT
        public void UpdateMovie(Movies movie)
        {
            Movies movies = new();
            movie.MovieId= movie.MovieId;   
            movie.Title = movie.Title;
            movie.Description = movie.Description;  
            movie.Release = movie.Release;  
            movie.RunningTime = movie.RunningTime;
            movie.GenreId = movie.GenreId;   
            movie.AwardId = movie.AwardId;

            _moviesDA.UpdateMovie(movie);
        }
        #endregion

        #region DELETE
        public void DeleteMovie(int movieId)
        {
            _moviesDA.DeleteMovie(movieId);
        }
        #endregion
    }
}
