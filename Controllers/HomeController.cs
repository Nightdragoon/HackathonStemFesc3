using System.Diagnostics;
using HackathonStemFesc.Dtos;
using HackathonStemFesc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HackathonStemFesc.Models;

namespace HackathonStemFesc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IThirdPartyConexion _thirdPartyConexion;

    public HomeController(ILogger<HomeController> logger, IThirdPartyConexion thirdPartyConexion)
    {
        _thirdPartyConexion = thirdPartyConexion;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<JsonResult> GetChatGpt([FromBody]ChatGptMessageDto message)
    {
        var chatGpt = await _thirdPartyConexion.GetChatGpt(message);
        return Json(chatGpt.output[1].content[0].text);

    }

    [HttpPost]
    public async Task<JsonResult> sendEmotion([FromBody] EmotionRecognitionDto message)
    {
        try
        {
            var emotion = await _thirdPartyConexion.GetEmotionRecognition(message);
            var emotionPredicitions = await _thirdPartyConexion.GetEmotionResponse(emotion);
            var listOfEmotions = emotionPredicitions[0].results.predictions[0].models.language.grouped_predictions[0]
                .predictions[0].emotions;
            var best = listOfEmotions.MaxBy(e => e.score);

            return Json(best);
        }
        catch (Exception e)
        {
            return Json(e.Message);
        }
    }

    [HttpPost]
    public async Task<JsonResult> GetHumenAi([FromBody] HumenEntranceDto message)
    {
        var humenAi = await _thirdPartyConexion.GetHumenAi(message);
        return Json(humenAi.generations[0].audio);
    }

public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}