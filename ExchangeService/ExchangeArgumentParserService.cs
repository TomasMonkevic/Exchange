using Exchange.Entity;
using System;
using System.Globalization;

namespace Exchange.Service
{
    public class ExchangeArgumentParserService : IExchangeArgumentParserService
    {
        private IExchangeEntityFactory _factory;
        public ExchangeArgumentParserService(IExchangeEntityFactory factory)
        {
            _factory = factory;
        }
        public IExchangePair ArgumentsToExchangePair(string[] args)
        {
            var wrongArgumentsException = new Exception("Incorrect argument format.\nUsage - 'Exchange EUR/DKK 12345.6789'\n");
            if (args.Length != 2)
            {
                throw wrongArgumentsException;
            }

            string[] currencies = args[0].Split('/');
            // All ISO currency codes are made form 3 letters so this checks if the format is correct
            if(currencies.Length != 2 || currencies[0].Length != 3 || currencies[1].Length != 3)
            {
                throw wrongArgumentsException;
            }

            try
            {
                var amount = Convert.ToDecimal(args[1], new CultureInfo("en-US"));
                return _factory.CreateExchangePair(_factory.CreateCurrency(currencies[0].ToUpper()), _factory.CreateCurrency(currencies[1].ToUpper()), amount);
            }
            catch (FormatException)
            {
                throw wrongArgumentsException;
            }
        }
    }
}
