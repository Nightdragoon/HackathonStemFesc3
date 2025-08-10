namespace HackathonStemFesc.Dtos;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Encoding
{
    public string format { get; set; }
    public int sample_rate { get; set; }
}

public class Generation
{
    public string generation_id { get; set; }
    public double duration { get; set; }
    public int file_size { get; set; }
    public Encoding encoding { get; set; }
    public string audio { get; set; }
    public List<List<Snip>> snippets { get; set; }
}

public class HumenAiDto
{
    public string request_id { get; set; }
    public List<Generation> generations { get; set; }
}

public class Snip
{
    public string id { get; set; }
    public string text { get; set; }
    public string generation_id { get; set; }
    public int utterance_index { get; set; }
    public string audio_format { get; set; }
    public string transcribed_text { get; set; }
    public string audio { get; set; }
}



