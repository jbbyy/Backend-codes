
using Consul;

namespace LayeredAppDemo
{
    public static class ServiceRegistryExtension
    {
        // Creating middleware for registering service on Consul
        // Name of the middle ware is UseConsul
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configurationSetting)
        {
            //static method IApplicationBuilder , passing 2 parameters
            //first parameter with (this) keyword -> extension method : trying to add new features in existing class. First parameter MUST start with this keyword 
            //UseConsul will get added into IApplicationBuilder via extension method. 

            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            //implements communication with a Consul server

            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtension");
            //This instance can be used to log messages throughout the application. Diagnostic 

            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            //interface provides notifications for the start and stop events of the host application's lifetime.



            // This is registration configuration that I am reading from appsettings.json file
            var registration = new AgentServiceRegistration()
            {
                ID = configurationSetting["ConsulConfig:ServiceName"],
                Name = configurationSetting["ConsulConfig:ServiceName"],
                Address = configurationSetting["ConsulConfig:ServiceHost"],
                Port = int.Parse(configurationSetting["ConsulConfig:ServicePort"])
            };

            logger.LogInformation("Registering with consul");
            //Here I am registering the service with service ID
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            //unable to register with same ID hence we deregister first and then register just incase 
            //user is already registered before
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifetime.ApplicationStopped.Register(() =>
            {
                logger.LogInformation("Unregistering service from consul");
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(!true);
            });
            return app;
        }


    }
}