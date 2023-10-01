using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BolsaValores.DataAccess.Persistences.BolsaValores;

public partial class BolsaValoresTestContext : DbContext
{
    public BolsaValoresTestContext()
    {
    }

    public BolsaValoresTestContext(DbContextOptions<BolsaValoresTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accion> Accion { get; set; }

    public virtual DbSet<BitacoraErrores> BitacoraErrores { get; set; }

    public virtual DbSet<BitacoraHistorial> BitacoraHistorial { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:BolsaValores");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accion>(entity =>
        {
            entity.HasKey(e => e.IdAccion).HasName("PK__Accion__E0B207A41062FBC9");

            entity.Property(e => e.IdAccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idAccion");
            entity.Property(e => e.Abre)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("abre");
            entity.Property(e => e.Alta)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("alta");
            entity.Property(e => e.Baja)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("baja");
            entity.Property(e => e.Cierra)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cierra");
            entity.Property(e => e.Codigo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora)
                .HasColumnType("datetime")
                .HasColumnName("hora");
        });

        modelBuilder.Entity<BitacoraErrores>(entity =>
        {
            entity.HasKey(e => e.IdBitacoraErrores).HasName("PK__Bitacora__64619F13E3BC5DC0");

            entity.Property(e => e.IdBitacoraErrores)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("idBitacoraErrores");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
        });

        modelBuilder.Entity<BitacoraHistorial>(entity =>
        {
            entity.HasKey(e => e.IdBitacoraHistorial).HasName("PK__Bitacora__9A1C34CB21166CF9");

            entity.Property(e => e.IdBitacoraHistorial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("idBitacoraHistorial");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.IdAccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idAccion");

            entity.HasOne(d => d.CorreoNavigation).WithMany(p => p.BitacoraHistorial)
                .HasForeignKey(d => d.Correo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BitacoraH__corre__619B8048");

            entity.HasOne(d => d.IdAccionNavigation).WithMany(p => p.BitacoraHistorial)
                .HasForeignKey(d => d.IdAccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BitacoraH__idAcc__60A75C0F");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Correo).HasName("PK__Usuario__2A586E0A19B4E70A");

            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contrasena");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
