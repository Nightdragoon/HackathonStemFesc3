namespace HackathonStemFesc.Dtos;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Content
    {
        public string type { get; set; }
        public List<object> annotations { get; set; }
        public List<object> logprobs { get; set; }
        public string text { get; set; }
    }

    public class Format
    {
        public string type { get; set; }
    }

    public class InputTokensDetails
    {
        public int cached_tokens { get; set; }
    }

    public class Metadata
    {
    }

    public class Output
    {
        public string id { get; set; }
        public string type { get; set; }
        public List<object> summary { get; set; }
        public string status { get; set; }
        public List<Content> content { get; set; }
        public string role { get; set; }
    }

    public class OutputTokensDetails
    {
        public int reasoning_tokens { get; set; }
    }

    public class Reasoning
    {
        public string effort { get; set; }
        public object summary { get; set; }
    }

    public class ChatGptDto
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created_at { get; set; }
        public string status { get; set; }
        public bool background { get; set; }
        public object error { get; set; }
        public object incomplete_details { get; set; }
        public object instructions { get; set; }
        public object max_output_tokens { get; set; }
        public object max_tool_calls { get; set; }
        public string model { get; set; }
        public List<Output> output { get; set; }
        public bool parallel_tool_calls { get; set; }
        public object previous_response_id { get; set; }
        public object prompt_cache_key { get; set; }
        public Reasoning reasoning { get; set; }
        public object safety_identifier { get; set; }
        public string service_tier { get; set; }
        public bool store { get; set; }
        public double temperature { get; set; }
        public Text text { get; set; }
        public string tool_choice { get; set; }
        public List<object> tools { get; set; }
        public int top_logprobs { get; set; }
        public double top_p { get; set; }
        public string truncation { get; set; }
        public Usage usage { get; set; }
        public object user { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Text
    {
        public Format format { get; set; }
        public string verbosity { get; set; }
    }

    public class Usage
    {
        public int input_tokens { get; set; }
        public InputTokensDetails input_tokens_details { get; set; }
        public int output_tokens { get; set; }
        public OutputTokensDetails output_tokens_details { get; set; }
        public int total_tokens { get; set; }
    }
