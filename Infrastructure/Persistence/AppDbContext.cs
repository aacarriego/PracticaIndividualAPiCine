using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {


        // Set de tablas (entidades)
        public DbSet<Sala> Salas { get; set; }

        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Funcion> Funciones { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.ToTable("Funciones");
                entity.HasKey(f => f.FuncionId);
                entity.Property(f => f.FuncionId).ValueGeneratedOnAdd();

                entity.HasOne(fun => fun.Pelicula)
                      .WithMany(pel => pel.Funciones)
                      .HasForeignKey(fun => fun.PeliculaId);

            });


            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Generos");
                entity.HasKey(f => f.GeneroId);
                entity.Property(f => f.GeneroId).ValueGeneratedOnAdd();

                entity.HasMany(gen => gen.Peliculas)
                      .WithOne(pel => pel.Genero)
                      .HasForeignKey(p => p.GeneroId);

            });



            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Salas");
                entity.HasKey(f => f.SalaId);
                entity.Property(f => f.SalaId).ValueGeneratedOnAdd();
                entity.HasMany(s => s.Funciones)
                      .WithOne(f => f.Sala)
                      .HasForeignKey(f => f.SalaId);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Tickets");
                entity.HasKey(t => t.TicketId);
                entity.Property(t => t.TicketId).ValueGeneratedOnAdd();
                entity.HasOne(t => t.funcion)
                      .WithMany(f => f.Tickets)
                      .HasForeignKey(t => t.FuncionId);
            });


         
        }



    }
}
