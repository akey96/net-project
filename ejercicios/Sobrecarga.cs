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
        
        // paso de referencia de muchos parametros
        private static double CalcularPromedio(params int[] numeros)
        {
            double suma = 0.0;
            foreach (var numero  in numeros)
            {
                suma = suma + numero;
            }

            return suma / numeros.Lenght;
        }
        
        // sobrecarga del metodo
        private static double CalcularPromedio(params double[] numeros)
        {
            double suma = 0.0;
            foreach (var numero  in numeros)
            {
                suma = suma + numero;
            }

            return suma / numeros.Lenght;
        }
    }
}