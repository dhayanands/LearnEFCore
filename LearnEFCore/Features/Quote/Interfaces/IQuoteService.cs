namespace LearnEFCore.Features.Quote
{
    public interface IQuoteService
    {
        Task<string> GetRandomQuoteAsync();
    }
}