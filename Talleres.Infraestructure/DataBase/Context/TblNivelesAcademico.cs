using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblNivelesAcademico
    {
        public TblNivelesAcademico()
        {
            TblAlumnos = new HashSet<TblAlumno>();
            TblProgramas = new HashSet<TblPrograma>();
        }

        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Nivel { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<TblAlumno> TblAlumnos { get; set; }
        public virtual ICollection<TblPrograma> TblProgramas { get; set; }
    }
}
