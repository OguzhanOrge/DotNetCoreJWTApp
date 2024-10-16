using JWTCQRSProject.Api.Core.Application.Dto;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}
