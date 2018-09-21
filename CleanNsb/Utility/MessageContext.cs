namespace CleanNsb
{
    public interface MessageContext
    {
        void Publish<T>(T @event);

        void Instruct<T>(T command);
    }
}