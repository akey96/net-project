namespace Genericos
{
    class Program
    {
        static void Main(string[] args)
        {
            var miDobleCollection =  FactoriaMiDobleCollection<string, int>(1);
            miDobleCollection.Agregar("Felipe", 7);
        }

        static IMiDobleCollection<T, M> FactoriaMiDobleCollection<T, M>(int discrimiante)
        {
            if(discrimiante == 1)
            {
                return new MiDobleCollection<T, M>();
            } 
            else if(discrimiante == 2)
            {
                return new MiDobleCollectionDiccionario<T, M>();
            }

            throw new NotImplementedException();
        }
    }

    interface IMiDobleCollection<T, M>
    {
        void Agregar(T valorT, M valorM);
    }

    class MiDobleCollection<T, M>: IMiDobleCollection
    {
        public List<T> MiListaDeT {get; set;}
        public List<M> MiListaDeM {get; set;}
        
        public MiDobleCollection()
        {
            MiListaDeT = new List<T>();
            MiListaDeM = new List<M>();
        }

        public void Agregar(T valorT, M valorM)
        {
            MiListaDeT.Add(valorT);
            MiListaDeM.Add(valorM);
        }
    }


    class MiDobleCollectionDiccionario<T, M>: IMiDobleCollection
    {
        public Dictionary<T, M> Diccionario {get; set;}
        
        public void Agregar(T valorT, M valorM)
        {
            
        }
    }
}