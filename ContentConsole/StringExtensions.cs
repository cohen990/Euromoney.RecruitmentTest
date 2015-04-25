namespace ContentConsole
{
    using System.Text;

    public static class StringExtensions
    {
        public static string Mask(this string input)
        {
            if (input.Length <= 2)
                return input;

            var builder = new StringBuilder();

            builder.Append(input[0]);

            for (int i = 1; i < input.Length - 1; i++)
            {
                builder.Append("#");
            }

            builder.Append(input[input.Length - 1]);

            return builder.ToString();
        }
    }
}