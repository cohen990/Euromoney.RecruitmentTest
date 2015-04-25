namespace ContentConsole.Test.Unit
{
    using System.Linq;
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

            Assert.AreSame(string.Empty, result);
        }

        [Test]
        public void GivenContentWithoutFilterableWords_ReturnsSameContent()
        {
            const string input = "I am normal content that should not be filtered";

            var filter = new WordFilter("camel");

            var result = filter.MaskWords(input);

            Assert.AreSame(input, result);
        }

        [Test]
        public void GivenFilterableWord_ReturnsMaskedWord()
        {
            const string input = "camel";
            const string expected = "c***l";

            var filter = new WordFilter("camel");

            var result = filter.MaskWords(input);

            Assert.AreSame(expected, result);
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
            return input;
        }
    }
}
