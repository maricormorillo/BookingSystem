using Microsoft.EntityFrameworkCore;
using FunGuide.Data;

namespace FunGuide.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any activities.
                if (context.Activities.Any())
                {
                    return;   // DB has been seeded
                }
                context.Activities.AddRange(
                    new Activities
                    {
                        Name = "Universal Studios Singapore Ticket",
                        Description = "The only Universal Studios theme park in Southeast Asia, offering exhilarating rides, performances, and attractions inspired by well-known movies and TV shows.",
                        Category = "Theme Parks",
                        Price = 90.00M
                    },
                    new Activities
                    {
                        Name = "ArtScience Museum Ticket",
                        Description = "The ArtScience Museum at Marina Bay Sands offers an engaging educational experience where you can learn about art, space, technology, and more.",
                        Category = "Museums",
                        Price = 70.00M
                    },
                    new Activities
                    {
                        Name = "Singapore River Cruise",
                        Description = "Take a leisurely trip on the famous bumboat down the beautiful river in Singapore.",
                        Category = "Day Trips",
                        Price = 50
                    },
                    new Activities
                    {
                        Name = "Gardens by the Bay Ticket",
                        Description = "Gardens by the Bay, one of Asia's top horticultural attractions, provides a picturesque haven for nature and photography enthusiasts as well as the family.",
                        Category = "Attraction Passes",
                        Price = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
