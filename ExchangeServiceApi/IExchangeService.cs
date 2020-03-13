using Exchange.Entity;

namespace Exchange.Service
{
    public interface IExchangeService
    {
        decimal CalculateMoneyCurrencyAmount(IExchangeRates exchangeRates, IExchangePair exchangePair);
    }
}
