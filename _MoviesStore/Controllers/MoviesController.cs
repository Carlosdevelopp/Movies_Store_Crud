using Infrastructure.Contract;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _MoviesStore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
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
        ///       "releaseMovie": datetime,
        ///       "genreMovie": 0
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
        ///       "releaseMovie": datetime,
        ///       "genreMovie": 0
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
        ///       "runningTimeMovie": string,
        ///       "releaseMovie": "string",
        ///       "genreMovie": string
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
        ///       "runningTimeMovie": datetime
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
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
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseShortMovie": 0,
        ///       "runningTimeMovie": datetime
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
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

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <response code="200">Succesfull operation and return movie object</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /one
        ///     {
        ///       "titleMovie": "string",
        ///       "descriptionMovie": "string",
        ///       "releaseShortMovie": 0,
        ///       "runningTimeMovie": datetime
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
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
