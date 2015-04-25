namespace ContentConsole.Test.Unit
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    [TestFixture]
    class WordFilterTests
    {
        [Test]
        public void GivenEmptyString_ReturnsEmptyString()
        {
            var input = string.Empty;

            var filter = new WordFilter(string.Empty);

            var result = filter.MaskWords(input);

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GivenContentWithoutFilterableWords_ReturnsSameContent()
        {
            const string input = "I am normal content that should not be filtered";

            var filter = new WordFilter("camel");

            var result = filter.MaskWords(input);

            Assert.AreEqual(input, result);
        }

        [Test]
        public void GivenFilterableWord_ReturnsMaskedWord()
        {
            const string input = "camel";
            const string expected = "c###l";

            var filter = new WordFilter("camel");

            var result = filter.MaskWords(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenOneFilterableWord_ReturnsOneMaskedWord()
        {
            const string input = "camel hair";
            const string expected = "c###l hair";

            var filter = new WordFilter("camel");

            var result = filter.MaskWords(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenTwoDifferentFilterableWord_ReturnsTwoAppropriatelyMaskedWord()
        {
            const string input = "camel hair";
            const string expected = "c###l h##r";

            var filter = new WordFilter("camel", "hair");

            var result = filter.MaskWords(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordContainingFilterableWord_ReturnsUnmaskedWord()
        {
            const string input = "arrest";
            const string expected = "arrest";

            var filter = new WordFilter("rest");

            var result = filter.MaskWords(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenContentWithDoubleSpaces_MasksWords()
        {
            const string input = "arrest  that  man";
            const string expected = "a####t  t##t  m#n";

            var filter = new WordFilter("arrest", "that", "man");

            var result = filter.MaskWords(input);

            Assert.AreEqual(expected, result);
        }
    }

    internal class WordFilter
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
