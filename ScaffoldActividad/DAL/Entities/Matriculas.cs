using System;
using System.Collections.Generic;

namespace ScaffoldActividad.Entities
{
    public partial class Matriculas
    {
        public Matriculas()
        {
            Conductores = new HashSet<Conductores>();
        }

        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Conductores> Conductores { get; set; }
    }
}
