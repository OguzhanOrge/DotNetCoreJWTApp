using AutoMapper;
using JWTCQRSProject.Api.Core.Application.Dto;
using JWTCQRSProject.Api.Core.Application.Features.CQRS.Queries;
using JWTCQRSProject.Api.Core.Application.Interfaces;
using JWTCQRSProject.Api.Core.Domain;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandlers : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;
        public GetAllProductsQueryHandlers(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return  mapper.Map<List<ProductListDto>>(data);
        }
    }
}
