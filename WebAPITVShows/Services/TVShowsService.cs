﻿using Microsoft.AspNetCore.Http.HttpResults;
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
    }
}