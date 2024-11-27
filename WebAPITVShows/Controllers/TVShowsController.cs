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
    [Route("api/[controller]")]
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
        [HttpGet("{id}")]
        public async Task<ActionResult<TVShowDTO>> GetTVShow(int id)
        {
            return await _tvShowService.GetByIdAsync(id);
        }

        /// <summary>
        /// Obtiene la lista completa de TV Shows.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="TVShowDTO"/>.</returns>
        /// <response code="200">Devuelve la lista de TV Shows.</response>
        /// <response code="400">Si ocurre un error al procesar la solicitud.</response>
        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<TVShowDTO>>> GetAll()
        {
            return await _tvShowService.GetAllAsync();
        }
        /// <summary>
        /// Crea un nuevo TV Show en la base de datos.
        /// </summary>
        /// <param name="createTVShowDTO">El objeto que contiene los datos necesarios para crear un nuevo TV Show.</param>
        /// <returns>Un mensaje que indica si el registro fue añadido exitosamente o si ocurrió algún error durante el proceso.</returns>
        /// <response code="200">Devuelve un mensaje de resultado.</response>
        /// <response code="400">Devuelve un mensaje de error.</response>
        [HttpPost]
        [Route("insertar")]
        public async Task<ActionResult<List<TVShowDTO>>> Create(CreateTVShowDTO createTVShowDTO)
        {
            return await _tvShowService.CreateAsync(createTVShowDTO);
        }

    }
}
