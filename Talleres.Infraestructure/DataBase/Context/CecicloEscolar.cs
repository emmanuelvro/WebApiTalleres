using System;
using System.Collections.Generic;

#nullable disable

namespace Talleres.Infraestructure.DataBase.Context
{
    public partial class CecicloEscolar
    {
        public string Empresa { get; set; }
        public string CicloEscolar { get; set; }
        public string TipoCicloEscolar { get; set; }
        public int Ejercicio { get; set; }
        public DateTime InicioCiclo { get; set; }
        public DateTime FinCiclo { get; set; }
        public DateTime InicioAdmision { get; set; }
        public DateTime FinAdmision { get; set; }
        public DateTime? UltActualizacion { get; set; }
        public string CicloAnterior { get; set; }
        public string Estatus { get; set; }
        public bool TieneMovimientos { get; set; }
        public string Usuario { get; set; }
        public string EstatusExpInt { get; set; }
        public bool? ExpInterna { get; set; }
        public bool? Inscripciones { get; set; }
        public DateTime? FechaBrinco { get; set; }
    }
}
