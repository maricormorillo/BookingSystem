using FunGuide.Areas.Data;
using System.Diagnostics;

namespace FunGuide.Models
{
    public class UserActivities
    {
        public AppUser? User { get; set; }
        public string? UserId { get; set; }
        public Activities? Activities { get; set; }
        public int? ActivityId { get; set; }
    }
}
