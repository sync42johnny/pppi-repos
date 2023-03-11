using ConsoleApp1;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ///////////////////
        Console.WriteLine("1.\tНаписати клас, який містить не менше 5 полів і не менше 3 методів. Типи даних та модифікатори доступу повинні бути різними.");
        ///////////////////

        Anime attackOnTitan = new Anime("Attack on Titan", "Action", 75, "Wit Studio", "Tetsurō Araki");

        // Getting information about the anime and printing it to the console
        Console.WriteLine(attackOnTitan.GetInfo());

        // Changing the genre of the anime
        attackOnTitan.SetGenre("Horror");

        // Getting and printing to the console the number of episodes in the format "seasons x, episodes y"
        Console.WriteLine(attackOnTitan.GetEpisodesFormatted());

        List<string> studios = new List<string> { "Madhouse", "Bones", "Kyoto Animation", "Shaft", "A-1 Pictures", "Gonzo" };
        attackOnTitan.ChangeStudio(studios);

        // Getting and printing to the console a list of anime with the same genre as the current anime but with a different studio and director
        List<Anime> allAnime = new List<Anime> {
            new Anime("Death Note", "Mystery", 37, "Madhouse", "Tetsurō Araki"),
            new Anime("Tokyo Ghoul", "Horror", 48,"Pierrot", "Shuhei Morita"),
            new Anime("Attack on Titan: Junior High",  "Comedy", 12, "Production I.G", "Yoshihide Ibata"),
            new Anime("Parasyte", "Horror", 24, "Madhouse", "Kenichi Shimizu"),
            new Anime("Black Butler", "Action",46, "A-1 Pictures", "Toshiya Shinohara")
        };
        List<Anime> similarAnime = attackOnTitan.GetSimilarAnime(allAnime);
        Console.WriteLine("Similar anime:");
        foreach (Anime anime in similarAnime)
        {
            Console.WriteLine(anime.GetInfo());
        }

        ///////////////////
        Console.WriteLine("2.\tПродемонструвати роботу з Type і TypeInfo");
        ///////////////////

        // Get the type of Anime class
        Type animeType = typeof(Anime);
        Console.WriteLine("Anime class name: " + animeType.Name);

        // Get the type information for the Anime class
        TypeInfo animeTypeInfo = animeType.GetTypeInfo();
        Console.WriteLine("Anime class has " + animeTypeInfo.DeclaredProperties.Count() + " properties:");

        // Print the names of all properties of the Anime class
        foreach (var property in animeTypeInfo.DeclaredProperties)
        {
            Console.WriteLine("- " + property.Name);
        }

        // Print the names of all public methods of the Anime class
        Console.WriteLine("Anime class has " + animeTypeInfo.DeclaredMethods.Count(m => m.IsPublic) + " public methods:");
        foreach (var method in animeTypeInfo.DeclaredMethods.Where(m => m.IsPublic))
        {
            Console.WriteLine("- " + method.Name);
        }

        // Print the names of all fields of the Anime class
        Console.WriteLine("Anime class has " + animeTypeInfo.DeclaredFields.Count() + " fields:");
        foreach (var field in animeTypeInfo.DeclaredFields)
        {
            Console.WriteLine("- " + field.Name);
        }

        ///////////////////
        Console.WriteLine("3.\tПродемонструвати роботу з MemberInfo");
        ///////////////////

        // Get all the members of the Anime class
        MemberInfo[] animeMembers = animeType.GetMembers();

        foreach (MemberInfo member in animeMembers)
        {
            Console.WriteLine(member.Name);
        }

        ///////////////////
        Console.WriteLine("4.\tПродемонструвати роботу з FieldInfo");
        ///////////////////

        Anime myAnime = new Anime("Cowboy Bebop", "Space Western", 26, "Sunrise", "Shinichirō Watanabe");

        // Accessing field using FieldInfo
        Type myAnimeType = typeof(Anime);
        FieldInfo studioField = myAnimeType.GetField("studio", BindingFlags.NonPublic | BindingFlags.Instance);
        string studioValue = (string)studioField.GetValue(myAnime);
        Console.WriteLine($"Studio: {studioValue}");

        // Modifying field using FieldInfo
        studioField.SetValue(myAnime, "Madhouse");

        ///////////////////
        Console.WriteLine("5.\tПродемонструвати роботу з MethodInfo. Викликати будь-який метод через Reflection");
        ///////////////////

        Anime fullmetalAlchemist = new Anime("Fullmetal Alchemist", "Action", 51, "Bones", "Seiji Mizushima");

        // Get the MethodInfo object for the GetInfo() method
        MethodInfo getInfoMethod = animeType.GetMethod("GetInfo");

        // Invoke the GetInfo() method on the anime instance
        string animeInfo = (string)getInfoMethod.Invoke(fullmetalAlchemist, null);

        // Print the anime information to the console
        Console.WriteLine(animeInfo);
    }
}