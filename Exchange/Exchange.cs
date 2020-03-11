using System;

using Exchange.Entity;

using Autofac;

namespace Exchange
{
    class Exchange
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Currency>().As<ICurrency>();
            builder.RegisterType<ExchangePair>().As<IExchangePair>();
            builder.RegisterType<ExchangeRates>().As<IExchangeRates>();
            builder.RegisterType<ExchangeEntityFactory>().As<IExchangeEntityFactory>();

            foreach (var item in builder.Build().Resolve<IExchangeRates>().Rates)
            {
                Console.WriteLine("{0} {1}", item.Key.Iso, item.Value);
            }
        }
    }
}
