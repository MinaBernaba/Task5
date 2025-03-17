using AutoMapper;

namespace BooksProject.Application.Mapping.BookMapper
{
    public partial class BookProfile : Profile
    {
        public BookProfile()
        {
            AddBookMapper();
            UpdateBookMapper();
        }
    }
}
