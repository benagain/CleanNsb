using System;

namespace CleanNsb
{
    namespace Maybe
    {
        public struct Maybe<T> where T : class
        {
            private readonly T _value;

            public Maybe(T value) => _value = value;

            public static implicit operator Maybe<T>(T value) => new Maybe<T>(value);

            public bool HasValue => _value != null;

            public Maybe<TResult> Select<TResult>(Func<T, Maybe<TResult>> getter) where TResult : class =>
                HasValue ? getter(_value) : new Maybe<TResult>();

            public T OrElse(T alternative) => HasValue ? _value : alternative;

            public T OrElseThrow(Func<Exception> exception) => HasValue ? _value : throw exception();

            public void Do(Action<T> action)
            {
                if (HasValue)
                    action(_value);
            }
        }

        public static class Extensions
        {
            public static bool IsNothing<T>(this Maybe<T> maybe) where T : class =>
                !maybe.HasValue;
        }
    }
}