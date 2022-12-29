namespace Infrastructure.DTO
{
    public class MoviesInsertDTO
    {
        public string TitleMovie { get; set; }  = string.Empty;
        public string DescriptionMovie { get; set; } = string.Empty;    
        public int RunnigTimeMovie { get; set; }    
        public DateTime ReleaseMovie { get; set; }  
        public int GenreId { get; set; }
        public int AwardId { get; set; }
    }
}
