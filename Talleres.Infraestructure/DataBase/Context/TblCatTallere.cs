using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblCatTallere
    {
        public TblCatTallere()
        {
            TblPagosIntelisis = new HashSet<TblPagosIntelisi>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int? IdNivelAcademico { get; set; }
        public string Lenguaje { get; set; }
        public double Costo { get; set; }
        public double CostoComida { get; set; }
        public TimeSpan? HoraComida { get; set; }
        public TimeSpan? Inicio { get; set; }
        public TimeSpan? Salida { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Tipo { get; set; }
        public int Cupo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public bool? Selectivo { get; set; }
        public string Profesor { get; set; }
        public int IdCliclo { get; set; }
        public string UrlVideo { get; set; }
        public bool IsComida { get; set; }
        public string Alias { get; set; }
        public int IdPlantel { get; set; }
        public string IdIntelisis { get; set; }

        public virtual TblCatClicloEscolar IdClicloNavigation { get; set; }
        public virtual TblCatNivelAcademico IdNivelAcademicoNavigation { get; set; }
        public virtual ICollection<TblPagosIntelisi> TblPagosIntelisis { get; set; }
    }
}
