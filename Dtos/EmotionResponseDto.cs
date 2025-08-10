namespace HackathonStemFesc.Dtos;

// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
public class Emotion
{
    public string name { get; set; }
    public double score { get; set; }
}

public class GroupedPrediction
{
    public string id { get; set; }
    public List<Prediction> predictions { get; set; }
}

public class Language
{
    public object metadata { get; set; }
    public List<GroupedPrediction> grouped_predictions { get; set; }
}

public class Models
{
    public Language language { get; set; }
}

public class Position
{
    public int begin { get; set; }
    public int end { get; set; }
}

public class Prediction
{
    public string file { get; set; }
    public string file_type { get; set; }
    public Models models { get; set; }
    public string text { get; set; }
    public Position position { get; set; }
    public object time { get; set; }
    public object confidence { get; set; }
    public object speaker_confidence { get; set; }
    public List<Emotion> emotions { get; set; }
    public object sentiment { get; set; }
    public object toxicity { get; set; }
}

public class Results
{
    public List<Prediction> predictions { get; set; }
    public List<object> errors { get; set; }
}

public class EmotionResponseDto
{
    public Source source { get; set; }
    public Results results { get; set; }
}

public class Source
{
    public string type { get; set; }
}
