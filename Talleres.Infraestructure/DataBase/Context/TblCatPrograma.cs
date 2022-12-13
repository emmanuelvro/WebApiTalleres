using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblCatPrograma
    {
        public TblCatPrograma()
        {
            TblCatAlumnos = new HashSet<TblCatAlumno>();
        }

        public int Id { get; set; }
        public string Programa { get; set; }
        public int? IdNivelAcademico { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public virtual TblCatNivelAcademico IdNivelAcademicoNavigation { get; set; }
        public virtual ICollection<TblCatAlumno> TblCatAlumnos { get; set; }
    }
}
