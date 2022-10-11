namespace ConsoleApplication1 
{
   class Program
   {

    static void Main(string[] args)
    {
        var miniViaje = new EnviarMiniMensaje();
        var enviarCorreo = new EnviarCorreo();
        Enviar(miniViaje, "Prueba");
        Enviar(enviarCorreo, "Prueba2");
        
        Console.Read();
    }

    public static void Enviar(IEnviarMensaje mensajero, string mensaje)
    {
        mensajero.EnviarMensaje(mensaje);
    }
   
   }

   interface IEnviadoMensaje
   {
    void EnviarMensaje(string mensaje);
   }

   class EnviarMiniMensaje: IEnviadoMensaje
   {
        public void EnviarMensaje(string mensaje)
        {
            Console.WriteLine("Enviando Minimensaje");
        }
   }

   class EnviarCorreo: IEnviadoMensaje
   {
        public void EnviarMensaje(string mensaje)
        {
            Console.WriteLine("Enviando Correo");
        }
   }

}