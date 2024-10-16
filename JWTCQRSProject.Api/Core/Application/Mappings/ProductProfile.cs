using AutoMapper;
using JWTCQRSProject.Api.Core.Application.Dto;
using JWTCQRSProject.Api.Core.Domain;

namespace JWTCQRSProject.Api.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
