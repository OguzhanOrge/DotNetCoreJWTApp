using AutoMapper;
using JWTCQRSProject.Api.Core.Application.Dto;
using JWTCQRSProject.Api.Core.Domain;

namespace JWTCQRSProject.Api.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryListDto>().ReverseMap();
        }
    }
}
