using Dourlens.RG.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dourlens.RG.DAL.DAL
{
    public class DourlensDbContext : DbContext, IDourlensDbContext
    {
        public DbSet<Espion> Espions { get; set; }
        public DbSet<Mission> Missions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Port=3306;Database=renseignements_generaux;Uid=root;Pwd=;";
            var serverVersion = new MySqlServerVersion(new Version(8, 2, 12));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
