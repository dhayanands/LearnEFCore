using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Quote.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LearnEFCore.Features.Quote.Controllers
{
    [ApiController]
    [Route("quotes")]
    public class RandomQuoteController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public RandomQuoteController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var quote = await _dispatcher.Send(new GetRandomQuoteQuery());
            return Ok(new { Quote = quote });
        }
    }
}