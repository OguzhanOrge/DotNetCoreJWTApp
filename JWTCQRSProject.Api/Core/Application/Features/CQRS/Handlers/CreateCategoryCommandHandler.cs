using JWTCQRSProject.Api.Core.Application.Features.CQRS.Commands;
using JWTCQRSProject.Api.Core.Application.Interfaces;
using JWTCQRSProject.Api.Core.Domain;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Category()
            {
                Definations = request.Definations,
            });
            return Unit.Value;
        }
    }
}
