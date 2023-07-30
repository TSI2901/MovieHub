using MovieHub.Common;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MovieHub.Data.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(GeneralApplicationConstants.CommentConstants.CommentMaxLength)]
        public string CommentEssence { get; set; } = null!;

        [Required]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        [Required]
        public Movie Movie { get; set; } = null!;

        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; } = null!;
        [Required]
        public IdentityUser Author { get; set; } = null!;
    }
}
