using System;

using Exchange.Entity;
using Exchange.Service;

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

            builder.RegisterType<ExchangeService>().As<IExchangeService>();

            var container = builder.Build();
            var service = container.Resolve<IExchangeService>();
            var exchangeRates = container.Resolve<IExchangeRates>();
            var factory = container.Resolve<IExchangeEntityFactory>();

            var eur = factory.CreateCurrency("Euro", "EUR");
            var usd = factory.CreateCurrency("Amerikanske dollar", "USD");
            var gbp = factory.CreateCurrency("Britiske pund", "GBP");
            var sek = factory.CreateCurrency("Svenske kroner", "SEK");
            var nok = factory.CreateCurrency("Norske kroner", "NOK");
            var chf = factory.CreateCurrency("Schweiziske franc", "CHF");
            var jpy = factory.CreateCurrency("Japanske yen", "JPY");
            var dkk = factory.CreateCurrency("Danske kroner", "DKK");
            Console.WriteLine(service.CalculateMoneyCurrencyAmount(exchangeRates, factory.CreateExchangePair(eur, dkk, 1.0m)));
            Console.WriteLine(service.CalculateMoneyCurrencyAmount(exchangeRates, factory.CreateExchangePair(dkk, usd, 6.63m)));
            Console.WriteLine(service.CalculateMoneyCurrencyAmount(exchangeRates, factory.CreateExchangePair(eur, usd, 1.0m)));
            Console.WriteLine(service.CalculateMoneyCurrencyAmount(exchangeRates, factory.CreateExchangePair(eur, eur, 104.0m)));
        }
    }
}
