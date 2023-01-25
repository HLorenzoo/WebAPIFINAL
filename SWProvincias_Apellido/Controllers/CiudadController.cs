using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Apellido.Data;
using SWProvincias_Apellido.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Apellido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly DBPaisFinalContext context;

        public CiudadController(DBPaisFinalContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();
        }

        [HttpGet("{ID}")]
        public ActionResult<Ciudad> GetById(int ID)
        {
            Ciudad ciudad = (from ciu in context.Ciudades
                                   where ciu.IdCiudad == ID
                                   select ciu).SingleOrDefault();
            return ciudad;
        }
        [HttpPost]

        public ActionResult<Ciudad> Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{ID}")]
        public ActionResult<Ciudad> Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }
            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudadABorrar = (from c in context.Ciudades
                                    where c.IdCiudad == id
                                    select c).SingleOrDefault();

            if (ciudadABorrar == null)
            {
                return NotFound();
            }
            context.Ciudades.Remove(ciudadABorrar);
            context.SaveChanges();
            return ciudadABorrar;

        }
    }
}
