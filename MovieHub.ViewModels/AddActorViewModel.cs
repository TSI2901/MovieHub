using MovieHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.ViewModels
{
    public class AddActorViewModel
    {
        public Guid? Id { get; set; }
        [Required]
        [StringLength(GeneralApplicationConstants.ActorConstants.ActorNameMaxLength, MinimumLength = GeneralApplicationConstants.ActorConstants.ActorNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(GeneralApplicationConstants.ActorConstants.ActorNameMaxLength, MinimumLength = GeneralApplicationConstants.ActorConstants.ActorNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public string ImgURL { get; set; } = null!;

      

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime BornDate { get; set; }

        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime? DeathDate { get; set; }

        [Required]
        [StringLength(GeneralApplicationConstants.ActorConstants.DescriptionMaxLength, MinimumLength = GeneralApplicationConstants.ActorConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(GeneralApplicationConstants.ActorConstants.CityNameMaxLength, MinimumLength = GeneralApplicationConstants.ActorConstants.CityNameMinLength)]
        public string BornCityName { get; set; } = null!;

        public ICollection<RewardViewModel> Rewards { get; set; } = new List<RewardViewModel>();
        public RewardViewModel? FirstReward { get; set; }
        public RewardViewModel? ThirdReward { get; set; }
        public RewardViewModel? SecondReward { get; set; }
    }
}
