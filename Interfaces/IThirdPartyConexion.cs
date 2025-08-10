using System.Text.Json;
using System.Text.Json.Serialization;
using HackathonStemFesc.Dtos;

namespace HackathonStemFesc.Interfaces;

public interface IThirdPartyConexion
{
    public Task<ChatGptDto> GetChatGpt(ChatGptMessageDto mensaje);
    public Task<HumenAiDto> GetHumenAi(HumenEntranceDto mensaje);
    public Task<EmotionRecognitionResoponseDto> GetEmotionRecognition(EmotionRecognitionDto mensaje);
    public Task<List<EmotionResponseDto>> GetEmotionResponse(EmotionRecognitionResoponseDto mensaje);
}

public class ThirdPartyConexion : IThirdPartyConexion
{
    public async Task<ChatGptDto> GetChatGpt(ChatGptMessageDto mensaje)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8000/chatGptConexion");
            var content = JsonSerializer.Serialize(mensaje);
            request.Content = new StringContent(content, null , "application/json");
            var response = await client.SendAsync(request);
            if (response == null || response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var restult = await JsonSerializer.DeserializeAsync<ChatGptDto>(await response.Content.ReadAsStreamAsync());
            return restult;
            

        }
        catch (Exception ex)
        {
            return null;
        }

    }

    public async Task<HumenAiDto> GetHumenAi(HumenEntranceDto mensaje)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8000/human");
            var content = JsonSerializer.Serialize(mensaje);
            request.Content = new StringContent(content , null , "application/json");
            var response = await client.SendAsync(request);
            if (response == null || response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var restult = await JsonSerializer.DeserializeAsync<HumenAiDto>(await response.Content.ReadAsStreamAsync());
            return restult;
            

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<EmotionRecognitionResoponseDto> GetEmotionRecognition(EmotionRecognitionDto mensaje)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://127.0.0.1:8000/emotion");
            var content = JsonSerializer.Serialize(mensaje);
            request.Content = new StringContent(content , null , "application/json");
            var response = await client.SendAsync(request);
            if (response == null || response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var restult = await JsonSerializer.DeserializeAsync<EmotionRecognitionResoponseDto>(await response.Content.ReadAsStreamAsync());
            return restult;
            

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<EmotionResponseDto>> GetEmotionResponse(EmotionRecognitionResoponseDto mensaje)
    {
        try
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://127.0.0.1:8000/getEmotion/" +mensaje.job_id);
            var response = await client.SendAsync(request);
            if (response == null || response.IsSuccessStatusCode == false)
            {
                return null;
            }
            var restult = await JsonSerializer.DeserializeAsync<List<EmotionResponseDto>>(await response.Content.ReadAsStreamAsync());
            return restult;
            

        }
        catch (Exception ex)
        {
            return null;
        }
    }
}