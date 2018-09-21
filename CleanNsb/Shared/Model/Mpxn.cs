namespace CleanNsb.Shared.Model
{
    public class Mpxn
    {
        public static Mpxn From(string mpxn) => new Mpxn { Value = mpxn };

        public static implicit operator string(Mpxn mpxn) => mpxn.Value;

        private string Value { get; set; }
    }
}