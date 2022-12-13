using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblPagosIntelisi
    {
        public int Id { get; set; }
        public int IdCiclo { get; set; }
        public int IdAlumno { get; set; }
        public int IdTaller { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual TblCatAlumno IdAlumnoNavigation { get; set; }
        public virtual TblCatClicloEscolar IdCicloNavigation { get; set; }
        public virtual TblCatTallere IdTallerNavigation { get; set; }
    }
}
