using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScaffoldActividad.Entities
{
    public partial class TransitoContext : DbContext
    {
        public TransitoContext()
        {
        }

        public TransitoContext(DbContextOptions<TransitoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conductores> Conductores { get; set; }
        public virtual DbSet<Matriculas> Matriculas { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                //optionsBuilder.UseSqlServer("server=P553D46;user=sa;password=siesa123456;database=Transito");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductores>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha_nacimiento)
                    .HasColumnName("Fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.identificacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.Conductores)
                    .HasForeignKey(d => d.MatriculaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_Matricula");
            });

            modelBuilder.Entity<Matriculas>(entity =>
            {
                entity.Property(e => e.FechaExpedicion).HasColumnType("date");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValidaHasta).HasColumnType("date");
            });

            modelBuilder.Entity<Sanciones>(entity =>
            {
                entity.Property(e => e.FechaActual).HasColumnType("date");

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.Property(e => e.Sancion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Conductores)
                    .WithMany(p => p.Sanciones)
                    .HasForeignKey(d => d.ConductoresId)
                    .HasConstraintName("fk_Conductor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
