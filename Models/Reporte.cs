using System;
using System.Collections.Generic;

#nullable disable

namespace pruebaHACSYS.Models
{
    public partial class Reporte
    {
        public string IdReporte { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Estatus { get; set; }
        public string Razon { get; set; }
        public string Acciones { get; set; }
    }
}
