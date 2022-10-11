

// Propiedades 

// public string Nombre { get; set;}
// public string Nombre { get; private set;}
// public int Dimension { get {return _compotentes.Count}}

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args )
        {
            var v1 = new Vector(new List<int> {3, 4, 5});
            var v2 = new Vector(new List<int> {1, 2, -9});
            Vector vectorSuma = v1.suma(v2);
            Vector vectorSuma2 = v1 + v2;
            v1++;

        }
    }
    // clases : Variables por referencia
    // struc ; variables por valor
    // class Vector
    struct Vector
    {
        //Campo
        private List<int> _componentes;

        // Propiedades
        private List<int> Componentes
        {
            get 
            {
                return _componentes;
            }
        }

        public int Dimension {get {return _componentes.Count; }}

        // indexador
        public int this[int i]
        {
            get {return _componentes[i];}
            set { _componentes[i] = value;}
        }

        // Constructor
        public Vector(List<int> componentes)
        {
            _componentes = componentes;
        }

        public Vector Suma (Vector v2) {
            if (Dimension != v2.Dimension)
            {
                throw new ApplicationException("Las dimenciones no son iguales");
            }

            List<int> resultado = new List<int>();
            for(int i=0; i<Dimension; i++)
            {
                resultado.Add(this[i] + v2[i]);
            }

            return new Vector(resultado);
        }
        
        // suma de operadores
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return vector1.Suma(vector2);
        }

        public static Vector operator ++(Vector vector1)
        {
            throw new NotImplementedException();
        }
    }


}


