using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Dal;
using ToysAndGames.Dal.Models;

namespace ToysAndGames.Web.Services
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToysAndGamesContext(serviceProvider.GetRequiredService<DbContextOptions<ToysAndGamesContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }

                context.Products.Add(new Product()
                {
                    Id = 1,
                    Name = "Rubiks Cube 3X3",
                    Company = "Hasbro Gaming.",
                    Description = "The Rubik's 3X3 Cube has many combinations, but only one solution.",
                    AgeRestriction = 12,
                    Price = 149
                });

                context.Products.Add(new Product()
                {
                    Id = 2,
                    Name = "Risk",
                    Company = "Hasbro Gaming.",
                    Description = "Create your strategy and beat your enemies on the battlefield",
                    AgeRestriction = 8,
                    Price = 679
                });

                context.Products.Add(new Product()
                {
                    Id = 3,
                    Name = "Jenga",
                    Company = "Hasbro Gaming.",
                    Description = "Take the challenge and pull all the blocks from the tower",
                    AgeRestriction = 6,
                    Price = 269
                });

                context.Products.Add(new Product()
                {
                    Id = 4,
                    Name = "Ghost of Tsushima",
                    Company = "Sucker Punch Productions",
                    Description = "Action-adventure stealth game played from a third-person perspective.",
                    AgeRestriction = 15,
                    Price = 1599
                });

                context.Products.Add(new Product()
                {
                    Id = 5,
                    Name = "The Last of Us Part II",
                    Company = "Naughty Dog",
                    Description = "Ellie embarks on a relentless journey to carry out justice and find closure.",
                    AgeRestriction = 12,
                    Price = 149
                });

                context.SaveChanges();
            }
        }
    }
}
