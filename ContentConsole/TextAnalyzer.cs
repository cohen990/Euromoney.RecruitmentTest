namespace ContentConsole
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class TextAnalyzer
    {
        private readonly string[] _badWords;
        public TextAnalyzer(params string[] badWords)
        {
            _badWords = badWords;
        }

        public int CountBadWords(string text)
        {
            int badWords = 0;

            foreach (var badWord in _badWords)
            {
                MatchCollection matches = Regex.Matches(text, badWord);

                badWords += matches.Count;
            }

            return badWords;
        }
    }
}
