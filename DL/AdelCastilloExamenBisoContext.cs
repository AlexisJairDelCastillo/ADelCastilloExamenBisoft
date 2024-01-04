using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class AdelCastilloExamenBisoContext : DbContext
{
    public AdelCastilloExamenBisoContext()
    {
    }

    public AdelCastilloExamenBisoContext(DbContextOptions<AdelCastilloExamenBisoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CiclistaClase> CiclistaClases { get; set; }

    public virtual DbSet<Ciclistum> Ciclista { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=ADelCastilloExamenBiso; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CiclistaClase>(entity =>
        {
            entity.HasKey(e => e.IdRelacion).HasName("PK__Ciclista__D27D6AE79FD242D4");

            entity.ToTable("CiclistaClase");

            entity.HasOne(d => d.IdCiclistaNavigation).WithMany(p => p.CiclistaClases)
                .HasForeignKey(d => d.IdCiclista)
                .HasConstraintName("FK__CiclistaC__IdCic__1A14E395");

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.CiclistaClases)
                .HasForeignKey(d => d.IdClase)
                .HasConstraintName("FK__CiclistaC__IdCla__1B0907CE");
        });

        modelBuilder.Entity<Ciclistum>(entity =>
        {
            entity.HasKey(e => e.IdCiclista).HasName("PK__Ciclista__43084A515ED6A959");

            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nivel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreCiclista)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.IdClase).HasName("PK__Clase__003FCC6F757E15C0");

            entity.ToTable("Clase");

            entity.Property(e => e.Aula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Horario)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Nivel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreClase)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
