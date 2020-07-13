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

        public DbSet<Product> Products { get; set; }
    }
}
