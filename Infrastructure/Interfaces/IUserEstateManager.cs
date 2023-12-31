namespace BlazorServer.Infrastructure.Interfaces;

public interface IUserEstateManager
{
    Task UpdateUserSumEstatesAsync(string userName, CancellationToken cancellationToken);
}