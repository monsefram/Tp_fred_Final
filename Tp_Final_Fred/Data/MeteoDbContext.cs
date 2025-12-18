using Microsoft.EntityFrameworkCore;
using Tp_Final_Fred.Models;
using System;
using System.IO;

namespace Tp_Final_Fred.Data
{
    public class MeteoDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "meteo.sqlite");

            options.UseSqlite($"Data Source={path}");
        }
    }
}
