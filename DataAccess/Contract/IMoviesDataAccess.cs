﻿using DataAccess.Models.Tables;

namespace DataAccess.Contract
{
    public interface IMoviesDataAccess
    {
        #region GET
        Movies GetMovie(int movieId);
        List<Movies> GetMovies();
        Movies GetMovieDetails(int movieId);
        List<Movies> GetMoviesDetails();
        #endregion

        #region POST
        void InsertMovie(Movies movie);
        #endregion

        #region PUT
        void UpdateMovie(Movies movie);
        #endregion

        #region DELETE
        void DeleteMovie(int movieId);
        #endregion
    }
}
