using NetCoreWithRedis.Dtos;

namespace NetCoreWithRedis.Services.BusyBooks;

public interface IBusyBooksService
{
    Task<List<BusyBookDto>> GetBusyBooks();
}