namespace ConsoleApp1
{
    class Printer
    {
        public static void PrintGreetings()
        {
            string[] names = { "Alice", "Bob", "Charlie", "David", "Emily" };

            Random random = new Random();

            for (int i = 0; i < names.Length; i++)
            {
                // Generate a random delay time between 1000 and 3000 milliseconds
                int delay = random.Next(1000, 3000);

                // Print a greeting message to the console with the name and delay time
                Console.WriteLine("Printer - Hello, {0}! (delay: {1} ms)", names[i], delay);

                // Pause the execution of the current thread for the specified delay time
                Thread.Sleep(delay);
            }
        }
    }
}
