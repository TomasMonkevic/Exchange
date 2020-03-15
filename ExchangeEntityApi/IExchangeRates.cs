using System.Collections.Generic;

namespace Exchange.Entity
{
    public interface IExchangeRates
    {
        ICurrency MainCurrency { get; set; }
        decimal Unit { get; set; }
        decimal GetRate(ICurrency currency);
        
    }
}
