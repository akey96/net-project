using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Controllers.Entidades;
using WebAPIAutores.Entidades;

namespace WebAPIAutores
{
    // Clase que maneja la conexion a la DB
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
         
        // DbSet, tipo de dato que permite setear una entidad
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }


    }
};
