using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Models.Request
{
    public class Alumno
    {
        public int idAlumno { get; set; }
        public bool Activo { get; set; }
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public int Familia { get; set; }
        public string Genero { get; set; }
        public int? IdPlantel { get; set; }
        public string Plantel { get; set; }
        public int? IdNivelAcademico { get; set; }
        public string NivelAcademico { get; set; }
        public int? IdPrograma { get; set; }
        public string Programa { get; set; }
        public string Grupo { get; set; }
        public int idCliclo { get; set; }
        public bool CuotaAdministrativa { get; set; }
        public bool Ruta { get; set; }
        public List<Taller> Talleres { get; set; }
        public List<Horas> Horas { get; set; }
        public List<Inscripcion> Inscripcion { get; set; }
        public bool Adeudo { get; set; }
        public List<Dias> Dias { get; set; }
        public int Sucursal { get; set; }
        public Dictionary<int, bool> Transporte { get; set; }
        public Alumno()
        {
            this.Transporte = new Dictionary<int, bool>();
            this.Dias = new List<Dias>();
            this.Talleres = new List<Taller>();
        }
    }
}
