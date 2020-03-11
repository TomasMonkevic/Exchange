namespace Exchange.Entity
{
    public interface IExchangePair
    {
        ICurrency MainCurrency { get; set; }
        ICurrency MoneyCurrency { get; set; }
        decimal Amount { get; set; }
    }
}
