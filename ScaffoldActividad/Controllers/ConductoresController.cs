using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScaffoldActividad.DAL.DTOs;
using ScaffoldActividad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScaffoldActividad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {

        private readonly TransitoContext _context;

        public ConductoresController(TransitoContext context)
        {
            _context = context;
        }

        // GET: api/<ConductoresController>
        #region GetConductores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductoresDTO>>> Get()
        {
            var conductores = await _context.Conductores.Select(c =>
            new ConductoresDTO
            {
                Id = c.Id,
                identificacion = c.identificacion,
                Nombre= c.Nombre,
                Apellidos = c.Apellidos,
                Direccion = c.Direccion,
                Telefono = c.Telefono,
                Email = c.Email,
                Fecha_nacimiento = c.Fecha_nacimiento,
                Activo = c.Activo,
                MatriculaId = c.MatriculaId,
                NumeroMatricula = c.Matricula.Numero
            }).ToListAsync();

            if (conductores != null)
            {
                return conductores.OrderBy(m => m.Id).ToList();
            }
            else
            {
                return NotFound();
            }
        }
        #endregion GetConductores

        // GET api/<ConductoresController>/5
        #region GetConductoresXid
        [HttpGet("{id}")]
        public async Task<ActionResult<ConductoresDTO>> Get(int id)
        {
            try
            {
                var conductor = await _context.Conductores.Select(
                c => new ConductoresDTO
                {
                Id = c.Id,
                identificacion = c.identificacion,
                Nombre= c.Nombre,
                Apellidos = c.Apellidos,
                Direccion = c.Direccion,
                Telefono = c.Telefono,
                Email = c.Email,
                Fecha_nacimiento = c.Fecha_nacimiento,
                Activo = c.Activo,
                MatriculaId = c.MatriculaId,
                NumeroMatricula = c.Matricula.Numero
                }).FirstOrDefaultAsync();

                if (conductor != null)
                {
                    return conductor;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

        }
        #endregion GetConductoresXid

        // POST api/<ConductoresController>
        #region CrearConductor
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductoresDTO conductoresDTO)
        {
            var conductor = new Conductores()
            {
                Id = conductoresDTO.Id,
                identificacion = conductoresDTO.identificacion,
                Nombre = conductoresDTO.Nombre,
                Apellidos = conductoresDTO.Apellidos,
                Direccion = conductoresDTO.Direccion,
                Telefono = conductoresDTO.Telefono,
                Email = conductoresDTO.Email,
                Fecha_nacimiento = conductoresDTO.Fecha_nacimiento,
                Activo = conductoresDTO.Activo,
                MatriculaId = conductoresDTO.MatriculaId
            };
            try
            {
                _context.Conductores.Add(conductor);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                //return HttpStatusCode.BadRequest;
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion CrearConductor

        // PUT api/<ConductoresController>/5
        #region ActualizarConductor
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(ConductoresDTO conductoresDTO)
        {
            var conductor = await _context.Conductores.FirstOrDefaultAsync(c => c.Id == conductoresDTO.Id);

                conductor.identificacion = conductoresDTO.identificacion;
                conductor.Nombre = conductoresDTO.Nombre;
                conductor.Apellidos = conductoresDTO.Apellidos;
                conductor.Direccion = conductoresDTO.Direccion;
                conductor.Telefono = conductoresDTO.Telefono;
                conductor.Email = conductoresDTO.Email;
                conductor.Fecha_nacimiento = conductoresDTO.Fecha_nacimiento;
                conductor.Activo = conductoresDTO.Activo;
                conductor.MatriculaId = conductoresDTO.MatriculaId;

            try
            {
                _context.Entry(conductor).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion ActualizarConductor

        // DELETE api/<ConductoresController>/5
        #region EliminarConductor
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var conductor = await _context.Conductores.FindAsync(id);

                if (conductor != null)
                {
                    _context.Entry(conductor).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.OK;
                }
                else
                {
                    return HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion ElimnarConductor

    }
}
