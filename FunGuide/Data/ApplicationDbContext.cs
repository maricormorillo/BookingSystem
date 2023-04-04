using FunGuide.Areas.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FunGuide.Models;

namespace FunGuide.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Activities>()
            //    .HasMany(x => x.Users)
            //    .WithMany(x => x.Activities)
            //    .UsingEntity<UserActivities>(
            //        j => { j.HasKey(d => new { d.ActivityId, d.UserId })});

            builder.Entity<Activities>()
                 .HasMany(cd => cd.Users)
                 .WithMany(c => c.Activities)
                 .UsingEntity<UserActivities>(
                 j => j.HasOne(x => x.User)
                    .WithMany(x => x.UserActivities)
                    .HasForeignKey(x => x.UserId),
                    j => j.HasOne(x => x.Activities)
                    .WithMany(x => x.UserActivities)
                    .HasForeignKey(x => x.ActivityId),                
                    j =>
                    {
                        j.HasKey(d => new { d.UserId, d.ActivityId });
                    }
                 );
        }

        public DbSet<Activities> Activities { get; set; }
        public DbSet<UserActivities> UserActivities { get; set; }
    }
}