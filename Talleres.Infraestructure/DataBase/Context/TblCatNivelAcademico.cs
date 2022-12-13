using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblCatNivelAcademico
    {
        public TblCatNivelAcademico()
        {
            TblCatAlumnos = new HashSet<TblCatAlumno>();
            TblCatProgramas = new HashSet<TblCatPrograma>();
            TblCatTalleres = new HashSet<TblCatTallere>();
        }

        public int Id { get; set; }
        public string Nivel { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<TblCatAlumno> TblCatAlumnos { get; set; }
        public virtual ICollection<TblCatPrograma> TblCatProgramas { get; set; }
        public virtual ICollection<TblCatTallere> TblCatTalleres { get; set; }
    }
}
