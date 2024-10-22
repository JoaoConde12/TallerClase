using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TallerClase.Models;

namespace TallerClase.Data
{
    public class TallerClaseContext : DbContext
    {
        public TallerClaseContext (DbContextOptions<TallerClaseContext> options)
            : base(options)
        {
        }

        public DbSet<TallerClase.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<TallerClase.Models.Estadio> Estadio { get; set; } = default!;
        public DbSet<TallerClase.Models.Futbolista> Futbolista { get; set; } = default!;
    }
}
