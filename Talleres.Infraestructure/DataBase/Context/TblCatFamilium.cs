using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblCatFamilium
    {
        public TblCatFamilium()
        {
            TblCatAlumnos = new HashSet<TblCatAlumno>();
        }

        public int Id { get; set; }
        public int Familia { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<TblCatAlumno> TblCatAlumnos { get; set; }
    }
}
