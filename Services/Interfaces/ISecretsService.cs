namespace ba_server.Services.Interfaces;

public interface ISecretsService
{
  Task<string> Get(string key);
}