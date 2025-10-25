using LearnEFCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnEFCore.Presentation.Controllers
{
    [ApiController]
    [Route("quotes")]
    public class RandomQuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public RandomQuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var quote = await _quoteService.GetRandomQuoteAsync();
                return Ok(new { Quote = quote });
            }
            catch (InvalidOperationException)
            {
                return NotFound("No quotes available.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}