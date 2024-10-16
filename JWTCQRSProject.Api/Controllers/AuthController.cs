using JWTCQRSProject.Api.Core.Application.Features.CQRS.Commands;
using JWTCQRSProject.Api.Core.Application.Features.CQRS.Queries;
using JWTCQRSProject.Api.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace JWTCQRSProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            var result = await mediator.Send(request);
            return Created("",result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await mediator.Send(request);
            if (dto.IsExist)
            {
                
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adi ve sifre hatali");
            }
        }
    }
}
