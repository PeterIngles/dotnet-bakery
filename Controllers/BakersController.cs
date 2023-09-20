using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        // _context is an instance of the ApplicationContext claass
        // We use _context to query our database!
        // This of it as being kinda like pool.query...but just kinda
        private readonly ApplicationContext _context;

        //  This is a constructor function.
        // The ApplicationContext is automatically passed to it
        // as an argument by .NET
        public BakersController(ApplicationContext context)
        {
            _context = context;
        }
        // NOW LETS MAKE SOME ROUTES
        // GET /api/bakers
        [HttpGet]
        public IEnumerable<Baker> GetAll()
        {
            // Look ma, no SQL queries!
            return _context.Bakers;
        }
        // GET /api/bakers/:id
        [HttpGet("{id}")]
        public ActionResult<Baker> GetById(int id)
        {
            Baker bakerWeDesire = _context.Bakers
            .SingleOrDefault(baker => baker.id == id);

            if (bakerWeDesire is null)
            {
                return NotFound();
            }
            return bakerWeDesire;
        }

        [HttpPost]
        public Baker CreateBaker(Baker newBaker)
        {
            // Two Step process
            // 1. We try to create a baker instance, using the data
            // that got sent in the POST request.

            _context.Add(newBaker);
            // 2. If step 1 works, then we "save the new baker in our
            // Bakers table
            _context.SaveChanges();

            return newBaker;
        }
    }
}
