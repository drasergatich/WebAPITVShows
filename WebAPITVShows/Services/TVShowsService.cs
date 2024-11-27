using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPITVShows.Models.Dtos;
using WebAPITVShows.Models.Entities;
using WebAPITVShows.Repositories;

namespace WebAPITVShows.Services
{
    /// <summary>
    /// Servicio para gestionar las operaciones relacionadas con los TV Shows.
    /// </summary>
    public class TVShowsService : ITVShowsService
    {
        private readonly IGenericRepository<TVShow> _genericRepository;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de TV Shows.
        /// </summary>
        /// <param name="genericRepository">Repositorio genérico utilizado para las operaciones CRUD sobre las entidades de tipo TVShow.</param>
        public TVShowsService(IGenericRepository<TVShow> genericRepository) 
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Obtiene un TV Show por su ID.
        /// Si no se encuentra, devuelve un NotFound con un mensaje.
        /// </summary>
        /// <param name="id">El ID del TV Show.</param>
        /// <returns>Un objeto de tipo <see cref="TVShowDTO"/> con la información del TV Show solicitado,
        /// o un objeto de error si no se encuentra.</returns>
        /// <response code="200">Devuelve el TV Show si se encuentra.</response>
        /// <response code="404">Si no se encuentra el TV Show, devuelve un mensaje con el error.</response>
        public async Task<ActionResult<TVShowDTO>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _genericRepository.GetByIdAsync(id);

                // Si no se encuentra la entidad, se devuelve un NotFound con el mensaje correspondiente
                if (entity == null)
                {
                    return new NotFoundObjectResult(new { message = "TV Show no encontrado." });
                }

                // Si se encuentra, se mapea a un DTO y se devuelve
                return new TVShowDTO
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Favorite = entity.Favorite
                };
            }
            catch (Exception ex) 
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }
        /// <summary>
        /// Obtiene una lista de todos los registros de TV Show existentes en la base de datos.
        /// Si no se encuentra, devuelve un NotFound con un mensaje.
        /// </summary>
        /// <returns>Una lista de tipo <see cref="TVShowDTO"/> con todos los registros existentes de TV Show,
        /// o un objeto de error si no se encuentra.</returns>
        /// <response code="200">Devuelve el TV Show si se encuentra.</response>
        /// <response code="404">Si no se encuentra ningún registro de TV Show, devuelve un mensaje con el error.</response>
        public async Task<ActionResult<List<TVShowDTO>>> GetAllAsync()
        {
            try
            {
                var entity = await _genericRepository.GetAllAsync();

                // Si no se encuentra ningún registro, se devuelve un NotFound con el mensaje correspondiente
                if (entity == null)
                {
                    return new NotFoundObjectResult(new { message = "Sin resultados." });
                }
                // Si se encuentra por lo menos un registro, se mapea a una lista DTO y se devuelve
                var listaTVShow = entity.Select(entity => new TVShowDTO
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Favorite = entity.Favorite
                }).ToList();

                return listaTVShow;
            }
            catch (Exception ex) 
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        /// <summary>
        /// Crea un nuevo registro de TV Show en la base de datos.
        /// </summary>
        /// <param name="createTVShowDTO">Objeto que contiene la información necesaria para crear un nuevo TV Show.</param>
        /// <response code="200">Devuelve un mensaje indicando que el registro se agregó exitosamente.</response>
        /// <response code="400">Si ocurrió un error durante el proceso, devuelve un mensaje con el detalle del error.</response>

        public async Task<ActionResult> CreateAsync(CreateTVShowDTO createTVShowDTO)
        {
            try
            {
                TVShow tVShow = new TVShow()
                {
                    Name = createTVShowDTO.Name,
                    Favorite = createTVShowDTO.Favorite
                };
                var resultado = await _genericRepository.AddAsync(tVShow);

                // Si no se agregó el registro, se devuelve un Bad Request con el mensaje correspondiente
                if (resultado == 0)
                {
                    return new BadRequestObjectResult(new { message = "No se pudieron realizar cambios en la base de datos." });
                }
                return new OkObjectResult(new { message = "Se agregó el registro exitosamente"});
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza un registro de TV Show en la base de datos.
        /// </summary>
        /// <param name="updateTVShowDTO">Objeto que contiene la información necesaria para actualizar un TV Show.</param>
        /// <param name="id">ID del TV Show a actualizar.</param>
        /// <response code="200">Devuelve un mensaje indicando que el registro se actualizó exitosamente.</response>
        /// <response code="400">Si ocurrió un error durante el proceso, devuelve un mensaje con el detalle del error.</response>

        public async Task<ActionResult> UpdateAsync(int id, UpdateTVShowDTO updateTVShowDTO)
        {
            try
            {
                TVShow tVShow = new TVShow()
                {
                    Id = id,
                    Name = updateTVShowDTO.Name,
                    Favorite = updateTVShowDTO.Favorite
                };
                var resultado = await _genericRepository.UpdateAsync(tVShow);

                // Si no se actualizó el registro, se devuelve un Bad Request con el mensaje correspondiente
                if (resultado == 0)
                {
                    return new BadRequestObjectResult(new { message = "No se pudieron realizar cambios en la base de datos." });
                }
                return new OkObjectResult(new { message = "Se agregaron los cambios exitosamente" });
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
