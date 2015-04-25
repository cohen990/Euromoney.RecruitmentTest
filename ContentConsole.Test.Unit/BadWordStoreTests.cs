namespace ContentConsole.Test.Unit
{
    using NUnit.Framework;

    [TestFixture]
    class BadWordStoreTests
    {
        [Test]
        public void ReturnsListOfBadWords()
        {
            var store = new BadWordStore();

            var words = store.GetAllBadWords();

            Assert.IsNotEmpty(words);
        }
    }
}
