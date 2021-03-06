﻿using System;

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
            builder.RegisterType<ExchangeArgumentParserService>().As<IExchangeArgumentParserService>();

            var container = builder.Build();
            var service = container.Resolve<IExchangeService>();
            var argumentParser = container.Resolve<IExchangeArgumentParserService>();

            try
            {
                var exchangePair = argumentParser.ArgumentsToExchangePair(args);
                Console.WriteLine(service.CalculateMoneyCurrencyAmount(exchangePair));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
