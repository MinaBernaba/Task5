using BooksProject.Application.Features.Books.Commands.Models;
using BooksProject.Data.Entities;

namespace BooksProject.Application.Mapping.BookMapper
{
    public partial class BookProfile
    {
        public void UpdateBookMapper() => CreateMap<UpdateBookCommand, Book>();
    }
}
