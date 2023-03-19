using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class ApiResponseData<T>
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
