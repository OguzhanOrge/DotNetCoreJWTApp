using AutoMapper;
using JWTCQRSProject.Api.Core.Application.Dto;
using JWTCQRSProject.Api.Core.Application.Features.CQRS.Queries;
using JWTCQRSProject.Api.Core.Application.Interfaces;
using JWTCQRSProject.Api.Core.Domain;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper mapper;

        public GetProductQueryHandler(IMapper mapper, IRepository<Product> repository)
        {
            this.mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return mapper.Map<ProductListDto>(data);
        }
    }
}
