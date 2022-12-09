using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;

namespace _MoviesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesInfrastructure _moviesInfrastructure;

        public MoviesController(IMoviesInfrastructure moviesInfrastructure)
        {
            _moviesInfrastructure = moviesInfrastructure;
        }

        #region GET
        [HttpGet("GetMovie")]
        public IActionResult GetMovie(int movieId)
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovie(movieId));
            }
            catch (Exception)
            {
                return BadRequest("Server internal error");
            }
        }

        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovies());
            }
            catch (Exception)
            {
                return BadRequest("Server internal error");
            }
        }
        #endregion

        #region POST
        [HttpPost("InsertMovie")]
        public IActionResult InserMovie(Movies movie)
        {
            try
            {
                _moviesInfrastructure.InsertMovie(movie);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Record no inserted");
            }
        }
        #endregion

        #region PUT
        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(Movies movie)
        {
            try
            {
                _moviesInfrastructure.UpdateMovie(movie);   
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Registry not updated");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId)
        {
            try
            {
                _moviesInfrastructure.DeleteMovie(movieId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Registred not delete");
            }
        }
        #endregion
    }
}
