using System.Collections.Generic;

namespace Exchange.Entity
{
    public interface IExchangeRates
    {
        ICurrency MainCurrency { get; set; }
        decimal Unit { get; set; }
        Dictionary<ICurrency, decimal> Rates { get; set; }
        
    }
}
