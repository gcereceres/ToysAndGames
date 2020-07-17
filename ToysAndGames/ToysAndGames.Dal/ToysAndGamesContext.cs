using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToysAndGames.Dal.Models;

namespace ToysAndGames.Dal
{
    public class ToysAndGamesContext : DbContext
    {
        public ToysAndGamesContext(DbContextOptions<ToysAndGamesContext> options) : base(options)
        {

        }

        public ToysAndGamesContext()
        {

        }

        public  virtual DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   Name = "Rubiks Cube 3X3",
                   Company = "Hasbro Gaming.",
                   Description = "The Rubik's 3X3 Cube has many combinations, but only one solution.",
                   AgeRestriction = 12,
                   Price = 149
               },
               new Product()
               {
                   Id = 2,
                   Name = "Risk",
                   Company = "Hasbro Gaming.",
                   Description = "Create your strategy and beat your enemies on the battlefield",
                   AgeRestriction = 8,
                   Price = 679
               },
               new Product()
               {
                   Id = 3,
                   Name = "Jenga",
                   Company = "Hasbro Gaming.",
                   Description = "Take the challenge and pull all the blocks from the tower",
                   AgeRestriction = 6,
                   Price = 269
               },
               new Product()
               {
                   Id = 4,
                   Name = "Ghost of Tsushima",
                   Company = "Sucker Punch Productions",
                   Description = "Action-adventure stealth game played from a third-person perspective.",
                   AgeRestriction = 15,
                   Price = 1599
               },
               new Product()
               {
                   Id = 5,
                   Name = "The Last of Us Part II",
                   Company = "Naughty Dog",
                   Description = "Ellie embarks on a relentless journey to carry out justice and find closure.",
                   AgeRestriction = 12,
                   Price = 149
               }
            );
        }
    }
}
