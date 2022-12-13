using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class ColegioAlemanContext : DbContext
    {
        public ColegioAlemanContext()
        {
        }

        public ColegioAlemanContext(DbContextOptions<ColegioAlemanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Art> Arts { get; set; }
        public virtual DbSet<Cealumno> Cealumnos { get; set; }
        public virtual DbSet<CecicloEscolar> CecicloEscolars { get; set; }
        public virtual DbSet<ListaPreciosTallere> ListaPreciosTalleres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=52.171.208.207; Database=ColegioAleman; User=salfadmin;Password=Ca$a13man77",
                                    builder => builder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Art>(entity =>
            {
                entity.HasKey(e => e.Articulo)
                    .HasName("priArt");

                entity.ToTable("Art");

                entity.HasIndex(e => e.Categoria, "Categoria");

                entity.HasIndex(e => e.CategoriaActivoFijo, "CategoriaActivoFijo");

                entity.HasIndex(e => e.ClaveFabricante, "ClaveFabricante");

                entity.HasIndex(e => e.Codigo, "Codigo");

                entity.HasIndex(e => e.Descripcion1, "Descripcion1");

                entity.HasIndex(e => e.Estatus, "Estatus");

                entity.HasIndex(e => e.Fabricante, "Fabricante");

                entity.HasIndex(e => e.Familia, "Familia");

                entity.HasIndex(e => e.Grupo, "Grupo");

                entity.HasIndex(e => e.Linea, "Linea");

                entity.HasIndex(e => e.Proveedor, "Proveedor");

                entity.HasIndex(e => e.Rama, "Rama");

                entity.HasIndex(e => e.Temporada, "Temporada");

                entity.Property(e => e.Articulo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Abc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ABC");

                entity.Property(e => e.Actividades).HasDefaultValueSql("((0))");

                entity.Property(e => e.AlmacenEspecificoVenta)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AlmacenEspecificoVentaMov)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AlmacenRop)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AlmacenROP");

                entity.Property(e => e.Alta).HasColumnType("datetime");

                entity.Property(e => e.AnexosAlFacturar).HasDefaultValueSql("((0))");

                entity.Property(e => e.Arancel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArancelDesperdicio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AutoRecaudacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BasculaPesar).HasDefaultValueSql("((0))");

                entity.Property(e => e.CalcularPresupuesto).HasDefaultValueSql("((0))");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoriaActivoFijo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoriaProd)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CenoAplicaBeca)
                    .HasColumnName("CENoAplicaBeca")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CenoAplicaPorcMat)
                    .HasColumnName("CENoAplicaPorcMat")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CesumarizaEnFactura)
                    .HasColumnName("CESumarizaEnFactura")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Clase)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveFabricante)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClavePresupuestalImpuesto1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClavePresupuestalRetencion1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveVehicular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoAlterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comision)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Concepto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Consumibles).HasDefaultValueSql("((0))");

                entity.Property(e => e.ContUso)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContUso2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContUso3)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CostoIdentificado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cuenta)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cuenta2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cuenta3)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaPresupuesto)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Delegacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionNumero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionNumeroInt)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EntreCalles)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsDeducible).HasDefaultValueSql("((0))");

                entity.Property(e => e.EsFormula).HasDefaultValueSql("((0))");

                entity.Property(e => e.Espacios).HasDefaultValueSql("((0))");

                entity.Property(e => e.EspaciosBloquearAnteriores).HasDefaultValueSql("((1))");

                entity.Property(e => e.EspaciosEspecificos).HasDefaultValueSql("((0))");

                entity.Property(e => e.EspaciosHoraA)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EspaciosHoraD)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EspaciosMinutos).HasDefaultValueSql("((60))");

                entity.Property(e => e.EspaciosNivel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Dia')");

                entity.Property(e => e.Estado)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusCosto)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SINCAMBIO')");

                entity.Property(e => e.EstatusPrecio)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NUEVO')");

                entity.Property(e => e.Estructura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Excento2).HasDefaultValueSql("((0))");

                entity.Property(e => e.Excento3).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExcluirDescFormaPago).HasDefaultValueSql("((0))");

                entity.Property(e => e.Fabricante)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Factor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FactorCompra).HasDefaultValueSql("((1.0))");

                entity.Property(e => e.Familia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Iedu)
                    .HasColumnName("IEDU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Impuesto1Excento).HasDefaultValueSql("((0))");

                entity.Property(e => e.Incentivo).HasColumnType("money");

                entity.Property(e => e.Isan)
                    .HasColumnName("ISAN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Linea)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoteOrdenar)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LotesAuto).HasDefaultValueSql("((0))");

                entity.Property(e => e.LotesFijos).HasDefaultValueSql("((0))");

                entity.Property(e => e.Margen).HasColumnType("money");

                entity.Property(e => e.MargenMinimo).HasColumnType("money");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MonedaCosto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MonedaPrecio)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NivelAcceso)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NivelToleranciaCosto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('(Empresa)')");

                entity.Property(e => e.NombreCorto)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ObjetoGasto)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ObjetoGastoRef)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrigenLocalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrigenPais)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Peaje).HasColumnType("money");

                entity.Property(e => e.PedimentoClave)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PedimentoRegimen)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Permiso)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PermisoRenglon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Plano)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Poblacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio10).HasColumnType("money");

                entity.Property(e => e.Precio2).HasColumnType("money");

                entity.Property(e => e.Precio3).HasColumnType("money");

                entity.Property(e => e.Precio4).HasColumnType("money");

                entity.Property(e => e.Precio5).HasColumnType("money");

                entity.Property(e => e.Precio6).HasColumnType("money");

                entity.Property(e => e.Precio7).HasColumnType("money");

                entity.Property(e => e.Precio8).HasColumnType("money");

                entity.Property(e => e.Precio9).HasColumnType("money");

                entity.Property(e => e.PrecioAnterior).HasColumnType("money");

                entity.Property(e => e.PrecioLiberado).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrecioLista).HasColumnType("money");

                entity.Property(e => e.PrecioMinimo).HasColumnType("money");

                entity.Property(e => e.Presentacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdCantidad).HasDefaultValueSql("((1))");

                entity.Property(e => e.ProdEstacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProdMov)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('(por omision)')");

                entity.Property(e => e.ProdMovGrupo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdPasoTotal).HasDefaultValueSql("((1))");

                entity.Property(e => e.ProdRuta)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProdUsuario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('(Mismo)')");

                entity.Property(e => e.ProdVerConcentracion).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProdVerCostoAcumulado).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProdVerDesperdicio).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProdVerMerma).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProdVerPorcentaje).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProgramaSectorial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Proveedor)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rama)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Registro1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Registro1Vencimiento).HasColumnType("datetime");

                entity.Property(e => e.RevisionFrecuenciaUnidad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RevisionSiguiente).HasColumnType("datetime");

                entity.Property(e => e.RevisionUltima).HasColumnType("datetime");

                entity.Property(e => e.RevisionUsuario)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ruta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RutaDistribucion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Saux)
                    .HasColumnName("SAUX")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SeCompra).HasDefaultValueSql("((0))");

                entity.Property(e => e.SeVende).HasDefaultValueSql("((0))");

                entity.Property(e => e.SerieLoteInfo).HasDefaultValueSql("((0))");

                entity.Property(e => e.SeriesLotesAutoOrden)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('(Empresa)')");

                entity.Property(e => e.Servicios).HasDefaultValueSql("((0))");

                entity.Property(e => e.SincroC).HasDefaultValueSql("((1))");

                entity.Property(e => e.SincroId)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SincroID");

                entity.Property(e => e.Situacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SituacionFecha).HasColumnType("datetime");

                entity.Property(e => e.SituacionNota)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SituacionUsuario)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SolicitarPrecios).HasDefaultValueSql("((0))");

                entity.Property(e => e.Temporada)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoEntregaSegUnidad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoEntregaUnidad)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TieneDireccion).HasDefaultValueSql("((0))");

                entity.Property(e => e.TieneMovimientos).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Normal')");

                entity.Property(e => e.TipoCatalogo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Resurtible')");

                entity.Property(e => e.TipoCompra)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCosteo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoEmpaque)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoImpuesto1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoImpuesto2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoImpuesto3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoImpuesto4)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoImpuesto5)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoOpcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.TipoRetencion1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoRetencion2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoRetencion3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoVehiculo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToleranciaCosto).HasColumnType("money");

                entity.Property(e => e.ToleranciaCostoInferior).HasColumnType("money");

                entity.Property(e => e.TratadoComercial)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UltimoCambio).HasColumnType("datetime");

                entity.Property(e => e.Unidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadCompra)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadTarima)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadTraspaso)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Utilidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValidarCodigo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValidarPresupuestoCompra)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WMostrar)
                    .HasColumnName("wMostrar")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Cealumno>(entity =>
            {
                entity.HasKey(e => e.Alumno)
                    .HasName("priCEAlumno");

                entity.ToTable("CEAlumno");

                entity.Property(e => e.Alumno)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Beca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CicloEscolar)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CicloEscolarAnterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CicloEscolarNext)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Colonia)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Comentarios).HasColumnType("text");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Conyuge)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CptasistioCita)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTAsistioCita");

                entity.Property(e => e.CptasistioCita2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTAsistioCita2");

                entity.Property(e => e.Cptcanal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPTCanal");

                entity.Property(e => e.CptcanalContacto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPTCanalContacto");

                entity.Property(e => e.CptcanalDetalle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CPTCanalDetalle");

                entity.Property(e => e.CptcitaPersonal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTCitaPersonal");

                entity.Property(e => e.CptcitaPersonal2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTCitaPersonal2");

                entity.Property(e => e.CptcitaPersonalNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CPTCitaPersonalNombre");

                entity.Property(e => e.CptcitaPersonalNombre2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CPTCitaPersonalNombre2");

                entity.Property(e => e.CptdetalleSeguimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPTDetalleSeguimiento");

                entity.Property(e => e.Cptestatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTEstatus");

                entity.Property(e => e.CptfechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("CPTFechaAlta");

                entity.Property(e => e.CptfechaCita)
                    .HasColumnType("datetime")
                    .HasColumnName("CPTFechaCita");

                entity.Property(e => e.CptfechaCita2)
                    .HasColumnType("datetime")
                    .HasColumnName("CPTFechaCita2");

                entity.Property(e => e.CptfechaContacto)
                    .HasColumnType("datetime")
                    .HasColumnName("CPTFechaContacto");

                entity.Property(e => e.Cptgrupo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CPTGrupo");

                entity.Property(e => e.CptnivelAcademico)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTNivelAcademico");

                entity.Property(e => e.CptplanEstudio)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CPTPlanEstudio");

                entity.Property(e => e.CptplantelCita).HasColumnName("CPTPlantelCita");

                entity.Property(e => e.CptplantelCita2).HasColumnName("CPTPlantelCita2");

                entity.Property(e => e.CptplantelNombreCita)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPTPlantelNombreCita");

                entity.Property(e => e.CptplantelNombreCita2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CPTPlantelNombreCita2");

                entity.Property(e => e.Cptprograma)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTPrograma");

                entity.Property(e => e.CptsubPrograma)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTSubPrograma");

                entity.Property(e => e.Cptturno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPTTurno");

                entity.Property(e => e.Cuenta)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CuentaRetencion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CURP");

                entity.Property(e => e.Delegacion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion10)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion8)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion9)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionNumero)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionNumeroInt)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DobleNacionalidadPais)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EMailAuto).HasColumnName("eMailAuto");

                entity.Property(e => e.EMailAutoOtro).HasColumnName("eMailAutoOtro");

                entity.Property(e => e.EMailAutoParticular).HasColumnName("eMailAutoParticular");

                entity.Property(e => e.EMailAutoTrabajo).HasColumnName("eMailAutoTrabajo");

                entity.Property(e => e.EMailInt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("eMailInt");

                entity.Property(e => e.EMailOtro)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("eMailOtro");

                entity.Property(e => e.EMailParticular)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("eMailParticular");

                entity.Property(e => e.EMailTrabajo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("eMailTrabajo");

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaPuesto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaTrabajo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadNacimiento)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EntreCalles)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EsHijoMayor).HasDefaultValueSql("((0))");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusPortal)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Activo')");

                entity.Property(e => e.Extension)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FactorInc).HasColumnType("money");

                entity.Property(e => e.FacturarCte)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FacturarCte2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FacturarCte3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Familia)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.FechaInicioClases).HasColumnType("datetime");

                entity.Property(e => e.FechaMatrimonio).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.GrupoNext)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Hijos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Impaplaza).HasColumnName("IMPAPLAZA");

                entity.Property(e => e.LenguasIndigenas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListaPrecioEsp)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MatriculaSep)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MatriculaSEP");

                entity.Property(e => e.NivelAcademico)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NivelAcademicoAnterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NivelAcademicoNext)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoGenerarCuotasJob).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PaisNacimiento)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pbeca)
                    .HasColumnType("money")
                    .HasColumnName("PBeca");

                entity.Property(e => e.PerfilPortal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Alumno')");

                entity.Property(e => e.PlanEstudio)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlanEstudioAnterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlanEstudioNext)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PlanEstudioSituacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Poblacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Profesion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Programa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramaAnterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramaNext)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PueblosIndigenas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaBancaria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reinscripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Relacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RFC");

                entity.Property(e => e.Ruta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SincroId)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("SincroID");

                entity.Property(e => e.Situacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SituacionFecha).HasColumnType("datetime");

                entity.Property(e => e.SituacionNota)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SituacionUsuario)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Smsauto).HasColumnName("SMSAuto");

                entity.Property(e => e.SubPrograma)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubProgramaNext)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoMovil)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoOficina)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoOtro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoParticular)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TieneBeca).HasDefaultValueSql("((0))");

                entity.Property(e => e.TieneTransporte).HasDefaultValueSql("((0))");

                entity.Property(e => e.TipoConvenio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrabajaCasa)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Turno)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TurnoNext)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tutor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaSituacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UltimoCambio).HasColumnType("datetime");

                entity.Property(e => e.UsoImagen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioSesionPortal)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ViveCon)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CecicloEscolar>(entity =>
            {
                entity.HasKey(e => new { e.Empresa, e.CicloEscolar })
                    .HasName("priCECicloEscolar");

                entity.ToTable("CECicloEscolar");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CicloEscolar)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CicloAnterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusExpInt)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FechaBrinco).HasColumnType("datetime");

                entity.Property(e => e.FinAdmision).HasColumnType("datetime");

                entity.Property(e => e.FinCiclo).HasColumnType("datetime");

                entity.Property(e => e.InicioAdmision).HasColumnType("datetime");

                entity.Property(e => e.InicioCiclo).HasColumnType("datetime");

                entity.Property(e => e.TipoCicloEscolar)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UltActualizacion).HasColumnType("datetime");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ListaPreciosTallere>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Articulo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CicloEscolar)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
