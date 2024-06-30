using ExoTModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExoTContext
{
    public class ExoContext : DbContext
    {
        public ExoContext(DbContextOptions<ExoContext> options) : base(options)
        {
        }

        public DbSet<Tache> Tache { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tache>(
            b =>
            {
                b.HasKey("Id");

                b.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                b.Property(e => e.Titre)
                    .IsRequired();

                b.Property(e => e.Creation)
                    .ValueGeneratedOnAdd();

                b.Property(e => e.Terminer)
                    .ValueGeneratedOnAdd();
            });

        }
    }
}
