namespace ConsoleApplication1 
{
    class Program
    {
        public void Main(string[] args)
        {
            double numero1 = 5;
            double numero2 = 7;
            double numero3 = 10;
            double promedio = CalcularPromedio(1,2 ,3 ,5,3, 23,45,3);
        
        }
        
        private static void metodo(string v1)
        {
            metodo(v1, "valor3"); 
        }

        private static void metodo(string v1, string v2 = "valor3")
        {
            Console.WriteLine(v1);
            Console.WriteLine(v2);
        }

    }
}