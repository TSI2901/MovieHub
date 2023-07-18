using MovieHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            MovieActors = new HashSet<MovieActor>();
            Rewards = new List<Reward>();
            MovieDirectors = new HashSet<MovieDirector>();
            Categories = new HashSet<MovieCategory>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(GeneralApplicationConstants.MovieConstants.MovieTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GeneralApplicationConstants.MovieConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [ForeignKey("Director")]
        public Guid DirectorId { get; set; }

        [Required]
        public int MovieLength { get; set; }

        [Required]
        public string ImgURL { get; set; } = null!;

        public decimal Budget { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }

        public ICollection<MovieDirector> MovieDirectors { get; set; }

        public ICollection<Reward> Rewards { get; set; }

        public ICollection<MovieCategory> Categories { get; set; }
    }
}
