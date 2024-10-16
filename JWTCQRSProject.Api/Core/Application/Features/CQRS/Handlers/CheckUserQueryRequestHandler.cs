using JWTCQRSProject.Api.Core.Application.Dto;
using JWTCQRSProject.Api.Core.Application.Features.CQRS.Queries;
using JWTCQRSProject.Api.Core.Application.Interfaces;
using JWTCQRSProject.Api.Core.Domain;
using MediatR;

namespace JWTCQRSProject.Api.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public CheckUserQueryRequestHandler(IRepository<AppRole> appRoleRepository, IRepository<AppUser> appUserRepository)
        {
            _appRoleRepository = appRoleRepository;
            _appUserRepository = appUserRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Username = user.Username;
                dto.IsExist = true;
                dto.Id = user.Id;
                var role = await _appRoleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Defination;
            }
            return dto;
        }
    }
}
