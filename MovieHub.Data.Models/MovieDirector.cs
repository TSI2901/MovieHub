using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class MovieDirector
    {
        [Required]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        [Required]
        [ForeignKey("Director")]
        public Guid DirectorId { get; set; }
        public Director Director { get; set; } = null!;
    }
}
