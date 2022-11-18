using System;
using System.Collections.Generic;

namespace ScaffoldActividad.Entities
{
    public partial class Sanciones
    {
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string Sancion { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }
        public int ConductoresId { get; set; }

        public virtual Conductores Conductores { get; set; }
    }
}
