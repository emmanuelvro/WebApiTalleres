using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class ListaPreciosTallere
    {
        public string Articulo { get; set; }
        public bool PagosMensuales { get; set; }
        public string CicloEscolar { get; set; }
        public int Sucursal { get; set; }
        public double? Inscripcion { get; set; }
        public double? Mensualidaes { get; set; }
        public double? Semestre1 { get; set; }
        public double? Semestrre2 { get; set; }
    }
}
