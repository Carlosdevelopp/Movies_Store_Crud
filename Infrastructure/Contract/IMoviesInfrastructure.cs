using DataAccess.Models.Tables;
using Infrastructure.DTO;

namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        #region GET
        MoviesDTO _GetMovie(int movieId);
        MoviesDTO GetMovie(int movieId);
        List<MoviesDTO> GetMovies();
        AwardsDTO GetMovieDetails(int movieId);
        List<AwardsDTO> GetMoviesDetails();
        #endregion

        #region POST
        void InsertMovie(MoviesInsertDTO movies);
        #endregion

        #region PUT
        void UpdateMovie(MoviesUpdateDTO movieDTO);
        #endregion

        #region DELETE
        void DeleteMovie(int movieId);
        #endregion
    }
}
