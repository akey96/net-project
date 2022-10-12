namespace Genericos
{


    class Program
    {
        static void Main(string[] args)
        {
            Generico_struct<int>(5);
            Generico_class<Perro>();
            Generico_Herencia<Gato>(new Gato());
        }

        static void Generico_struct<T>(T valor) where T: struct
        {

        }

        static M Generico_class<M>() where M: class, new()
        {
            return new M();
        }

        static void Generico_interface<M>(T implementacion) where T: IEnumerable<T>
        {
            foreach (T item in implementacion)
            {
                
            }
        }

        static C Generico_constructor<C>() where C: new()
        {
            return new C();
        }

        static void Generico_Herencia<A>(A animal) where A: Animal
        {
            animal.HacerRuido();
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

    sealed class Gusano: Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("Soy un gusano");
        }
    }

}