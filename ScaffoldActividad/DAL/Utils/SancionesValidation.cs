using FluentValidation;
using ScaffoldActividad.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaffoldActividad.DAL.Utils
{
    public class SancionesValidation : AbstractValidator<SancionesDTO>
    {
        public SancionesValidation()
        {
            RuleFor(s => s.Sancion).NotEmpty().WithMessage("Nombre Obligatorio");
            RuleFor(a => a.Observacion).Length(2, 50).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
        }
    }
}
