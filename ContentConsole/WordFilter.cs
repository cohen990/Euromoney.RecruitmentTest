namespace ContentConsole
{
    using System.Text.RegularExpressions;

    public class WordFilter
    {
        private readonly string[] _wordsToFilter;

        public WordFilter(params string[] wordsToFilter)
        {
            _wordsToFilter = wordsToFilter;
        }

        public string MaskWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            foreach (var word in _wordsToFilter)
            {
                var regex = @"(\A|\W)" + word + @"(\z|\W)";

                if (Regex.IsMatch(input, regex))
                {
                    input = input.Replace(word, word.Mask());
                }
            }

            return input;
        }
    }
}