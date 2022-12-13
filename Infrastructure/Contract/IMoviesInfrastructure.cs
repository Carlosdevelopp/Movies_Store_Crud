using DataAccess.Models.Tables;
using Infrastructure.DTO;

namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        #region GET
        MoviesDTO GetMovie(int movieId);
        List<MoviesDTO> GetMovies();
        AwardsDTO GetMovieDetails(int movieId);
        List<Movies> GetMoviesDetails();
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
