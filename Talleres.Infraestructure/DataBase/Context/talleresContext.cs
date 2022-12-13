using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class talleresContext : DbContext
    {
        public talleresContext()
        {
        }

        public talleresContext(DbContextOptions<talleresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAlumno> TblAlumnos { get; set; }
        public virtual DbSet<TblCiclo> TblCiclos { get; set; }
        public virtual DbSet<TblFamilia> TblFamilias { get; set; }
        public virtual DbSet<TblGenero> TblGeneros { get; set; }
        public virtual DbSet<TblNivelesAcademico> TblNivelesAcademicos { get; set; }
        public virtual DbSet<TblPlantele> TblPlanteles { get; set; }
        public virtual DbSet<TblPrograma> TblProgramas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblAlumno>(entity =>
            {
                entity.ToTable("tbl_Alumnos");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Grupo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Situacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamiliaNavigation)
                    .WithMany(p => p.TblAlumnos)
                    .HasForeignKey(d => d.IdFamilia)
                    .HasConstraintName("FK__tbl_Alumn__IdFam__6C190EBB");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.TblAlumnos)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__tbl_Alumn__IdGen__6D0D32F4");

                entity.HasOne(d => d.IdNivelAcademicoNavigation)
                    .WithMany(p => p.TblAlumnos)
                    .HasForeignKey(d => d.IdNivelAcademico)
                    .HasConstraintName("FK__tbl_Alumn__IdNiv__6E01572D");

                entity.HasOne(d => d.IdPlantelNavigation)
                    .WithMany(p => p.TblAlumnos)
                    .HasForeignKey(d => d.IdPlantel)
                    .HasConstraintName("FK__tbl_Alumn__IdPla__6EF57B66");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.TblAlumnos)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK__tbl_Alumn__IdPro__6FE99F9F");
            });

            modelBuilder.Entity<TblCiclo>(entity =>
            {
                entity.ToTable("tbl_Ciclos");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Ciclo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPlantelNavigation)
                    .WithMany(p => p.TblCiclos)
                    .HasForeignKey(d => d.IdPlantel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Ciclos_tbl_Planteles");
            });

            modelBuilder.Entity<TblFamilia>(entity =>
            {
                entity.ToTable("tbl_Familias");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblGenero>(entity =>
            {
                entity.ToTable("tbl_Generos");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblNivelesAcademico>(entity =>
            {
                entity.ToTable("tbl_NivelesAcademicos");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nivel)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPlantele>(entity =>
            {
                entity.ToTable("tbl_Planteles");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Plantel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPrograma>(entity =>
            {
                entity.ToTable("tbl_Programas");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Programa)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.TblProgramas)
                    .HasForeignKey(d => d.IdNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Progr__IdNiv__66603565");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
