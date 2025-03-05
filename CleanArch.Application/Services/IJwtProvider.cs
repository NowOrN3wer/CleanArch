using CleanArch.Application.Features.Auth.Login;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Services;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}