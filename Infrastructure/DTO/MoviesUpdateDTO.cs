namespace Infrastructure.DTO
{
    public class MoviesUpdateDTO
    {
        public string TitleMovie { get; set; }  = string.Empty;
        public string DescriptionMovie { get; set; } = string.Empty;    
        public int RunningTimeMovie { get; set; }   
        public DateTime ReleaseMovie { get; set; }   
    }
}
