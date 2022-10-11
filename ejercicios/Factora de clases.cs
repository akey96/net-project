namespace ConsoleApplication1 
{
   class Program
   {

    static void Main(string[] args)
    {


        // Factory class
        var enviadorMensajeDependencia = FactoriaEnviadorMensaje.Factoria("sms");
        
        // inyeccion por constructor
        var enviadorMensaje = new EnviadorMensaje(enviadorMensajeDependencia);
        
        // Polimorfismo
        enviadorMensaje.EnviadorMensaje("Holas");
    }
   
   }

   public static class FactoriaEnviadorMensaje
   {
        public static IEnviadoMensaje Factoria(string tipoEnviadorMensaje)
        {
            if (tipoEnviadorMensaje == "sms")
            {
                return new EnviarMiniMensaje();
            } 
            else if (tipoEnviadorMensaje == "correo") 
            {
                return new EnviarCorreo();
            }
            throw new ApplicationException();
        }
   }


   public class EnviadorMensaje
   {
        // Inyeccion de dependencias por constructor
        private IEnviadoMensaje _enviadorMensaje;

        public EnviadorMensaje(IEnviadoMensaje enviadorMensaje)
        {
            _enviadorMensaje = enviadorMensaje;
        }

        public void EnviarMensaje(string mensaje)
        {
            _enviadorMensaje.EnviadorMensaje(mensaje);
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