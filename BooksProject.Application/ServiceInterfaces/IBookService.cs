using BooksProject.Application.Features.Books.Queries.Responses;
using BooksProject.Data.Entities;

namespace BooksProject.Application.ServiceInterfaces
{
    public interface IBookService
    {
        Task<List<BookMainInfoResponse>> GetAllBooksAsync();
        Task<BookMainInfoResponse> GetBookByIdAsync(int BookId);
        Task<bool> IsBookExistByTitleAsync(string BookName);
        Task<bool> IsExistAsync(int BookId);
        Task<bool> AddBookAsync(Book Book);
        Task<bool> UpdateBookAsync(Book Book);
        Task<bool> DeleteBookAsync(int BookId);
    }
}
