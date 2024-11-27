using Microsoft.AspNetCore.Mvc;
using WebAPITVShows.Models.Dtos;
using WebAPITVShows.Models.Entities;

namespace WebAPITVShows.Services
{
    public interface ITVShowsService
    {
        Task<ActionResult<TVShowDTO>> GetByIdAsync(int id);
        Task<ActionResult<List<TVShowDTO>>> GetAllAsync();
        Task<ActionResult> CreateAsync(CreateTVShowDTO createTVShowDTO);
        Task<ActionResult> UpdateAsync(int id, UpdateTVShowDTO updateTVShowDTO);

    }
}
