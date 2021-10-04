using Basic_Raytracer.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Raytracer.Repository
{
    public class RaytraceContext : DbContext
    {
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<ShapeType> ShapeTypes { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public string DbPath { get; private set; }

        public RaytraceContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}raytrace.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
