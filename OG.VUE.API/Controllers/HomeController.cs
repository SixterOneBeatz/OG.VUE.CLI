using OG.VUE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OG.VUE.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        // GET: api/Home
        public List<Persona> Get()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                using (DB db = new DB())
                {
                    personas = db.Persona.ToList();
                }
            }
            catch (Exception ex)
            {
                personas = new List<Persona>();
            }
            return personas;
        }

        // GET: api/Home/5
        public Persona Get(int id)
        {
            return new Persona() { Id = 1, Nombre = "Ronaldo" };
        }

        // POST: api/Home
        public void Post([FromBody]Persona value)
        {
            Persona persona = new Persona();
            try
            {
                using (DB db = new DB())
                {
                    value.FechaN = DateTime.Now;
                    db.Persona.Add(value);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                persona = new Persona();
            }
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]Persona value)
        {
            Persona persona = new Persona();
            try
            {
                using (DB db = new DB())
                {
                    persona = db.Persona.Find(id);
                    if (persona != null)
                    {
                        persona.Nombre = value.Nombre;
                        persona.Edad = value.Edad;
                        db.SaveChanges();
                    }
                    else
                    {
                        persona = new Persona();
                    }
                }
            }
            catch (Exception ex)
            {
                persona = new Persona();
            }            
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
            Persona persona = new Persona();
            try
            {
                using (DB db = new DB())
                {
                    persona = db.Persona.Find(id);
                    if (persona != null)
                    {
                        db.Persona.Remove(persona);
                        db.SaveChanges();
                    }
                    else
                    {
                        persona = new Persona();
                    }
                }
            }
            catch (Exception ex)
            {
                persona = new Persona();
            }
        }
    }
}
