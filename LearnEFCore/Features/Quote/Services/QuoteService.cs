namespace LearnEFCore.Features.Quote
{
    public class QuoteService : IQuoteService
    {
        private static readonly Random _random = new Random();

        public async Task<string> GetRandomQuoteAsync()
        {
            var quotesPath = Path.Combine(Directory.GetCurrentDirectory(), "Shared", "Common", "quotes.txt");
            var quotes = await File.ReadAllLinesAsync(quotesPath);
            if (quotes.Length == 0)
            {
                throw new InvalidOperationException("No quotes available.");
            }
            return quotes[_random.Next(quotes.Length)];
        }
    }
}