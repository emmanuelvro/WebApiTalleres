using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblFamilia
    {
        public TblFamilia()
        {
            TblAlumnos = new HashSet<TblAlumno>();
        }

        public int Id { get; set; }
        public Guid Uid { get; set; }
        public int Familia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<TblAlumno> TblAlumnos { get; set; }
    }
}
