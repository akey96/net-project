namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> duplicar = x => {return x*10};
            Func<int, int, int> multiplicar = (x, y) => {return x*y};

            Console.WriteLine(duplicar(10));
            Console.WriteLine(multiplicar(2, 4));
        }
    }
}