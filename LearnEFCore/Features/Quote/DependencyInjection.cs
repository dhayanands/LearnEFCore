using LearnEFCore.Application.Services;
using LearnEFCore.Features.Quote.Handlers;
using LearnEFCore.Features.Quote.Queries;

namespace LearnEFCore.Features.Quote
{
    public static class QuoteFeatureExtensions
    {
        public static IServiceCollection AddQuoteFeature(this IServiceCollection services)
        {
            // Register Quote feature services
            services.AddScoped<IQuoteService, QuoteService>();

            // Register query handlers
            services.AddScoped<IQueryHandler<GetRandomQuoteQuery, string>, GetRandomQuoteQueryHandler>();

            return services;
        }
    }
}