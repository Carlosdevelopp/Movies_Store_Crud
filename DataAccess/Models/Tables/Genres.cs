using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Tables
{
    public class Genres
    {
        [key]
        public int GenreId { get; set; }    
        public string Genre { get; set; }    
    }
}
