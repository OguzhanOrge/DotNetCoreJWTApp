using AutoMapper;
using JWTCQRSProject.Api.Core.Application.Dto;
using JWTCQRSProject.Api.Core.Application.Features.CQRS.Queries;
using JWTCQRSProject.Api.Core.Application.Interfaces;
using JWTCQRSProject.Api.Core.Domain;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;
        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByIdAsync(request.Id);
            return mapper.Map<CategoryListDto>(data);
        }
    }
}
