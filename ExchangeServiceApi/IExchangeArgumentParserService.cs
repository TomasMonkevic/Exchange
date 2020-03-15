using Exchange.Entity;

namespace Exchange.Service
{
    public interface IExchangeArgumentParserService
    {
        IExchangePair ArgumentsToExchangePair(string[] args);
    }
}
