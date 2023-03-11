using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Anime
    {
        // A field with read-only access (readonly)
        public readonly String Title;

        // A field with private access
        private String genre;

        // A field with default access (internal)
        internal int Episodes;

        // A field with access only within this class (protected)
        protected String studio;

        // A field with access through get/set accessors
        public String Director { get; set; }

        // Class constructor that initializes fields
        public Anime(String title, String genre, int episodes, String studio, String director)
        {
            Title = title;
            this.genre = genre;
            Episodes = episodes;
            this.studio = studio;
            Director = director;
        }

        public String GetInfo()
        {
            return $"{Title} ({Episodes} еп.) - {genre} ({studio}) - реж. {Director}";
        }

        // Method with access only within this class (protected) that changes the value of a field
        protected void SetStudio(String newStudio)
        {
            studio = newStudio;
        }

        // Method with access through the get accessor
        public String GetGenre()
        {
            return genre;
        }

        // Method with access through the set accessor that changes the value of a field
        public void SetGenre(String newGenre)
        {
            genre = newGenre;
        }

        // Method that returns the number of episodes in the format "seasons x, episodes y"
        public String GetEpisodesFormatted()
        {
            int seasons = Episodes / 12;
            int episodes = Episodes % 12;

            if (seasons == 0)
            {
                return $"{Episodes} еп.";
            }
            else if (episodes == 0)
            {
                return $"{seasons} сезонів";
            }
            else
            {
                return $"{seasons} сезонів, {episodes} еп.";
            }
        }

        // Method that changes the studio that created the anime to a random studio from a list
        public void ChangeStudio(List<String> studios)
        {
            Random random = new Random();
            int index = random.Next(studios.Count);
            studio = studios[index];
        }

        // Method that returns a list of anime with the same genre as the current one,
        // but with different studio and director
        public List<Anime> GetSimilarAnime(List<Anime> allAnime)
        {
            List<Anime> similarAnime = new List<Anime>();

            foreach (Anime anime in allAnime)
            {
                if (anime.Title != Title && anime.genre == genre && anime.studio != studio &&
                    anime.Director != Director)
                {
                    similarAnime.Add(anime);
                }
            }

            return similarAnime;
        }
    }
}
