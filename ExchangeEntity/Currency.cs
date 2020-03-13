using System;

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

        public bool Equals(ICurrency other)
        {
            if (other == null) {
                return false;
            }

            return Iso == other.Iso;
        }

        // TODO move to interface
        public override int GetHashCode() {
            return Iso.GetHashCode();
        }
    }
}
