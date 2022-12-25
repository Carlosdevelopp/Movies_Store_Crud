using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Tables
{
    public class Awards
    {
        [Key]
        public int AwardId { get; set; }
        public string AwardTitle { get; set; } 

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
