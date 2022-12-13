using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Models.Request
{
    public class Taller
    {
        public int? IdTaller { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public string Genero { get; set; }
        public int? IdNivelAcademico { get; set; }
        public string NivelAcademico { get; set; }
        public string Lenguaje { get; set; }
        public double Costo { get; set; }
        public double CostoComida { get; set; }
        public TimeSpan? HoraComida { get; set; }
        public TimeSpan? Inicio { get; set; }
        public TimeSpan? Salida { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Tipo { get; set; }
        public bool Selectivo { get; set; }
        public int IdPrograma { get; set; }
        public string Programa { get; set; }
        public int IdClico { get; set; }
        public bool Activo { get; set; }
        public int Cupo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public List<string> Galeria { get; set; }
        public string Profesores { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Taller> SubTalleres { get; set; }
        public List<Dias> Dias { get; set; }
        public List<Programas> Programas { get; set; }
        public string Observaciones { get; set; }
        public string Url_Video { get; set; }
        public bool IsComida { get; set; }
        public int IdPlantel { get; set; }
        public string IdIntelisis { get; set; }
        public bool Pagado { get; set; }
    }
}
