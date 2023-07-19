using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class Category
    {
        public Category()
        {
            Movies = new HashSet<MovieCategory>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public ICollection<MovieCategory> Movies{ get; set; }
    }
}
