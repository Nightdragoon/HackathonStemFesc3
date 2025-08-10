using System.Text.Json;
using HackathonStemFesc.Dtos;

namespace HackathonStemFesc.Interfaces;

public interface ILoginConexion
{
    public bool SiExiste(string username, string password);
    public Task<bool> Register(RegisterDto user);
    public bool Login(string username, string password);
}

public class LoginConexion : ILoginConexion
{
    public bool SiExiste(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Register(RegisterDto user)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "127.0.0.1:8000/register");
            var contenido = JsonSerializer.Serialize(user);
            var content = new StringContent(contenido, null, "application/json");

            request.Content = content;
            var response = await client.SendAsync(request);
            if (response == null || response.IsSuccessStatusCode == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception e)
        {
            return false;
        }
        
    }

    public bool Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}