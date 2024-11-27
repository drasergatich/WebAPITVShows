namespace WebAPITVShows.Models.Dtos
{
    /// <summary>
    /// DTO que representa los datos de un show de TV.
    /// </summary>
    public class TVShowDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Favorite { get; set; }
    }
}
