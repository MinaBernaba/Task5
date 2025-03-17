using BooksProject.Data.Entities;
using BooksProject.Infrastructure.Context;
using BooksProject.Infrastructure.Interfaces;

namespace BooksProject.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
    }
}
