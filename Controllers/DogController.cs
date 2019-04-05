using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DogApi.Context;
using DogApi.Models;

namespace LotusERPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogApiContext _context;          
        public DogController(DogApiContext context)         
        {             
            _context = context; 
        } 

        // GET api/dog
        // [HttpGet]
        // public IEnumerable<Dog> GetAll()
        // {
        //     System.Console.WriteLine("HTTP Get all!");
        //     return _context.Dogs.ToList();
        // }

        [HttpGet(Name="GetDogAll")] 
        public ActionResult<List<Dog>> GetAll() 
        {     
            return _context.Dogs.ToList(); 
        } 

        [HttpGet("{Id}", Name="GetDogId")]
        public IActionResult GetById(long id)
        {
            System.Console.WriteLine("HTTP GetBy Id!");

            var item = _context.Dogs.FirstOrDefault(t => t.Id == id);
            if(item==null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Dog item)
        {
            System.Console.WriteLine($"HTTP Post(add) Dog {item.Nome}!");

            if (item==null)
            {
                return BadRequest();
            }
            _context.Dogs.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetDogId", new { id = item.Id }, item);
        }
                 
    }
}