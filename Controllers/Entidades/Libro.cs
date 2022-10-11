using WebAPIAutores.Entidades;

namespace WebAPIAutores.Controllers.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        // llave foranea de Autor
        public int AutorId { get; set; }

        // Objeto que guarda referencia a la entidad Autor que pertenece el Libro
        public Autor Autor { get; set; }

    }
}
