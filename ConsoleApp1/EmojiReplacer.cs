namespace ConsoleApp1
{
    class EmojiReplacer
    {
        public static void ReplaceWordsWithEmojis(string text, string[] wordsToReplace, string[] emojis)
        {
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < wordsToReplace.Length; j++)
                {
                    if (words[i] == wordsToReplace[j])
                    {
                        words[i] = emojis[j];
                        break;
                    }
                }
            }

            string modifiedText = string.Join(" ", words);

            // Add a delay of 1 second
            Thread.Sleep(1000);

            // Print the modified text to the console
            Console.WriteLine(modifiedText);
        }
    }
}
