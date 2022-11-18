using FluentValidation;
using ScaffoldActividad.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaffoldActividad.DAL.Utils
{
    public class ConductoresValidation : AbstractValidator<ConductoresDTO>
    {
        public ConductoresValidation()
        {
            RuleFor(a => a.identificacion).NotEmpty().WithMessage("Identificacion NO puede estar vacio");
            RuleFor(b => b.Telefono).Length(10).WithMessage("Numero Telefono debe tener Minimo 10 caracteres");
            RuleFor(c => c.Apellidos).NotEmpty().WithMessage("Apellido es Obligatorio");
            RuleFor(user => user.Nombre).NotEqual(user => user.Apellidos).WithMessage("Nombre y apellido no pueden ser iguales");
            RuleFor(customer => customer.Email).EmailAddress();
        }
    }
}
