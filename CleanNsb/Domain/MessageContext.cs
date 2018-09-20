namespace EventuallyPoc
{

    namespace Domain
    {
        public interface MessageContext
        {
            void Publish<T>(T @event);

            void Instruct<T>(T command);
        }
    }
}