using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaffoldActividad.DAL.DTOs
{
    public class ConductoresDTO
    {
        public int Id { get; set; }
        public string identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public bool? Activo { get; set; }
        public int? MatriculaId { get; set; }
        public string NumeroMatricula { get; set; }
    }
}
