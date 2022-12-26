using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class AwardsDTO
    {
        public string TitleMovie { get; set; }  = string.Empty;
        public string DescriptionMovie { get; set; } = string.Empty;    
        public string ReleaseShortMovie { get; set; } = string.Empty;   
        public string RunningTimeMovie { get; set; } = string.Empty;    
        public string Genre { get; set; } = string.Empty;           
        public string Award { get; set; } = string.Empty;
    }
}
