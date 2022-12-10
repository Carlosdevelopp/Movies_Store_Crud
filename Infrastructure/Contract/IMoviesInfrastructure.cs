﻿using DataAccess.Models.Tables;
namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        #region GET
        Movies GetMovie(int movieId);
        List<Movies> GetMovies();
        #endregion

        #region POST
        void InsertMovie(Movies movies);
        #endregion

        #region PUT
        void UpdateMovie(Movies movie);
        #endregion

        #region DELETE
        void DeleteMovie(int movieId);
        #endregion
    }
}
