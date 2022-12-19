using DataAccess.Contract;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Infrastructure.Utils;
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
        public MoviesDTO GetMovie(int movieId)
        {
            Movies movie = _moviesDA.GetMovie(movieId);

            MoviesDTO moviesDTO = new MoviesDTO
            {
                TitleMovie = movie.Title,
                DescriptionMovie = movie.Description,
                RunningTimeMovie = movie.RunningTime,
                ReleaseMovie = movie.Release
            };

            return moviesDTO;
        }
        public List<MoviesDTO> GetMovies()
        {
            List<Movies> movies = _moviesDA.GetMovies();

            //Syntax
            //List<MoviesDTO> moviesDTO = (from u in movies
            //                       select new MoviesDTO
            //                       {
            //                           TitleMovie = u.Title,
            //                           DescriptionMovie = u.Description,
            //                           ReleaseMovie = u.Release,
            //                           RunningTimeMovie = u.RunningTime,
            //                       }).ToList();

            //Method
            List<MoviesDTO> moviesDTO_method = movies.Select(u => new MoviesDTO
            {
                TitleMovie = u.Title,
                DescriptionMovie = u.Description,   
                ReleaseMovie = u.Release,
                RunningTimeMovie = u.RunningTime,
            }).ToList();

            return moviesDTO_method;
        }
        public AwardsDTO GetMovieDetails(int movieId)
        {
            Movies movie = _moviesDA.GetMovieDetails(movieId);

            AwardsDTO _awardsDTO = new AwardsDTO
            {
                TitleMovie = movie.Title.FormatTitle(),
                DescriptionMovie = movie.Description.TextUpperCase(),
                ReleaseShortMovie = movie.Release.ToShortDate(),
                RunningTimeMovie = movie.RunningTime.FormatTime(),
                Genre = movie.Genres.Genre.ToLower(),
                Award = movie.Awards.AwardTitle.AwardText()
            };

            return _awardsDTO;
        }
        public List<AwardsDTO> GetMoviesDetails()
        {
            List<Movies> movies = _moviesDA.GetMoviesDetails();

            List<AwardsDTO> _movies = (from u in movies
                                    select new AwardsDTO
                                    {
                                        TitleMovie = u.Title.FormatTitle(),
                                        DescriptionMovie = u.Description.TextUpperCase(),
                                        ReleaseShortMovie = u.Release.ToShortDate(),
                                        RunningTimeMovie = u.RunningTime.FormatTime(),
                                        Genre = u.Genres.Genre.ToLower(),
                                        Award = u.Awards.AwardTitle.AwardText()
                                    }).ToList();

            return _movies;
        }
        #endregion

        #region POST
        public void InsertMovie(MoviesInsertDTO movieDTO)
        {
            Movies movie = new();
            movie.Title = movieDTO.TitleMovie;
            movie.Description = movieDTO.DescriptionMovie;
            movie.Release = movieDTO.ReleaseMovie;
            movie.RunningTime = movieDTO.RunnigTimeMovie;

            _moviesDA.InsertMovie(movie);
        }
        #endregion

        #region PUT
        public void UpdateMovie(MoviesUpdateDTO movieDTO)
        {
            Movies movie = new();   
            movie.Title = movieDTO.TitleMovie;
            movie.Description = movieDTO.DescriptionMovie;  
            movie.Release = movieDTO.ReleaseMovie;  
            movie.RunningTime = movieDTO.RunningTimeMovie;

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
