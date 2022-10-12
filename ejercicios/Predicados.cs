namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<Persona> predicado = EsMayorDeEdad;
            var p = new Persona()
            {
                Nombre = "Claudia",
                Edad = 30
            };

            Console.WriteLine(predicado(p));  

        }


        static bool EsMayorDeEdad(Persona persona)
        {
            return persona.Edad >= 18;
        }
        
    }

    class Persona
    {
        public string Nombre {get; set;}
        public string Edad {get; set;}
        
    }
}