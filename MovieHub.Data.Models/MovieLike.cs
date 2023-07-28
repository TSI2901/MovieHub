using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class MovieLike
    {
        [Required]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        [Required]
        [ForeignKey("Follower")]
        public string FollowerId { get; set; } = null!;
        public IdentityUser Follower { get; set; } = null!;
    }
}
