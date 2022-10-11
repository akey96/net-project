namespace ConsoleApplication1 
{
    class Program
    {
        // si no tiene modificar de acceso, se asume que es private
        static void Main(string[] args)
        {
            var iteradorDeLista = new IteradorDeLista();
            iteradorDeLista.Lista = new List<int> {1, 2, 3};
            iteradorDeLista.EscribirLista();

            iteradorDeLista.Lista = null;
            Console.WriteLine(iteradorDeLista.Lista);
            iteradorDeLista.EscribirLista();
        }
        
    }

    class IteradorDeLista()
    {
        public IteradorDeLista()
        {
            _lista = new List<int>();
        }

        private List<int> _lista;

        public List<int> Lista
        {
            get
            {
                return _lista;
            }
            set
            {
                if(value != null)
                {
                    _lista = value;
                }
                else
                {
                    _lista = new List<int>();
                }
            }
        }

        public void EscribirLista() 
        {
            foreach(var item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
    
}