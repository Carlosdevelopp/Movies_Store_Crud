namespace Infrastructure.DTO
{
    public class MoviesUpdateDTO
    {
        public string TitleMovie { get; set; }  
        public string DescriptionMovie { get; set; }
        public int RunningTimeMovie { get; set; }   
        public DateTime ReleaseMovie { get; set; }   
    }
}
