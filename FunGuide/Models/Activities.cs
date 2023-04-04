using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FunGuide.Areas.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FunGuide.Models
{
    public class Activities
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required] 
        public string? Name { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required]
        public string? Description { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Category { get; set; }

        [Range(1, 500)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public List<AppUser>? Users { get; set; }
        public List<UserActivities>? UserActivities { get; set; }
    }
}
