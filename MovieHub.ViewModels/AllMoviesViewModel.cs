using MovieHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.ViewModels
{
    public class AllMoviesViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImgURL { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
        public Category Category { get; set; } = null!;
        public int MovieLength { get; set; }
    }
}
