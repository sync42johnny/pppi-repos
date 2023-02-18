namespace ConsoleApp1
{
    class NumberProcessor
    {
        public static void PrintOddAndEvenNumbers()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNumbers.Add(numbers[i]);
                }
                else
                {
                    oddNumbers.Add(numbers[i]);
                }

                // Print a message to the console indicating the number being processed.
                Console.WriteLine("OddOrEven - Processed number: {0}", numbers[i]);

                // Pause the execution of the program for 500 milliseconds.
                Thread.Sleep(500);
            }

            Console.WriteLine("OddOrEven - Found {0} even numbers and {1} odd numbers.", evenNumbers.Count, oddNumbers.Count);
        }
    }
}
