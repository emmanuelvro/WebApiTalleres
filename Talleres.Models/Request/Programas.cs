using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talleres.Models.Request
{
    public class Programas
    {
        public int IdPrograma { get; set; }
        public string Programa { get; set; }
        public bool Activo { get; set; }
        public int? IdNivel { get; set; }
        public bool Selected { get; set; }
    }
}
