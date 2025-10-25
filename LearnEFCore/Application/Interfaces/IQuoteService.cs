namespace LearnEFCore.Application.Interfaces
{
    public interface IQuoteService
    {
        Task<string> GetRandomQuoteAsync();
    }
}