namespace Exchange.Entity
{
    public class ExchangePair : IExchangePair
    {
        public ExchangePair(ICurrency mainCurrency, ICurrency moneyCurrency, decimal amount)
        {
            MainCurrency = mainCurrency;
            MoneyCurrency = moneyCurrency;
            Amount = amount;
        }
        public ICurrency MainCurrency { get; set; }
        public ICurrency MoneyCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
