namespace Exchange.Entity
{
    public interface IExchangeEntityFactory
    {
        ICurrency CreateCurrency(string name, string iso);
        ICurrency CreateCurrency(string iso);
        IExchangePair CreateExchangePair(ICurrency mainCurrency, ICurrency moneyCurrency, decimal amount);
    }
}
