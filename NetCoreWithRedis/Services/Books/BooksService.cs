using NetCoreWithRedis.Dtos;

namespace NetCoreWithRedis.Services.Books;

public class BooksService : IBooksService
{
    public async Task<List<BookDto>> GetBooks()
    {
        var books = new List<BookDto>();
        var booksStore = new List<BookDto>()
        {
            new BookDto()
            {
                IdBook = 1,
                Title = "Book 1",
                Edition = 22,
                Editorial = "Prueba 1",
                CreationAt = DateTime.Now,
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
            }, new BookDto()
            {
                IdBook = 2,
                Title = "Book 2",
                Edition = 33,
                Editorial = "Prueba 2",
                CreationAt = DateTime.Now,
                Authors = new List<AuthorDto>()
                {
                    new AuthorDto()
                        {
                            IdAuthor = 4,
                            Name = "Author 4",
                            Email = "author4@correo.com",
                            Phone = "123456789"
                        },
                    new AuthorDto()
                        {
                            IdAuthor = 3,
                            Name = "Author 3",
                            Email = "author3@correo.com",
                            Phone = "123456789"
                        }
                }
            }
        };
        books.AddRange(booksStore);
        return books;
    }

    public Task<bool> SetBook(BookDto value)
    {
        throw new NotImplementedException();
    }
}