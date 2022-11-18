using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaffoldActividad.DAL.DTOs
{
    public class MatriculasDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool? Activo { get; set; }

    }
}
