using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblPlantele
    {
        public TblPlantele()
        {
            TblAlumnos = new HashSet<TblAlumno>();
            TblCiclos = new HashSet<TblCiclo>();
        }

        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Plantel { get; set; }
        public int Sucursal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<TblAlumno> TblAlumnos { get; set; }
        public virtual ICollection<TblCiclo> TblCiclos { get; set; }
    }
}
