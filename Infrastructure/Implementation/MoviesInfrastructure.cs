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

        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion
    }
}
