using Microsoft.AspNetCore.Mvc;
using NetCoreWithRedis.Dtos;
using NetCoreWithRedis.Services.BusyBooks;
using NetCoreWithRedis.Services.Redis;

namespace NetCoreWithRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusyBooksController(IRedisService redisService, IBusyBooksService busyBooksService) : ControllerBase
    {
        private readonly IRedisService _redisService = redisService;
        private readonly IBusyBooksService _busyBooksService = busyBooksService;

        /// <summary>list Busy Books</summary>
        /// <remarks>It is possible return list Busy Books.</remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBusyBooks()
        {
            try
            {
                string recordKey = $"BusyBooks_{DateTime.Now:yyyyMMdd_hhmm}";
                var response = await _redisService.GetData<BusyBookDto>(recordKey);
                if (response != null)
                {
                    return Ok(response);
                }
                var busyBooksResponse = await _busyBooksService.GetBusyBooks();
                await _redisService.SetData(recordKey, busyBooksResponse);
                return Ok(busyBooksResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
