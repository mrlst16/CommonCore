namespace CommonCore.Interfaces.Helpers
{
    public interface IApplicationConsistency
    {
        byte[] GetBytes(string str);
        string GetString(byte[] bytes);
        bool BytesEqual(byte[] one, byte[] two);
    }
}
