using AutoMapper;
using Lsoc.Core.Models;
using Lsoc.Core.ViewModels;

namespace Lsoc.API.Mapping;

public class LsocMappingProfile : Profile
{
    public LsocMappingProfile() => CreateMap<CreatePostViewModel, Post>();
}