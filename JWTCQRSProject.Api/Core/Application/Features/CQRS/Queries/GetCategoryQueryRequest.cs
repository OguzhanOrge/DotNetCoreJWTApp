using JWTCQRSProject.Api.Core.Application.Dto;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
