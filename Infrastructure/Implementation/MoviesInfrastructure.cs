using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
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
        public Movies GetMovie(int movieId)
        {


            Movies movie = _moviesDA.GetMovie(movieId);

            return movie;
        }
        public List<Movies> GetMovies()
        {
            List<Movies> Movies = _moviesDA.GetMovies();

            List<Movies> movies = (from u in Movies
                                   select new Movies
                                   {
                                       MovieId = u.MovieId,
                                       Description = u.Description,
                                       Title = u.Title,
                                       Release = u.Release,
                                       RunningTime = u.RunningTime,
                                   }).ToList();

            return movies;
        }
        public AwardsDTO GetMovieDetails(int movieId)
        {
            Movies movie = _moviesDA.GetMovieDetails(movieId);

            AwardsDTO _awardsDTO = new AwardsDTO
            {
                TitleMovie = movie.Title,
                DescriptionMovie = movie.Description
            };

            return _awardsDTO;
        }
        public List<Movies> GetMoviesDetails()
        {
            List<Movies> movies = _moviesDA.GetMoviesDetails();

            List<Movies> _movies = (from u in movies
                                    select new Movies
                                    {
                                        MovieId = u.MovieId,
                                        Description = u.Description,
                                        Title = u.Title,
                                        Release = u.Release,
                                        RunningTime = u.RunningTime,
                                    }).ToList();

            return _movies;
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
