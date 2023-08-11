using MovieHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        
        public DateTime ReleaseDate { get; set; }


        public int MovieLength { get; set; }

     
        public string ImgURL { get; set; } = null!;

        public decimal Budget { get; set; }


        public ICollection<MovieActor> MovieActors { get; set; } = new HashSet<MovieActor>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<MovieDirector> MovieDirectors { get; set; } = new HashSet<MovieDirector>();

        public ICollection<Reward> Rewards { get; set; } = new HashSet<Reward>();

        public ICollection<MovieCategory> Categories { get; set; } = new HashSet<MovieCategory>();

        public ICollection<MovieLike> MovieLikes { get; set; } = new HashSet<MovieLike>();
    }
}
