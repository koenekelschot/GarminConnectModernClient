namespace GarminConnectModernClient.Clients
{
    public interface IGarminSsoClient
    {
        Task LoginAsync(string username, string password, CancellationToken cancellationToken);
        Task LogoutAsync(CancellationToken cancellationToken);
    }
}
