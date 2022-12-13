using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblConfirmacione
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public int IdCiclo { get; set; }
        public double Monto { get; set; }
        public bool Descuento { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual TblCatAlumno IdAlumnoNavigation { get; set; }
        public virtual TblCatClicloEscolar IdCicloNavigation { get; set; }
    }
}
