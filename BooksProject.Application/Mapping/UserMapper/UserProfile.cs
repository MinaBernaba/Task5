﻿using AutoMapper;

namespace BooksProject.Application.Mapping.UserMapper
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            RegisterUser();
        }
    }
}
