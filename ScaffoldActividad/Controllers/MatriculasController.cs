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
    public class MatriculasController : ControllerBase
    {

        private readonly TransitoContext _context;

        public MatriculasController(TransitoContext context)
        {
            _context = context;
        }

        // GET: api/<MatriculasController>
        #region GetMatriculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculasDTO>>> Get()
        {
            var matriculas = await _context.Matriculas.Select(m =>
            new MatriculasDTO
            {
                Id = m.Id,
                Numero = m.Numero,
                FechaExpedicion = m.FechaExpedicion,
                ValidaHasta = m.ValidaHasta,
                Activo = m.Activo
            }).ToListAsync();

            if (matriculas != null)
            {
                return matriculas.OrderBy(m => m.Id).ToList();
            }
            else
            {
                return NotFound();
            }
        }
        #endregion GetMatriculas

        // GET api/<MatriculasController>/5
        #region GetMatriculasXid
        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculasDTO>> Get(int id)
        {
            try
            {
                var matricula = await _context.Matriculas.Select(
                m => new MatriculasDTO
                {
                    Id = m.Id,
                    Numero = m.Numero,
                    FechaExpedicion = m.FechaExpedicion,
                    ValidaHasta = m.ValidaHasta,
                    Activo = m.Activo
                }).FirstOrDefaultAsync();
                if (matricula != null)
                {
                    return matricula;
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
        #endregion GetMatriculasXid

        // POST api/<MatriculasController>
        #region CrearMatricula
        [HttpPost]
        public async Task<HttpStatusCode> Post(MatriculasDTO matriculasDTO)
        {
            var matricula = new Matriculas()
            {
                Id = matriculasDTO.Id,
                Numero = matriculasDTO.Numero,
                FechaExpedicion = matriculasDTO.FechaExpedicion,
                ValidaHasta = matriculasDTO.ValidaHasta,
                Activo = matriculasDTO.Activo
            };
            try
            {
                _context.Matriculas.Add(matricula);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                //return HttpStatusCode.BadRequest;
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion CrearMatricula

        // PUT api/<MatriculasController>/5
        #region ActualizarMatricula
        [HttpPut("{Numero}")]
        public async Task<HttpStatusCode> Put(MatriculasDTO matriculasDTO)
        {
            var matricula = await _context.Matriculas.FirstOrDefaultAsync(m => m.Numero == matriculasDTO.Numero);

            matricula.Numero = matriculasDTO.Numero;
            matricula.FechaExpedicion = matriculasDTO.FechaExpedicion;
            matricula.ValidaHasta = matriculasDTO.ValidaHasta;
            matricula.Activo = matriculasDTO.Activo;

            try
            {
                _context.Entry(matricula).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion ActualizarMatricula

        // DELETE api/<MatriculasController>/5
        #region EliminarMatricula
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var matricula = await _context.Matriculas.FindAsync(id);

                if (matricula != null)
                {
                    _context.Entry(matricula).State = EntityState.Deleted;
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
        #endregion ElimnarMatricula
    }
}
