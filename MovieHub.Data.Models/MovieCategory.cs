using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class MovieCategory
    {
        [Required]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        [Required]
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
