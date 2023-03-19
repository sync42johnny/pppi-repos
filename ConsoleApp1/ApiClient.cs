using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class ApiClient
    {
        // Private variables used by the ApiClient class
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly int _accountId;
        private readonly string _sessionId;

        // Constructor for the ApiClient class
        public ApiClient(HttpClient httpClient, string baseUrl, string apiKey, int accountId, string sessionId)
        {
            // Initialize private variables
            _httpClient = httpClient;
            _baseUrl = baseUrl;
            _apiKey = apiKey;
            _accountId = accountId;
            _sessionId = sessionId;
        }

        // Method to make a GET request to an endpoint and return an ApiResponseModel with Movie data
        public async Task<ApiResponseModel<Movie>> GetAsync<T>(string endpoint)
        {
            try
            {
                // Make GET request to specified endpoint
                var response = await _httpClient.GetAsync($"{_baseUrl}/{endpoint}");
                // Process response and return ApiResponseModel with Movie data
                return await ProcessResponse(response);
            }
            catch (Exception ex)
            {
                // If an exception occurs, return ApiResponseModel with error information
                return new ApiResponseModel<Movie>
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    Data = null
                };
            }
        }

        // Method to make a POST request to an endpoint with data and return an ApiResponseModel with Movie data
        public async Task<ApiResponseModel<Movie>> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                // Serialize data into JSON format
                var jsonData = JsonConvert.SerializeObject(data);
                // Create request body with JSON data
                var requestBody = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                // Make POST request to specified endpoint with request body
                var response = await _httpClient.PostAsync($"{_baseUrl}/{endpoint}", requestBody);
                // Ensure that response indicates success
                response.EnsureSuccessStatusCode();

                // Process response and return ApiResponseModel with Movie data
                return await ProcessResponse(response);
            }
            catch (Exception ex)
            {
                // If an exception occurs, return ApiResponseModel with error information
                return new ApiResponseModel<Movie>
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    Data = null
                };
            }
        }

        // Method to add a movie to a watchlist for the account associated with the ApiClient instance
        public async Task<HttpResponseMessage> AddMovieToWatchlistAsync(int movieId, string mediaType)
        {
            // Create new POST request to add movie to watchlist
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/account/{_accountId}/watchlist?api_key={_apiKey}&session_id={_sessionId}");
            // Add Bearer authorization header to request
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");
            // Add JSON content to request body
            request.Content = new StringContent(JsonConvert.SerializeObject(new { media_id = movieId, watchlist = true, media_type = mediaType }),
                                                Encoding.UTF8,
                                                "application/json");

            // Send request and ensure that response indicates success
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response;
        }

        // Private method to process an HttpResponseMessage and return an ApiResponseModel with Movie data
        private async Task<ApiResponseModel<Movie>> ProcessResponse(HttpResponseMessage response)
        {
            // Create new ApiResponseModel to hold response data
            var apiResponse = new ApiResponseModel<Movie>
            {
                // Set the Message property of the ApiResponseModel to the response reason phrase
                Message = response.ReasonPhrase,

                // Set the StatusCode property of the ApiResponseModel to the response status code
                StatusCode = (int)response.StatusCode
            };

            // Read the response content as a string
            var responseContent = await response.Content.ReadAsStringAsync();

            try
            {
                // Deserialize the response content into an ApiResponseData<Movie> object using JsonConvert
                var data = JsonConvert.DeserializeObject<ApiResponseData<Movie>>(responseContent);

                // Set the Data property of the ApiResponseModel to the deserialized response data
                apiResponse.Data = data.Results;
            }
            catch (JsonException)
            {
                // If deserialization fails, set the Message property of the ApiResponseModel to indicate the failure
                apiResponse.Message = "Unable to parse response data.";
            }

            // Return the ApiResponseModel object
            return apiResponse;
        }
    }
}
