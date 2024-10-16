using JWTCQRSProject.Api.Core.Application.Dto;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest : IRequest<ProductListDto>
    {
        public int Id { get; set; }
        public GetProductQueryRequest(int Id)
        {
            this.Id = Id;
        }

    }
}
