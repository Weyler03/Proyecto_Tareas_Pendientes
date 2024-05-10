using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sistema_Tareas.Models;

public partial class SistemaTareasContext : DbContext
{
    public SistemaTareasContext()
    {
    }

    public SistemaTareasContext(DbContextOptions<SistemaTareasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTareas).HasName("PK__Tareas__0F207C4B38B55A59");

            entity.Property(e => e.IdTareas).HasColumnName("Id_Tareas");
            entity.Property(e => e.EstadoTarea)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('No Completada')")
                .HasColumnName("Estado_Tarea");
            entity.Property(e => e.NombreTarea)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Tarea");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
