using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string? Definations { get; set; }
    }
}
