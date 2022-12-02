using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class MoviesDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region GET
        //Obtener todos los registros
        public List<Movies> GetMovies()
        {
            List<Movies> Movies = (from u in _dbContext.Movies
                                   select u).ToList();

            return Movies;
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
