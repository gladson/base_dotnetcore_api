using Microsoft.EntityFrameworkCore;
using DogApi.Models;

namespace DogApi.Context
{
    public class DogApiContext : DbContext 
    {
        public DogApiContext(DbContextOptions<DogApiContext> options) : base(options) {
            //Dog Context
        }
        public DbSet<Dog> Dogs { get; set; }
    }
}