using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        //string originalText = "I'm so happy!";
        //string[] wordsToReplace = { "happy" };
        //string[] emojis = { "😊" };

        //Thread t1 = new Thread(() => EmojiReplacer.ReplaceWordsWithEmojis(originalText, wordsToReplace, emojis));
        //Thread t2 = new Thread(new ThreadStart(Printer.PrintGreetings));
        //Thread t3 = new Thread(new ThreadStart(NumberProcessor.PrintOddAndEvenNumbers));

        //t1.Start();
        //t2.Start();
        //t3.Start();

        //t1.Join();
        //t2.Join();
        //t3.Join();


        Console.WriteLine("Starting asynchronous methods...");

        // Call asynchronous methods

        // GetRatingAsync
        Task<int> ratingTask = Task.Run(() => GetRatingAsync("Naruto"));

        Console.WriteLine($"Retrieving user rating for Naruto...");

        int rating = ratingTask.Result;

        Console.WriteLine($"The average user rating for Naruto is {rating}%.");

        // DownloadFileAsync
        Task.Run(() => DownloadFileAsync("https://cdn.myanimelist.net/images/anime/2/75259.jpg", "D:/Downloads/output.jpg")).Wait();
        
        // PrintFizzBuzz
        Task.Run(() => PrintFizzBuzz(50)).Wait();

        Console.WriteLine("All asynchronous methods have completed.");

        Console.ReadLine();
    }

    static async Task<int> GetRatingAsync(string animeName)
    {
        // We'll simulate a delay to simulate the time it take
        // to retrieve data from a database or other data source.
        await Task.Delay(1000);

        // simulate the user rating for the anime.
        Random rand = new Random();
        return rand.Next(50, 101);
    }

    static async Task DownloadFileAsync(string url, string outputFilename)
    {
        Console.WriteLine($"Starting DownloadFileAsync for {url}...");
        using (var client = new System.Net.WebClient())
        {
            await client.DownloadFileTaskAsync(url, outputFilename);
        }
        Console.WriteLine($"DownloadFileAsync completed for {url}.");
    }

    static async Task PrintFizzBuzz(int count)
    {
        Console.WriteLine($"Starting PrintFizzBuzz for {count} numbers...");
        for (int i = 1; i <= count; i++)
        {
            string output = "";
            if (i % 3 == 0) output += "Fizz";
            if (i % 5 == 0) output += "Buzz";
            if (string.IsNullOrEmpty(output)) output = i.ToString();
            Console.WriteLine(output);
            await Task.Delay(500);
        }
        Console.WriteLine($"PrintFizzBuzz completed for {count} numbers.");
    }
}