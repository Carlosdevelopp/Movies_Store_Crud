﻿using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class MoviesDataAccess : IMoviesDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region GET
        //Obtener un registro
        public Movies GetMovie(int movieId)
        {
            Movies movies = (from m in _dbContext.Movies
                            where m.MovieId == movieId
                            select m).FirstOrDefault();

            return movies;
        }

        //Obtener todos los registros
        public List<Movies> GetMovies()
        {
            List<Movies> Movies = (from u in _dbContext.Movies
                                   select u).ToList();

            return Movies;
        }
        #endregion

        #region POST
        public void InsertMovie(Movies movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
        #endregion

        #region PUT
        public void UpdateMovie(Movies movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        #endregion

        #region DELETE
        public void DeleteMovie(int movieId)
        {
            Movies movies = (from m in _dbContext.Movies
                             where m.MovieId == movieId
                             select m).FirstOrDefault();

            _dbContext.Movies.Remove(movies);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
