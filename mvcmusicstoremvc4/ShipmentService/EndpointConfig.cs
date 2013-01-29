namespace ShipmentService 
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .RavenSubscriptionStorage()
                .RavenPersistence();
        }
    }
}