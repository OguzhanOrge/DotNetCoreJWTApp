using JWTCQRSProject.Api.Core.Application.Features.CQRS.Commands;
using JWTCQRSProject.Api.Core.Application.Interfaces;
using JWTCQRSProject.Api.Core.Domain;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var unchangedProduct = await repository.GetByIdAsync(request.Id);
            if (unchangedProduct != null) 
            {
                unchangedProduct.Name = request.Name;
                unchangedProduct.Price = request.Price;
                unchangedProduct.CategoryId = request.CategoryId;
                unchangedProduct.Stock = request.Stock;
                await repository.UpdateAsync(unchangedProduct);
            }
            return Unit.Value;
        }
    }
}
