namespace ConsoleApplication1 
{
    /*
    * public: Todos tienen  permiso de uso
    * private: Es visible dentro del mismo tipo(class o struc) se puede utilizar
    * protected: Solo desde tipos derivados
    * internal: Solamente se puede utilizar desde el mismo proyecto
    */

    class Program
    {
        static void Main(string[] args)
        {
            Animal perro = new Perro();
            Animal gato = new Gato();
            Animal pelicano = new Pelicano();
            Animal gusano = new Gusano();

            AnimalHacerRuido(perro);
            AnimalHacerRuido(gato);
            AnimalHacerRuido(pelicano);
            AnimalHacerRuido(gusano);

            Console.Read();
        }   

        // Polimorfismo
        public static void AnimalHacerRuido(Animal animal) 
        {
            animal.HacerRuido();
        }
    }

    abstract class Animal
    {
        public virtual void HacerRuido()
        {
            Console.WriteLine("Ruido Generico");
        }
    }

    class Perro: Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("Woof");
        }
    }


    class Gato: Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("Meeow");
        }
    }

    class Pelicano: Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("tuki tuki");
        }
    }

    class Gusano: Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("Soy un gusano");
        }
    }


}