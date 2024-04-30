using NetCoreWithRedis.Dtos;

namespace NetCoreWithRedis.Services.Books;

public interface IBooksService
{
    Task<List<BookDto>> GetBooks();
    Task<bool> SetBook(BookDto value);
}