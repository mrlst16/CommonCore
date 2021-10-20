namespace CommonCore.Interfaces.Utilities
{
    public interface IValidator
    {
        void ThrowExceptionIfInvalid<T>(T request);
    }
}
