using Microsoft.AspNetCore.Mvc;
using NetCoreWithRedis.Dtos;
using NetCoreWithRedis.Services.Books;
using NetCoreWithRedis.Services.Redis;

namespace NetCoreWithRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IRedisService redisService, IBooksService booksService) : ControllerBase
    {
        private readonly IRedisService _redisService = redisService;
        private readonly IBooksService _booksService = booksService;

        /// <summary>list Books</summary>
        /// <remarks>It is possible return list Books.</remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                string recordKey = $"Books_{DateTime.Now:yyyyMMdd_hhmm}";
                var response = await _redisService.GetData<BookDto>(recordKey);
                if (response != null)
                {
                    return Ok(response);
                }
                var booksResponse = await _booksService.GetBooks();
                await _redisService.SetData(recordKey, booksResponse);
                return Ok(booksResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
