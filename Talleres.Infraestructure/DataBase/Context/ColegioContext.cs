using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class colegioContext : DbContext
    {
        public colegioContext()
        {
        }

        public colegioContext(DbContextOptions<colegioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCatAlumno> TblCatAlumnos { get; set; }
        public virtual DbSet<TblCatClicloEscolar> TblCatClicloEscolars { get; set; }
        public virtual DbSet<TblCatFamilium> TblCatFamilia { get; set; }
        public virtual DbSet<TblCatNivelAcademico> TblCatNivelAcademicos { get; set; }
        public virtual DbSet<TblCatPrograma> TblCatProgramas { get; set; }
        public virtual DbSet<TblCatTallere> TblCatTalleres { get; set; }
        public virtual DbSet<TblConfirmacione> TblConfirmaciones { get; set; }
        public virtual DbSet<TblPagosIntelisi> TblPagosIntelises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=13.65.103.115; Database=colegio; User=sa; Password=SQL20224CAL4M4n.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblCatAlumno>(entity =>
            {
                entity.ToTable("tbl_Cat_Alumnos");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Grupo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClicloEscolarNavigation)
                    .WithMany(p => p.TblCatAlumnos)
                    .HasForeignKey(d => d.IdClicloEscolar)
                    .HasConstraintName("FK__tbl_Cat_A__IdCli__7D439ABD");

                entity.HasOne(d => d.IdFamiliaNavigation)
                    .WithMany(p => p.TblCatAlumnos)
                    .HasForeignKey(d => d.IdFamilia)
                    .HasConstraintName("FK__tbl_Cat_A__IdFam__787EE5A0");

                entity.HasOne(d => d.IdNivelAcademicoNavigation)
                    .WithMany(p => p.TblCatAlumnos)
                    .HasForeignKey(d => d.IdNivelAcademico)
                    .HasConstraintName("FK__tbl_Cat_A__IdNiv__7B5B524B");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.TblCatAlumnos)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK__tbl_Cat_A__IdPro__7C4F7684");
            });

            modelBuilder.Entity<TblCatClicloEscolar>(entity =>
            {
                entity.ToTable("tbl_Cat_ClicloEscolar");

                entity.Property(e => e.Ciclo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdPlantel).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblCatFamilium>(entity =>
            {
                entity.ToTable("tbl_Cat_Familia");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblCatNivelAcademico>(entity =>
            {
                entity.ToTable("tbl_Cat_NivelAcademico");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nivel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCatPrograma>(entity =>
            {
                entity.ToTable("tbl_Cat_Programas");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Programa)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNivelAcademicoNavigation)
                    .WithMany(p => p.TblCatProgramas)
                    .HasForeignKey(d => d.IdNivelAcademico)
                    .HasConstraintName("FK__tbl_Cat_P__IdNiv__403A8C7D");
            });

            modelBuilder.Entity<TblCatTallere>(entity =>
            {
                entity.ToTable("tbl_Cat_Talleres");

                entity.Property(e => e.Alias).HasMaxLength(100);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliclo).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdIntelisis)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IdPlantel).HasDefaultValueSql("((1))");

                entity.Property(e => e.Lenguaje)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Profesor).HasMaxLength(250);

                entity.Property(e => e.Selectivo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UrlVideo).HasColumnName("Url_video");

                entity.HasOne(d => d.IdClicloNavigation)
                    .WithMany(p => p.TblCatTalleres)
                    .HasForeignKey(d => d.IdCliclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Tall__IdCiclo__503BEA1C");

                entity.HasOne(d => d.IdNivelAcademicoNavigation)
                    .WithMany(p => p.TblCatTalleres)
                    .HasForeignKey(d => d.IdNivelAcademico)
                    .HasConstraintName("FK__tbl_Cat_T__IdNiv__160F4887");
            });

            modelBuilder.Entity<TblConfirmacione>(entity =>
            {
                entity.ToTable("tbl_Confirmaciones");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.TblConfirmaciones)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Confirmaciones_tbl_Cat_Alumnos");

                entity.HasOne(d => d.IdCicloNavigation)
                    .WithMany(p => p.TblConfirmaciones)
                    .HasForeignKey(d => d.IdCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Confirmaciones_tbl_Cat_ClicloEscolar");
            });

            modelBuilder.Entity<TblPagosIntelisi>(entity =>
            {
                entity.ToTable("tbl_PagosIntelisis");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.TblPagosIntelisis)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PagosIntelisis_tbl_Cat_Alumnos");

                entity.HasOne(d => d.IdCicloNavigation)
                    .WithMany(p => p.TblPagosIntelisis)
                    .HasForeignKey(d => d.IdCiclo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PagosIntelisis_tbl_Cat_ClicloEscolar");

                entity.HasOne(d => d.IdTallerNavigation)
                    .WithMany(p => p.TblPagosIntelisis)
                    .HasForeignKey(d => d.IdTaller)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PagosIntelisis_tbl_Cat_Talleres");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
