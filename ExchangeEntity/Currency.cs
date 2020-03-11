namespace Exchange.Entity
{
    public class Currency : ICurrency
    {
        public Currency(string name, string iso)
        {
            Name = name;
            Iso = iso;
        }
        public string Name { get; set; }
        public string Iso { get; set; }
    }
}
