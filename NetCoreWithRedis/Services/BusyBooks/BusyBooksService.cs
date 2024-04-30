using NetCoreWithRedis.Dtos;

namespace NetCoreWithRedis.Services.BusyBooks;

public class BusyBooksService : IBusyBooksService
{
    public async Task<List<BusyBookDto>> GetBusyBooks()
    {
        var busyBooks = new List<BusyBookDto>();
        var busyBooksStore = new List<BusyBookDto>()
        {
            new BusyBookDto()
            {
                IdBusyBook = 1,
                CreationAt = DateTime.Now,
                Book = new List<BookDto>()
                {
                    new BookDto()
                    {
                        IdBook = 1,
                        Editorial = "",
                        Edition = 22,
                        Title = "Book 1",
                        Authors = new List<AuthorDto>()
                            {
                                new AuthorDto()
                                    {
                                        IdAuthor = 1,
                                        Name = "Author 1",
                                        Email = "author1@correo.com",
                                        Phone = "123456789"
                                    },
                                new AuthorDto()
                                    {
                                        IdAuthor = 2,
                                        Name = "Author 2",
                                        Email = "author2@correo.com",
                                        Phone = "123456789"
                                    }
                            }
                    }
                }
            }
        };
        busyBooks.AddRange(busyBooksStore);
        return busyBooks;
    }
}