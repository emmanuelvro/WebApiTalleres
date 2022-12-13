using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblAlumno
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public int Matricula { get; set; }
        public int? IdPlantel { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? IdFamilia { get; set; }
        public int? IdGenero { get; set; }
        public int? IdNivelAcademico { get; set; }
        public int? IdPrograma { get; set; }
        public string Grupo { get; set; }
        public string Estatus { get; set; }
        public string Situacion { get; set; }
        public bool Adeudo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual TblFamilia IdFamiliaNavigation { get; set; }
        public virtual TblGenero IdGeneroNavigation { get; set; }
        public virtual TblNivelesAcademico IdNivelAcademicoNavigation { get; set; }
        public virtual TblPlantele IdPlantelNavigation { get; set; }
        public virtual TblPrograma IdProgramaNavigation { get; set; }
    }
}
