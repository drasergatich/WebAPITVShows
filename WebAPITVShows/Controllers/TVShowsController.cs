using Microsoft.AspNetCore.Mvc;
using WebAPITVShows.Models.Dtos;
using WebAPITVShows.Models.Entities;
using WebAPITVShows.Repositories;
using WebAPITVShows.Services;

namespace WebAPITVShows.Controllers
{
    /// <summary>
    /// Controlador que maneja las operaciones CRUD para los TV Shows.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TVShowsController : ControllerBase
    {
        private readonly ITVShowsService _tvShowService;

        public TVShowsController(ITVShowsService tvShowService)
        {
            _tvShowService = tvShowService;
        }
        /// <summary>
        /// Obtiene los detalles de un programa de televisión por su ID.
        /// </summary>
        /// <param name="id">ID del programa de televisión.</param>
        /// <returns>Un objeto <see cref="TVShowDTO"/> con los detalles del programa de televisión solicitado.</returns>
        /// <response code="200">Si el TV Show fue encontrado.</response>
        /// <response code="404">Si el TV Show no fue encontrado.</response>
        /// <response code="500">Si ocurrió un error interno en el servidor.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TVShowDTO>> GetTVShow(int id)
        {
            return await _tvShowService.GetByIdAsync(id);
        }
    }
}
