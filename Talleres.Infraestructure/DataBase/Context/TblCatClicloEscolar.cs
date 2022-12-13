using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblCatClicloEscolar
    {
        public TblCatClicloEscolar()
        {
            TblCatAlumnos = new HashSet<TblCatAlumno>();
            TblCatTalleres = new HashSet<TblCatTallere>();
            TblConfirmaciones = new HashSet<TblConfirmacione>();
            TblPagosIntelisis = new HashSet<TblPagosIntelisi>();
        }

        public int Id { get; set; }
        public string Ciclo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int IdPlantel { get; set; }

        public virtual ICollection<TblCatAlumno> TblCatAlumnos { get; set; }
        public virtual ICollection<TblCatTallere> TblCatTalleres { get; set; }
        public virtual ICollection<TblConfirmacione> TblConfirmaciones { get; set; }
        public virtual ICollection<TblPagosIntelisi> TblPagosIntelisis { get; set; }
    }
}
