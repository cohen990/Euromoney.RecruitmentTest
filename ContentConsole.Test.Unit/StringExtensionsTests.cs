namespace ContentConsole.Test.Unit
{
    using NUnit.Framework;

    class StringExtensionsTests
    {
        [TestFixture]
        class MaskWordTests
        {
            [Test]
            public void GivenEmptyString_ReturnsString()
            {
                var input = string.Empty;

                var result = input.Mask();

                Assert.AreEqual(string.Empty, result);
            }

            [Test]
            public void Given1LetterWord_ReturnsSameWord()
            {
                const string input = "a";

                var result = input.Mask();

                Assert.AreEqual("a", result);
            }

            [Test]
            public void Given2LetterWord_ReturnsSameWord()
            {
                const string input = "an";

                var result = input.Mask();

                Assert.AreEqual("an", result);
            }

            [Test]
            public void Given3LetterWord_ReturnsMaskedWord()
            {
                const string input = "and";

                var result = input.Mask();

                Assert.AreEqual("a*d", result);
            }

            [Test]
            public void Given4LetterWord_ReturnsMaskedWord()
            {
                const string input = "andy";

                var result = input.Mask();

                Assert.AreEqual("a**y", result);
            }

            [Test]
            public void Given7LetterWord_ReturnsMaskedWord()
            {
                const string input = "America";

                var result = input.Mask();

                Assert.AreEqual("A*****a", result);
            }
        }
    }
}
