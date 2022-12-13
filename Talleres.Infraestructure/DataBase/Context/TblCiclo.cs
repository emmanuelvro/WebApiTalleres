using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class TblCiclo
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Ciclo { get; set; }
        public int IdPlantel { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool? Activo { get; set; }

        public virtual TblPlantele IdPlantelNavigation { get; set; }
    }
}
