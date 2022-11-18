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
    public class SancionesController : ControllerBase
    {

        private readonly TransitoContext _context;

        public SancionesController(TransitoContext context)
        {
            _context = context;
        }

        // GET: api/<SancionesController>
        #region GetSanciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            var sanciones = await _context.Sanciones.Select(s =>
            new SancionesDTO
            {
                Id = s.Id,
                FechaActual = s.FechaActual,
                Sancion = s.Sancion,
                Observacion = s.Observacion,
                Valor = s.Valor,
                ConductoresId = s.ConductoresId,
                Conductor = s.Conductores.Nombre + " " + s.Conductores.Apellidos

            }).ToListAsync();

            if (sanciones != null)
            {
                return sanciones.OrderBy(m => m.Id).ToList();
            }
            else
            {
                return NotFound();
            }
        }
        #endregion GetSanciones

        // GET api/<SancionesController>/5
        #region GetSancionesid
        [HttpGet("{id}")]
        public async Task<ActionResult<SancionesDTO>> Get(int id)
        {
            try
            {
                var sancion = await _context.Sanciones.Select(
                s => new SancionesDTO
                {
                    Id = s.Id,
                    FechaActual = s.FechaActual,
                    Sancion = s.Sancion,
                    Observacion = s.Observacion,
                    Valor = s.Valor,
                    ConductoresId = s.ConductoresId,
                    Conductor = s.Conductores.Nombre + " " + s.Conductores.Apellidos
                }).FirstOrDefaultAsync();

                if (sancion != null)
                {
                    return sancion;
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
        #endregion GetSancionesXid

        // POST api/<SancionesController>
        #region CrearSancion
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTO sancionesDTO)
        {
            var sancion = new Sanciones()
            {
                Id = sancionesDTO.Id,
                FechaActual = sancionesDTO.FechaActual,
                Sancion = sancionesDTO.Sancion,
                Observacion = sancionesDTO.Observacion,
                Valor = sancionesDTO.Valor,
                ConductoresId = sancionesDTO.ConductoresId
            };
            try
            {
                _context.Sanciones.Add(sancion);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                //return HttpStatusCode.BadRequest;
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion CrearSancion

        // PUT api/<SancionesController>/5
        #region ActualizarConductor
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sancionesDTO)
        {
            var sancion = await _context.Sanciones.FirstOrDefaultAsync(s => s.Id == sancionesDTO.Id);

                sancion.Id = sancionesDTO.Id;
                sancion.FechaActual = sancionesDTO.FechaActual;
                sancion.Sancion = sancionesDTO.Sancion;
                sancion.Observacion = sancionesDTO.Observacion;
                sancion.Valor = sancionesDTO.Valor;
                sancion.ConductoresId = sancionesDTO.ConductoresId;

            try
            {
                _context.Entry(sancion).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion ActualizarConductor

        // DELETE api/<SancionesController>/5
        #region EliminarConductor
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var sancion = await _context.Sanciones.FindAsync(id);

                if (sancion != null)
                {
                    _context.Entry(sancion).State = EntityState.Deleted;
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
