using MovieHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.ViewModels
{
    public class AddMovieViewModel
    {
        public Guid? Id { get; set; }
        [Required]
        [StringLength(GeneralApplicationConstants.MovieConstants.MovieTitleMaxLength, MinimumLength = GeneralApplicationConstants.MovieConstants.MovieTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(GeneralApplicationConstants.MovieConstants.DescriptionMaxLength, MinimumLength =GeneralApplicationConstants.MovieConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

       

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public ICollection<RewardViewModel> Rewards { get; set; } = new HashSet<RewardViewModel>();
        public RewardViewModel? FirstReward { get; set; }
        public RewardViewModel? ThirdReward { get; set; }
        public RewardViewModel? SecondReward { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
        [Required]
        public CategoryViewModel FirstCategorieId { get; set; } = null!;
        public CategoryViewModel? SecondCategorieId { get; set; } 
        public CategoryViewModel? ThirdCategorieId { get; set; } 

        [Required]
        public int MovieLength { get; set; }

        [Required]
        [StringLength(GeneralApplicationConstants.StudioConstants.StudioNameMaxLength, MinimumLength = GeneralApplicationConstants.StudioConstants.StudioNameMinLength)]
        public string StudioName { get; set; } = null!;

        [Required]
        public string ImgURL { get; set; } = null!;

        public decimal Budget { get; set; }
    }
}
