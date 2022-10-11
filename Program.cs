using WebAPIAutores;

// Instancia para contruir la aplicacion
var builder = WebApplication.CreateBuilder(args);

// Clase que lanza la aplicacion con la instancia de la aplicacion
var startup = new Startup(builder.Configuration);
   
// Seteamos las configuraciones de la clase a contruir
startup.ConfigureServices(builder.Services);

// Contruimos nuestra aplicacion
var app = builder.Build();


//
var servicioLogger = (ILogger<Startup>)app.Services.GetService(typeof(ILogger<Startup>));

// Configuracmos la clase que lanzara nuestra aplicacion con sus variables de entorno
startup.Configure(app, app.Environment, servicioLogger);

// ejecutamos la aplicaciones
app.Run();
