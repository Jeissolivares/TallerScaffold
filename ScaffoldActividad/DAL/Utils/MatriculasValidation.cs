using FluentValidation;
using ScaffoldActividad.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaffoldActividad.DAL.Utils
{
    public class MatriculasValidation : AbstractValidator<MatriculasDTO>
    {
        public MatriculasValidation()
        {
            RuleFor(m => m.Numero).NotEmpty().WithMessage("Numero de Matricula Obligatorio");
        }
    }
}
