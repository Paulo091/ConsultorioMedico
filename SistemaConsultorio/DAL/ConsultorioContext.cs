using Microsoft.EntityFrameworkCore;
using SistemaConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaConsultorio.DAL
{
    public class ConsultorioContext : DbContext
    {
        DbSet<Pacientes> Pacientes { get; set; }
        DbSet<Medicos> Medicos { get; set; }
        DbSet<Consultas> Consultas { get; set; }

        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacientes>().Property(x => x.Nome).IsRequired();
            modelBuilder.Entity<Pacientes>().Property(x => x.DataNascimento).IsRequired();
        }
    }
}
