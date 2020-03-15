using Exchange.Entity;

namespace Exchange.Service.UnitTests
{
    public static class TestData
    {
        public readonly static Currency DKK = new Currency("Danske kroner", "DKK");
        public readonly static Currency EUR = new Currency("Euro", "EUR");
        public readonly static Currency USD = new Currency("Amerikanske dollar", "USD");
        public readonly static Currency GBP = new Currency("Britiske pund", "GBP");
        public readonly static Currency LTL = new Currency("Lithuanian litas", "LTL");
    }
}
