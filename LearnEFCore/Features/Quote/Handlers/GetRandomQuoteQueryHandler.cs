using LearnEFCore.Application.Services;
using LearnEFCore.Features.Quote.Queries;

namespace LearnEFCore.Features.Quote.Handlers
{
    public class GetRandomQuoteQueryHandler : IQueryHandler<GetRandomQuoteQuery, string>
    {
        private readonly IQuoteService _quoteService;

        public GetRandomQuoteQueryHandler(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public async Task<string> Handle(GetRandomQuoteQuery query)
        {
            return await _quoteService.GetRandomQuoteAsync();
        }
    }
}