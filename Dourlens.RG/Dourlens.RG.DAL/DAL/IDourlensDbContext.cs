using Dourlens.RG.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dourlens.RG.DAL.DAL
{
    public interface IDourlensDbContext
    {
        public DbSet<Espion> Espions { get; set; }
        public DbSet<Mission> Missions { get; set; }
    }
}
