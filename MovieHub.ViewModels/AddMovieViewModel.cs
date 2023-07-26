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

        [Required]
        public int MovieLength { get; set; }

        [Required]
        public string ImgURL { get; set; } = null!;

        public decimal Budget { get; set; }
    }
}
