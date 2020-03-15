using System;

namespace Exchange.Entity
{
    public interface ICurrency : IEquatable<ICurrency>
    {
        string Name { get; set; }
        string Iso { get; set; }

        int GetHashCode();
    }
}
