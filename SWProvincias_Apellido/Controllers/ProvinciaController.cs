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
    public class ProvinciaController : ControllerBase
    {
        private readonly DBPaisFinalContext context;

        public ProvinciaController(DBPaisFinalContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();
        }

        [HttpGet("{ID}")]
        public ActionResult<Provincia> GetById(int ID)
        {
            Provincia provincia = (from prov in context.Provincias
                               where prov.IdProvincia == ID
                               select prov).SingleOrDefault();
            return provincia;
        }
        [HttpPost]

        public ActionResult<Provincia> Post(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Provincias.Add(provincia);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{ID}")]
        public ActionResult<Provincia> Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }
            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{ID}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provinciaABorrar = (from c in context.Provincias
                                   where c.IdProvincia == id
                                   select c).SingleOrDefault();

            if (provinciaABorrar == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provinciaABorrar);
            context.SaveChanges();
            return provinciaABorrar;

        }

    }
}
