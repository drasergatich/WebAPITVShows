using Microsoft.AspNetCore.Mvc;
using WebAPITVShows.Models.Dtos;
using WebAPITVShows.Models.Entities;

namespace WebAPITVShows.Services
{
    public interface ITVShowsService
    {
        Task<ActionResult<TVShowDTO>> GetByIdAsync(int id);
    }
}
