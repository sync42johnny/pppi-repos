using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Movie
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        public override string ToString()
        {
            return $"Movie ID: {Id}\n" +
                   $"Title: {Title}\n" +
                   $"Release Date: {ReleaseDate.ToString("yyyy-MM-dd")}\n" +
                   $"Overview: {Overview}\n" +
                   $"Popularity: {Popularity}\n" +
                   $"Vote Average: {VoteAverage}\n" +
                   $"Vote Count: {VoteCount}\n" +
                   $"Genres: {string.Join(", ", GenreIds)}\n" +
                   $"Is Adult: {Adult}\n" +
                   $"Has Video: {Video}\n" +
                   $"Original Language: {OriginalLanguage}\n" +
                   $"Original Title: {OriginalTitle}\n" +
                   $"Poster Path: {PosterPath}\n" +
                   $"Backdrop Path: {BackdropPath}";
        }
    }
}

