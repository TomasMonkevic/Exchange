using Exchange.Entity;

namespace Exchange.Service.UnitTests
{
    public static class TestData
    {
        public readonly static Currency dkk = new Currency("Danske kroner", "DKK");
        public readonly static Currency eur = new Currency("Euro", "EUR");
        public readonly static Currency usd = new Currency("Amerikanske dollar", "USD");
        public readonly static Currency gbp = new Currency("Britiske pund", "GBP");
        public readonly static Currency LTL = new Currency("Lithuanian litas", "LTL");
    }
}
