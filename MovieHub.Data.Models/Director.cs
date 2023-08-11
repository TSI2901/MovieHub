using MovieHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class Director
    {
        public Director()
        {
            Rewards = new List<Reward>();
            Movies = new HashSet<MovieDirector>();
            Comments = new List<Comment>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(GeneralApplicationConstants.ActorConstants.ActorNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(GeneralApplicationConstants.ActorConstants.ActorNameMaxLength)]
        public string LastName { get; set; } = null!;
        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime BornDate { get; set; }

        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime DeathDate { get; set; }

        [Required]
        [MaxLength(GeneralApplicationConstants.ActorConstants.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImgURL { get; set; } = null!;

        [Required]
        [MaxLength(GeneralApplicationConstants.ActorConstants.CityNameMaxLength)]
        public string BornCityName { get; set; } = null!;

        public ICollection<Reward> Rewards { get; set; }

        public ICollection<MovieDirector> Movies { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
