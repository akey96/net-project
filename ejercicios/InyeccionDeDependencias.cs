namespace ConsoleApplication1 
{
   class Program
   {

    static void Main(string[] args)
    {
        var enviarCorreo = new EnviarCorreo();
        
        // inyeccion por constructor
        var enviadorMensaje = new EnviadorMensaje(enviarCorreo);
        enviadorMensaje.EnviadorMensaje("Holas");

        // inyeccion por atributo
        var enviadorMensaje = new EnviadorMensaje();
        enviadorMensaje.ImplementacionEnviadorMensaje = enviarCorreo;
        enviadorMensaje.EnviadorMensaje("Holas");
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

        // Inyeccion de dependencias por atributo

        public IEnviadoMensaje ImplementacionEnviadorMensaje 
        {
            get { return _enviadorMensaje;}
            set { _enviadorMensaje = value;}
        }

        public EnviadorMensaje()
        {
            _enviadorMensaje = new EnviarCorreo();
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