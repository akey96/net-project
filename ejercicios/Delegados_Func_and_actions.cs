namespace
{
    class Program
    {
        // declaracion del delgado
        public delegate string DeEnteroAString(int valor);

        static void Main(string[] args)
        {
            // Instanciacion del delegado
            var deEnteroAString = new  DeEnteroAString(FuncionRetornaToString);
            var deEnteroAStringMasUno = new  DeEnteroAString(FuncionRetornaToStringMasUno);
    
            Console.WriteLine(deEnteroAString(20));
            Console.WriteLine(deEnteroAStringMasUno(20));
            
            Func<int, string> delegadoFunc = FuncionRetornaToStringMasUno;
            var resultado = delegadoFunc(10);

            Action<int> delegadoAction = Ejemplo;

            delegadoAction(12);  


        }

        public static string FuncionRetornaToString(int valor)
        {
            return valor.ToString();
        }

        public static string FuncionRetornaToStringMasUno(int valor)
        {
            return (valor + 1).ToString();
        }

        public static void Ejemplo(int a)
        {

        }

    }
}