namespace ContentConsole
{
    public class BadWordStore
    {
        public string[] GetAllBadWords()
        {
            /* Not entirely sure if I understood what was meant by
             * 'No actual storage implementation or databases are required, feel free to stub or mock any data access you need.' */

            var words = new[] { "bad", "nasty", "horrible", "swine" };

            return words;
        }
    }
}