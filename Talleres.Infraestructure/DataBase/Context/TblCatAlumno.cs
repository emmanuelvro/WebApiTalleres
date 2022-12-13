using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblCatAlumno
    {
        public TblCatAlumno()
        {
            TblConfirmaciones = new HashSet<TblConfirmacione>();
            TblPagosIntelisis = new HashSet<TblPagosIntelisi>();
        }

        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? IdFamilia { get; set; }
        public int? IdGenero { get; set; }
        public int? IdPlantel { get; set; }
        public int? IdNivelAcademico { get; set; }
        public int? IdPrograma { get; set; }
        public string Grupo { get; set; }
        public int? IdClicloEscolar { get; set; }
        public int? IdEstatus { get; set; }
        public int? IdSituacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public bool Adeudo { get; set; }
        public bool Ruta { get; set; }

        public virtual TblCatClicloEscolar IdClicloEscolarNavigation { get; set; }
        public virtual TblCatFamilium IdFamiliaNavigation { get; set; }
        public virtual TblCatNivelAcademico IdNivelAcademicoNavigation { get; set; }
        public virtual TblCatPrograma IdProgramaNavigation { get; set; }
        public virtual ICollection<TblConfirmacione> TblConfirmaciones { get; set; }
        public virtual ICollection<TblPagosIntelisi> TblPagosIntelisis { get; set; }
    }
}
