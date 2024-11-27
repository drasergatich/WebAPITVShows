using System.ComponentModel.DataAnnotations;

namespace WebAPITVShows.Models.Entities
{
    public class TVShow
    {
        [Key]
        public int Id { get;  set; }
        public string? Name { get;  set; }
        public bool Favorite { get;  set; }
    }
}
