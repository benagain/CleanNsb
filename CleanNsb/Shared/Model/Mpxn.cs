using System;
using System.Collections.Generic;

namespace CleanNsb.Shared.Model
{
    public class Mpxn
    {
        public static Mpxn From(int mpxn) => new Mpxn { Value = mpxn };

        public static Mpxn From(string mpxn) => new Mpxn { Value = Convert.ToInt32(mpxn) };

        public static implicit operator string(Mpxn mpxn) => mpxn.ToString();

        public override string ToString() => Value.ToString();

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case string other: return Value.ToString() == other;
                case Mpxn other: return Value == other.Value;
                case int other: return Value == other;
                default: return false;
            }
        }

        public static bool operator ==(Mpxn l, Mpxn r) => l.Equals(r);

        public static bool operator !=(Mpxn l, Mpxn r) => !l.Equals(r);

        public static bool operator ==(Mpxn l, string r) => l.Equals(Mpxn.From(r));

        public static bool operator !=(Mpxn l, string r) => !(l == r);

        public static bool operator ==(Mpxn l, int r) => l.Equals(Mpxn.From(r));

        public static bool operator !=(Mpxn l, int r) => !(l == r);

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<int>.Default.GetHashCode(Value);
        }

        private int Value { get; set; }
    }
}