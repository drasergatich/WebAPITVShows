﻿using System.ComponentModel.DataAnnotations;

namespace WebAPITVShows.Models.Dtos
{
    public class CreateTVShowDTO
    {
        [Required]
        public string? Name { get; set; }
        public bool Favorite { get; set; }
    }
}
