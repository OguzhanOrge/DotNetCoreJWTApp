using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Definations { get; set; }
    }
}
