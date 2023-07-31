using MovieHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.ViewModels
{
    public class DirectorDetailsViewModel
    {
        public Guid Id { get; set; }

        
        public string FirstName { get; set; } = null!;

        
        public string LastName { get; set; } = null!;
        
        
        public DateTime BornDate { get; set; }

        public DateTime DeathDate { get; set; }

        
        public string Description { get; set; } = null!;

       
        public string ImgURL { get; set; } = null!;

       
        public string BornCityName { get; set; } = null!;

        public ICollection<Reward> Rewards { get; set; } = new HashSet<Reward>();

        public ICollection<MovieDirector> Movies { get; set; } = new HashSet<MovieDirector>();
    }
}
