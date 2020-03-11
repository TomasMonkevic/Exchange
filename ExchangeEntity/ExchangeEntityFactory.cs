namespace Exchange.Entity
{
    public class ExchangeEntityFactory : IExchangeEntityFactory
    {
        public ICurrency CreateCurrency(string name, string iso)
        {
            return new Currency(name, iso);
        }
        public IExchangePair CreateExchangePair(ICurrency mainCurrency, ICurrency moneyCurrency, decimal amount)
        {
            return new ExchangePair(mainCurrency, moneyCurrency, amount);
        }
    }
}
