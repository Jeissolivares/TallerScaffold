using System;
using System.Collections.Generic;

namespace ScaffoldActividad.Entities
{
    public partial class Conductores
    {
        public Conductores()
        {
            Sanciones = new HashSet<Sanciones>();
        }

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

        public virtual Matriculas Matricula { get; set; }
        public virtual ICollection<Sanciones> Sanciones { get; set; }
    }
}
