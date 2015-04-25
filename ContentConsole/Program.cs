using System;

namespace ContentConsole
{
    using System.Linq;

    public static class Program
    {
        public static void Main(string[] args)
        {
            bool unmasked = args.Contains("--unmasked");

            const string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            var words = new BadWordStore().GetAllBadWords();

            var analyzer = new TextAnalyzer(words);

            var filter = new WordFilter(words);

            var badWords = analyzer.CountBadWords(content);

            var output = content;

            if (!unmasked)
            {
                output = filter.MaskWords(content);
            }

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(output);
            Console.WriteLine("Total Number of negative words: " + badWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }

}
