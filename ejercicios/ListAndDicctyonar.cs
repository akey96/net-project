namespace Colecciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> NombreEdad = new Dictionary<string, int>();
            NombreEdad.Add("Felipe", 40)

            if (NombreEdad.ContainsKey("Felipe"))
            {
                NombreEdad.Remove("Felipe");
            }

            foreach (var key in NombreEdad.Keys)
            {   
                Console.WriteLine(key);
            }
            //////////////////////////////////////////////////////////
            Queue<string> queue = new Queue<string>();

            queue.Add("Primero");
            queue.Add("Segundo");
            queue.Add("Tercero");
            
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            var primerElemento = queue.Dequeue();
            Console.WriteLine(primerElemento);
            ////////////////////////////////////////////////////////////////
            Stack<string> stack = new Stack<string>();
            stack.Push("A");
            var elementoAriba = stack.Pop(9);

            /////////////////////////////////////////////////////////////
            string[] arregloDeString = new string[] { "Felipe", "C#", "Javascript"};

            // redimencionar
            Array.Resize<string>(ref arregloDeString,  6);

            /////////////////////////////////////////////////////////////
            int[,] matriz = new int[2, 2];
            matriz[1, 0] = 1;
            
        }
    }
}
