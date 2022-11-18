using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaffoldActividad.DAL.DTOs
{
    public class SancionesDTO
    {
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string Sancion { get; set; }
        public string Observacion { get; set; }
        public decimal Valor { get; set; }
        public int ConductoresId { get; set; }

        public string Conductor { get; set; }

    }
}
