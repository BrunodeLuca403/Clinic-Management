using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicManagement.Core.Entitys.OpenIA
{
    public class OpenAIResponse
    {
        [JsonPropertyName("output")]
        public List<Output> Output { get; set; }

    }

    public class Output
    {
        [JsonPropertyName("content")]
        public List<Content> Content { get; set; }
    }

    public class Content
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("annotations")]
        public List<string> Annotations { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
