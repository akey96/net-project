namespace ConsoleApplication1 
{
   class Program
   {

    static void Main(string[] args)
    {
        // Tipos de datos anonimos
        var animalito1 = new { animal = "perro", nombre = "Roberto", vidas = 1};
        var animalito2 = new { animal = "gato", nombre = "Lulu", vidas = 7};
        
        // dynamic es permite definir un tipo generico, ideal para tipòs anonimos
        List<dynamic> animalitos = new List<dynamic>();

        animalitos.Add(animalito1);
        animalitos.Add(animalito2);

        foreach(dynamic animalito in animalitos)
        {
            Console.WriteLine("El {0} de nombre {1} tiene {2} vidas", animalito.animal, animalito.nombre, animalito.vidas);
        }
        Console.Read();
    }
   
   }

   class Persona
   {
        public string Nombre {get; set;}
        public string Edad {get; set;}
        
   }

   
}