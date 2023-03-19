using System;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();

            // set base URL for API requests
            var baseUrl = "https://api.themoviedb.org/3";

            // set API key for authentication
            var apiKey = "d9a2ab55e3ff870e13783f73f794a473";

            // set session ID and account ID for watchlist API requests
            var sessionId = "2da368b63b55e42ffc4c7b632e6c52c71b3c5e3f";
            var accountId = 14680716;

            // create a new instance of the custom API client with the HttpClient and API parameters
            var apiClient = new ApiClient(httpClient, baseUrl, apiKey, accountId, sessionId);

            // use the API client to send a GET request to get a list of popular movies
            var popularMovies = await apiClient.GetAsync<object>($"movie/popular?api_key={apiKey}");

            // use the API client to send a POST request to search for horror movies with "Shrex" query
            var horrorMovies = await apiClient.PostAsync<object>($"search/movie?api_key={apiKey}", new { query = "Shrex" });

            // print the status code of the horrorMovies API response
            Console.WriteLine($"the status code of the horrorMovies API response: {horrorMovies.StatusCode}");

            // if the popularMovies API response is successful, print the movie list
            if (popularMovies.StatusCode == 200)
            {
                foreach (var movie in popularMovies.Data)
                {
                    Console.WriteLine($"{movie}\n");
                }
            }
            else
            {
                // if the popularMovies API response is not successful, print the error status code
                Console.WriteLine($"Error: {popularMovies.StatusCode}");
            }

            // use the API client to add a movie and TV show to the user's watchlist
            var response = await apiClient.AddMovieToWatchlistAsync(11, "movie");
            await apiClient.AddMovieToWatchlistAsync(677179, "movie");
            await apiClient.AddMovieToWatchlistAsync(536554, "movie");
            await apiClient.AddMovieToWatchlistAsync(100088, "tv");
        }
    }
}
