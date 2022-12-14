namespace Infrastructure.DTO
{
    public class MoviesInsertDTO
    {
        public string TitleMovie { get; set; }  
        public string DescriptionMovie { get; set; }
        public int RunnigTimeMovie { get; set; }    
        public DateTime ReleaseMovie { get; set; }  
    }
}
