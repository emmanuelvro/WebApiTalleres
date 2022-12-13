using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblGenero
    {
        public TblGenero()
        {
            TblAlumnos = new HashSet<TblAlumno>();
        }

        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Genero { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<TblAlumno> TblAlumnos { get; set; }
    }
}
