using AutoMapper;
using Lsoc.Core.Models;
using Lsoc.Core.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Lsoc.API.Mapping;

public class LsocMappingProfile : Profile
{
    public LsocMappingProfile()
    {
        CreateMap<CreatePostViewModel, Post>();
        CreateMap<Post, PostViewModel>()
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));

        CreateMap<IdentityUser, UserViewModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.NormalizedUsername, opt => opt.MapFrom(src => src.NormalizedUserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.NormalizedEmail));
    }
}