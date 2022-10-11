using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Entidades;
using WebAPIAutores.Services;

namespace WebAPIAutores.Controllers {

    [ApiController]
    // [Authorize]
    [Route("api/autores")]
    public class AutoresController: ControllerBase {
        private readonly ApplicationDBContext context;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ServiceScoped serviceScoped;
        private readonly IService serviceA;
        private readonly ILogger<AutoresController> logger;

        public AutoresController(
            ApplicationDBContext context,
            ServiceTransient serviceTransient,
            ServiceSingleton serviceSingleton,
            ServiceScoped serviceScoped,
            IService serviceA,
            ILogger<AutoresController>  logger)
        {
            this.context = context;
            this.serviceTransient = serviceTransient;
            this.serviceSingleton = serviceSingleton;
            this.serviceScoped = serviceScoped;
            this.serviceA = serviceA;
            this.logger = logger;
        }

        [HttpGet("GUID")]
        [ResponseCache(Duration = 10)]
        [Authorize]     //Filtroa nivel de metodo
        public IActionResult ObtenerGuids()
        {
            return Ok(new {
                AutoresController_Transient = serviceTransient.Guid,
                ServiceA_transient = serviceA.obtenerTransient(),
                AutoresController_Scoped = serviceScoped.Guid,
                ServiceA_Scoped = serviceA.obtenerScoped(),
                AutoresController_Singleton = serviceSingleton.Guid,
                ServiceA_Singleton = serviceA.obtenerSingleton()
            });
        }

        [HttpGet]   // api/autores
        [HttpGet("/listado")]   //  /listado
        public async Task<ActionResult<List<Autor>>> Get()
        {
            logger.LogInformation("Estamos obteniendo los usuarios");
            // Include, incluye la referencia a los libros del autor, ToListAsync ya que estamos usando progrmacion asyncrona
            return await context.Autores.Include(x => x.Libros).ToListAsync();
        }


        [HttpGet("primero")]    //  api/autores/primero
        public async Task<ActionResult<Autor>> PrimerAutor()
        {
            // Retorna El primer autor o coincidencia
            return await context.Autores.Include(x => x.Libros).FirstOrDefaultAsync();
        }

        [HttpGet("{id:int}")]   //  api/autores/{id}
        public async Task<ActionResult<Autor>> Get(int id)
        {
            // Autor con id especifico
            var autor =  await context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpGet("{nombre}/{edad?}")]   //  api/autores/{nombre}/{edad}  , donde edad es opcional
        //[HttpGet("{nombre}/{edad=18}")]   //  api/autores/{nombre}/{edad}  , donde edad toma el valor por defecto de 18
        public async Task<ActionResult<Autor>> Get(string nombre, string edad)
        {
            var autor = await context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Post( Autor autor)
        {

            // validacion desde el controlador
            var existeAutorConElMismoNombre = await context.Autores.AnyAsync(x => x.Nombre == autor.Nombre);
            if (existeAutorConElMismoNombre)
            {
                return BadRequest($"Ya existe un autor con el nombre {autor.Nombre}");
            }

            // Console.WriteLine(autor);
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put( Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            }

            // retorna si existe un autor con id especifico
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Autor {Id = id});
            await context.SaveChangesAsync();
            return Ok();

        }
    }

} 