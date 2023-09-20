using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/bread")]
    public class BreadsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BreadsController(ApplicationContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Bread> GetAll()
        {
            return _context.Breads
            .Include(bread => bread.bakedBy);
            // .Include is doing a JOIN for us. It's using the bakedById to 
            // attach the associated as the value of the baked by attribute
        }

        [HttpGet("{id}")]
        public ActionResult<Bread> GetById(int id)
        {
            Bread breadWeWant = _context.Breads
            .SingleOrDefault(bread => bread.id == id);

            if (breadWeWant is null)
            {
                return NotFound();
            }
            return breadWeWant;

        }

          // POST /api/breads
    // .NET automatically converts our JSON request body
    // into a `Bread` object. 
    [HttpPost]
    public Bread Post(Bread bread) 
    {
        // Tell the DB context about our new bread object
        _context.Add(bread);
        // ...and save the bread object to the database
        _context.SaveChanges();

        // Respond back with the created bread object
        return bread;
    }

     // PUT /api/breads/:id
    // Updates a bread by id
    [HttpPut("{id}")]
    public Bread Put(int id, Bread bread) 
    {
        // Our DB context needs to know the id of the bread to update
        bread.id = id;

        // Tell the DB context about our updated bread object
        _context.Update(bread);

        // ...and save the bread object to the database
        _context.SaveChanges();

        // Respond back with the created bread object
        return bread;
    }

     // DELETE /api/breads/:id
    [HttpDelete("{id}")]
    public void Delete(int id) 
    {
        // Find the bread, by ID
        Bread bread = _context.Breads.Find(id);

        // Tell the DB that we want to remove this bread
        _context.Breads.Remove(bread);

        // ...and save the changes to the database
        _context.SaveChanges();;
    }

    }
}
