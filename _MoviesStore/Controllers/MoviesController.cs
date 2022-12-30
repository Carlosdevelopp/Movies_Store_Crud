using AutoMapper;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _MoviesStore.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
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
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /one
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "runningTimeMovie": 0,
        ///       "releaseMovie": datetime
        ///     }
        ///
        /// </remarks>
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

        /// <summary>
        /// Get movie list
        /// </summary>
        /// <response code="200">Succesfull operation and return movie object</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     GET /all
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "runningTimeMovie": 0,
        ///       "releaseMovie": datetime
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
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

        /// <summary>
        /// Gets movieDetails by id
        /// </summary>
        /// <param name="movieId">Integer with id movie</param>
        /// <response code="200">Succesfull operation and return movie object</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /one
        ///     {  
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseMovie": "string",
        ///       "runningTimeMovie": string,
        ///       "genre": "string",
        ///       "Award": "string"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
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

        /// <summary>
        /// Gets moviesDetails list
        /// </summary>
        /// <response code="200">Succesfull operation and return movie object</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /all
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseShortMovie": "string",
        ///       "runningTimeMovie": "string",
        ///       "genre": "string",
        ///       "award": "string"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
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
        /// <summary>
        /// Insert a record
        /// </summary>
        /// <response code="200">Succesfull operation and return movie object</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /one
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseShortMovie": 0,
        ///       "runningTimeMovie": "datetime",
        ///       "GenreId": 0,
        ///       "AwardId": 0
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
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
        /// <summary>
        /// Update a record
        /// </summary>
        /// <response code="200">Succesfull operation and return movie object</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /one
        ///     {
        ///       "movieId": 0,
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "runningTimeMovie": 0,
        ///       "releaseMovie": datetime,
        ///       "GenreId": 0,
        ///       "AwardId": 0
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
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
        /// <summary>
        /// Delete a record
        /// </summary>
        /// <response code="200">Succesfull operation and return movie object</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns></returns>
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
