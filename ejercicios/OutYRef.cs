namespace
{

    class Persona
    {
        public string Nombre {get; set;}
        public int Edad {get; set;}
        
        public Persona(string Nombre, int Edad)
        {
            this.Nombre = Nombre;
            this.Edad = Edad;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Persona("Luis", 23);
            int edad = 24;

            EditarPersona(p, "Pedro");

            // Permite pasar paso de parametro por valor como parametros por referencia
            EditarEdad(ref edad, 25)

            // Lo mismo que ref, pero te lanza una excepcion si en el metodo no se llega a modificar
            EditarEdad2(out edad, 25)
            
        }

        static void EditarPersona(Persona persona, string nuevoValor)
        {
            persona.nombre = nuevoValor;
        }

        static void EditarEdad(ref int edadActual, int nuevaEdad)
        {
            edadActual = nuevaEdad;
        }

        static void EditarEdad2(out int edadActual, int nuevaEdad)
        {
            edadActual = nuevaEdad;
        }
    }
}