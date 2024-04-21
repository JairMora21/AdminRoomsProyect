using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdminRooms.Models;

public partial class DbRoomsContext : DbContext
{
    public DbRoomsContext()
    {
    }

    public DbRoomsContext(DbContextOptions<DbRoomsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignacion> Asignacions { get; set; }

    public virtual DbSet<Casa> Casas { get; set; }

    public virtual DbSet<Cobro> Cobros { get; set; }

    public virtual DbSet<Cuarto> Cuartos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<GastosFijo> GastosFijos { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Huesped> Huespeds { get; set; }

    public virtual DbSet<TipoGasto> TipoGastos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);

            entity.ToTable("Asignacion");

            entity.Property(e => e.IdAsignacion).HasColumnName("Id_Asignacion");
            entity.Property(e => e.IdCasa).HasColumnName("Id_Casa");
            entity.Property(e => e.IdCuarto).HasColumnName("Id_Cuarto");
            entity.Property(e => e.IdHuesped).HasColumnName("Id_Huesped");
            entity.Property(e => e.UltimoPago)
                .HasColumnType("date")
                .HasColumnName("Ultimo_Pago");

            entity.HasOne(d => d.IdCasaNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdCasa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Casa");

            entity.HasOne(d => d.IdCuartoNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdCuarto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Cuarto");

            entity.HasOne(d => d.IdHuespedNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdHuesped)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Huesped");
        });

        modelBuilder.Entity<Casa>(entity =>
        {
            entity.HasKey(e => e.IdCasa);

            entity.ToTable("Casa");

            entity.Property(e => e.IdCasa).HasColumnName("Id_Casa");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroCuartos).HasColumnName("Numero_Cuartos");
        });

        modelBuilder.Entity<Cobro>(entity =>
        {
            entity.HasKey(e => e.IdCobros);

            entity.Property(e => e.IdCobros).HasColumnName("Id_Cobros");
            entity.Property(e => e.IdAsignacion).HasColumnName("Id_Asignacion");
            entity.Property(e => e.Periodo).HasColumnType("date");

            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.Cobros)
                .HasForeignKey(d => d.IdAsignacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cobros_Asignacion");
        });

        modelBuilder.Entity<Cuarto>(entity =>
        {
            entity.HasKey(e => e.IdCuarto);

            entity.ToTable("Cuarto");

            entity.Property(e => e.IdCuarto).HasColumnName("Id_Cuarto");
            entity.Property(e => e.IdAsignacion).HasColumnName("Id_Asignacion");
            entity.Property(e => e.IdCasa).HasColumnName("Id_Casa");
            entity.Property(e => e.IdHuesped).HasColumnName("Id_Huesped");
            entity.Property(e => e.NumeroCuarto).HasColumnName("Numero_Cuarto");

            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.Cuartos)
                .HasForeignKey(d => d.IdAsignacion)
                .HasConstraintName("FK_Cuarto_Asignacion");

            entity.HasOne(d => d.IdCasaNavigation).WithMany(p => p.Cuartos)
                .HasForeignKey(d => d.IdCasa)
                .HasConstraintName("FK_Cuarto_Casa");

            entity.HasOne(d => d.IdHuespedNavigation).WithMany(p => p.Cuartos)
                .HasForeignKey(d => d.IdHuesped)
                .HasConstraintName("FK_Cuarto_Huesped");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura);

            entity.ToTable("Factura");

            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.Concepto)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Huesped)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdAsignacion).HasColumnName("Id_Asignacion");

            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdAsignacion)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Factura_Asignacion");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.IdGasto).HasName("PK_Gastos_1");

            entity.Property(e => e.IdGasto).HasColumnName("Id_Gasto");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.IdGastoFijo).HasColumnName("Id_GastoFijo");
            entity.Property(e => e.IdTipoGasto).HasColumnName("Id_TipoGasto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoGastoNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.IdTipoGasto)
                .HasConstraintName("FK_Gastos_TipoGasto");
        });

        modelBuilder.Entity<GastosFijo>(entity =>
        {
            entity.HasKey(e => e.IdGastosFijos);

            entity.Property(e => e.IdGastosFijos).HasColumnName("Id_GastosFijos");
            entity.Property(e => e.FechaAviso)
                .HasColumnType("date")
                .HasColumnName("Fecha_Aviso");
            entity.Property(e => e.FechaPagado)
                .HasColumnType("date")
                .HasColumnName("Fecha_Pagado");
            entity.Property(e => e.IdTipoGasto).HasColumnName("Id_TipoGasto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoGastoNavigation).WithMany(p => p.GastosFijos)
                .HasForeignKey(d => d.IdTipoGasto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GastosFijos_TipoGasto");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero);

            entity.ToTable("Genero");

            entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");
            entity.Property(e => e.Genero1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Genero");
        });

        modelBuilder.Entity<Huesped>(entity =>
        {
            entity.HasKey(e => e.IdHuesped);

            entity.ToTable("Huesped");

            entity.Property(e => e.IdHuesped).HasColumnName("Id_Huesped");
            entity.Property(e => e.Alacena)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta)
                .HasColumnType("date")
                .HasColumnName("Fecha_Alta");
            entity.Property(e => e.FechaSalidaPrev)
                .HasColumnType("date")
                .HasColumnName("Fecha_Salida_Prev");
            entity.Property(e => e.IdCasa).HasColumnName("Id_Casa");
            entity.Property(e => e.IdCuarto).HasColumnName("Id_Cuarto");
            entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");
            entity.Property(e => e.MotivoEstancia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Motivo_Estancia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PagoInicial).HasColumnName("Pago_Inicial");
            entity.Property(e => e.Refrigerador)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoEmergencia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Telefono_Emergencia");

            entity.HasOne(d => d.IdCasaNavigation).WithMany(p => p.Huespeds)
                .HasForeignKey(d => d.IdCasa)
                .HasConstraintName("FK_Huesped_Casa");

            entity.HasOne(d => d.IdCuartoNavigation).WithMany(p => p.Huespeds)
                .HasForeignKey(d => d.IdCuarto)
                .HasConstraintName("FK_Huesped_Cuarto");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Huespeds)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Huesped_Genero");
        });

        modelBuilder.Entity<TipoGasto>(entity =>
        {
            entity.HasKey(e => e.IdTipoGasto);

            entity.ToTable("TipoGasto");

            entity.Property(e => e.IdTipoGasto).HasColumnName("id_TipoGasto");
            entity.Property(e => e.IdTemp).HasColumnName("id_temp");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
