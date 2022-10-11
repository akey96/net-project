namespace ConsoleApplication1 
{
    class Program
    {
        // si no tiene modificar de acceso, se asume que es private
        static void Main(string[] args)
        {
            Console.WriteLine(5.ElevadoALa(3));
            Console.WriteLine(7.Doble());
        }
        
    }

    // Una clase estatica no puede ser instanceada
    public static class IntegerExtensionMethods
    {
        public static double ElevadoALa(this int valor, int exponente)
        {
            return Math.Pow(valor, exponente);
        }

        public static double Doble(this int valor)
        {
            return valor * 2;
        }
    }
    
}