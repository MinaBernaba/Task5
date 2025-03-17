using BooksProject.Application.Features.Books.Queries.Responses;
using BooksProject.Application.ServiceInterfaces;
using BooksProject.Data.Entities;
using BooksProject.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksProject.Application.Services
{
    public class BookService(IBookRepository _bookRepository) : IBookService
    {
        public async Task<List<BookMainInfoResponse>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllNoTracking().Select(x => new BookMainInfoResponse()
            {
                Title = x.Title
            }).ToListAsync();
            return books;
        }

        public async Task<BookMainInfoResponse> GetBookByIdAsync(int bookId)
            => await _bookRepository.GetAllNoTracking()
            .Where(x => x.BookId == bookId)
            .Select(x => new BookMainInfoResponse()
            {
                Title = x.Title
            }).FirstAsync();

        public async Task<bool> IsBookExistByTitleAsync(string title) => await _bookRepository.IsExistAsync(x => x.Title.ToLower() == title);

        public async Task<bool> IsExistAsync(int bookId) => await _bookRepository.IsExistAsync(x => x.BookId == bookId);

        public async Task<bool> AddBookAsync(Book book)
        {
            return await _bookRepository.AddAsync(book);
        }
        public async Task<bool> UpdateBookAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }
        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            return await _bookRepository.DeleteAsync(book);
        }
    }
}
