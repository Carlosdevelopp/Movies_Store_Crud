using Infrastructure.Contract;
using Infrastructure.DTO;
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
        /// <summary>
        /// Gets movie by id
        /// </summary>
        /// <param name="movieId">Integer with id movie</param>
        /// <response code="200">Succesfull operation and return movie object</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns></returns>
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

        [HttpGet("GetMovieDetails")]
        public IActionResult GetMovieDetails(int movieId)
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMovieDetails(movieId));
            }
            catch (Exception)
            {
                return BadRequest("Server internal error");
            }
        }

        [HttpGet("GetMoviesDetails")]
        public IActionResult GetMoviesDetails()
        {
            try
            {
                return Ok(_moviesInfrastructure.GetMoviesDetails());
            }
            catch (Exception)
            {
                return BadRequest("Server internal error");
            }
        }
        #endregion

        #region POST
        [HttpPost("InsertMovie")]
        public IActionResult InserMovie(MoviesInsertDTO movieDTO)
        {
            try
            {
                _moviesInfrastructure.InsertMovie(movieDTO);
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
        public IActionResult UpdateMovie(MoviesUpdateDTO movieDTO)
        {
            try
            {
                _moviesInfrastructure.UpdateMovie(movieDTO);   
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
