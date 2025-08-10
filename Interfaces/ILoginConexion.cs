using System.Text.Json;
using HackathonStemFesc.Dtos;

namespace HackathonStemFesc.Interfaces;

public interface ILoginConexion
{
    public bool SiExiste(string username, string password);
    public Task<CreatedDto> Register(RegisterDto user);
    public bool Login(string username, string password);
}

public class LoginConexion : ILoginConexion
{
    public bool SiExiste(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<CreatedDto> Register(RegisterDto user)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "127.0.0.1:8000/users/upsert");
            var contenido = JsonSerializer.Serialize(user);
            var content = new StringContent(contenido, null, "application/json");

            request.Content = content;
            var response = await client.SendAsync(request);
            if (response == null || response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var restult = await JsonSerializer.DeserializeAsync<CreatedDto>(await response.Content.ReadAsStreamAsync());
            return restult;
        }
        catch (Exception e)
        {
            return null;
        }
        
    }

    public bool Login(string username, string password)
    {
        throw new NotImplementedException();
    }
}