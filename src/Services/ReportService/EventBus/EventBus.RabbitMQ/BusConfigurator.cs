using MassTransit;
using MassTransit.RabbitMqTransport;

namespace EventBus.RabbitMQ
{
    public class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host(RabbitMqConstants.RabbitMqUri, configurator =>
                {
                    configurator.Username(RabbitMqConstants.Username);
                    configurator.Password(RabbitMqConstants.Password);
                });

                registrationAction?.Invoke(factory);
            });

        }
    }
}
