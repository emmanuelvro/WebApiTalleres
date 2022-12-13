using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Models.Request
{
    public class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public int IdAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public int Familia { get; set; }
        public string Grado { get; set; }
        public int IdTaller { get; set; }
        public string NombreTaller { get; set; }
        public int IdSubtaller { get; set; }
        public string NombreSubtaller { get; set; }
        public double Costo { get; set; }
        public int Matricula { get; set; }
        public bool? Selectivo { get; set; }
        public bool CuotaAdministrativa { get; set; }
        public bool IsComida { get; set; }
        public bool Action { get; set; }
        public TimeSpan? Inicio { get; set; }
        public TimeSpan? Fin { get; set; }
        public TimeSpan? HoraComida { get; set; }
        public List<Dias> Dias { get; set; }
        public int IdPlantel { get; set; }
        public string IdIntelisis { get; set; }
        public bool Enviada { get; set; }

    }
}
