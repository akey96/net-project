namespace WebAPIAutores.Services
{
    public interface IService
    {
        Guid obtenerScoped();
        Guid obtenerSingleton();
        Guid obtenerTransient();
        void RealizarTarea();
    }

    public class ServiceA : IService
    {

        /*
         * Critical
         * Error
         * Warning
         * Information
         * Debug
         * Trace
         */

        private readonly ILogger<ServiceA> logger;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ServiceTransient serviceTransient;

        public ServiceA(
            ILogger<ServiceA> logger,
            ServiceScoped serviceScoped,
            ServiceSingleton serviceSingleton,
            ServiceTransient serviceTransient)
        {
            this.logger = logger;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.serviceTransient = serviceTransient;
        }

        public Guid obtenerTransient() {  return serviceTransient.Guid; }
        public Guid obtenerSingleton() { return serviceSingleton.Guid; }
        public Guid obtenerScoped() {  return serviceScoped.Guid; }


        public void RealizarTarea()
        {

        }

    }

    public class ServiceB : IService
    {
        public Guid obtenerScoped()
        {
            throw new NotImplementedException();
        }

        public Guid obtenerSingleton()
        {
            throw new NotImplementedException();
        }

        public Guid obtenerTransient()
        {
            throw new NotImplementedException();
        }

        public void RealizarTarea()
        {

        }

    }

    public class ServiceTransient
    {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServiceScoped
    {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServiceSingleton
    {
        public Guid Guid = Guid.NewGuid();
    }

}
