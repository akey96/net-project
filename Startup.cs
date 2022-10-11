using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json.Serialization;
using WebAPIAutores.Services;

namespace WebAPIAutores
{
    public class Startup {

        public IConfiguration Configuration { get; }

        // Inyectamos IConfiguration, Interfaz que trae las variables de entorno
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services) {
           
            // Agregar controller y evitar llamadas ciclicas en las entidades, en caso de molestar
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            
            // Agregamos la instacion que manejara la DB
            services.AddDbContext<ApplicationDBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddTransient<IService, ServiceA>();

            // Inyeccion que es instaciada cada vez, no tiene escope, solo es viva por un instante
            services.AddTransient<ServiceTransient>();
            
            // Inyeccion de dependencia que es instaciada por cada peticicion, comparten scope dentro de una sola peticion 
            services.AddScoped<ServiceScoped>();

            // Inyeccion que es instanciada una unica vez y se comparte por toda la aplicacion
            services.AddSingleton<ServiceSingleton>();

            // Consfiguracion de servicio para cache
            services.AddResponseCaching();

            // service default  para authentication
            services.AddAuthentication(JwtBearerDefaults.authenticationScheme).AddJwtBearer();

            // configuracion necesario para Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
       
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger) {

            // app.UseMiddleware<LoguearRespuestaHTTPMiddleware>();
            app.UseLoguearRespuestaHTTP();

            app.Map("/ruta1", app =>
            {

                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Estoy interceptando la tuberia");
                });
            });


            // Configure the HTTP request pipeline(Middlware). 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Middleware para cache
            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();

            });

        }

    }
}