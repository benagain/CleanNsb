namespace EventuallyPoc
{
    namespace Domain
    {
        public class Mpxn
        {
            public static Mpxn Create(string mpxn) => new Mpxn { Value = mpxn };

            public static implicit operator string(Mpxn mpxn) => mpxn.Value;

            private string Value { get; set; }
        }
    }
}