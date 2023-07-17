using MovieHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class Reward
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(GeneralApplicationConstants.RewardConstants.RewardNameMaxLength)]
        public string Title { get; set; } = null!;
    }
}
