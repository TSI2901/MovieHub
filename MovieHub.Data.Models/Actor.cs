using MovieHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class Actor
    {
        public Actor()
        {
            rewards = new List<Reward>();
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
        [MaxLength(GeneralApplicationConstants.ActorConstants.CityNameMaxLength)]
        public string BornCityName { get; set; } = null!;

        public ICollection<Reward> rewards { get; set; }
    }
}
