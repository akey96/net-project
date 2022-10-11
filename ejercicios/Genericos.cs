using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Genericos
{
    class Program
    {
        static void Main(string[] args)
        {
            var persona1 = new Persona() { Nombre = "Felipe"};
            var Xml_persona1 = Serializar<Persona>(persona1);

            var empresa = new Empresa() { Direccion = "Av. Lejos"};
            var Xml_persona1 = Serializar<Empresa>(empresa);
             
        }

        private static string Serializar<T>(T valor)
        {
            var serializador = new XmlSerializer(typeof(T));

            using (var escritorString = new StringWriter())
            {
                using (var escritor = XmlWriter.Create(escritorString))
                {
                    serializador.Serialize(escritor, valor);
                    return escritorString.ToString();
                }
            }
        }
    }
}