using BooksProject.Application.Features.Authentication.Models;
using BooksProject.Data.Identity;

namespace BooksProject.Application.Mapping.UserMapper
{
    public partial class UserProfile
    {
        public void RegisterUser() => CreateMap<RegisterUserCommand, User>();
    }
}
