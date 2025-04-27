using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RO.DevTest.Application.Contracts.DTOs;
using RO.DevTest.Domain.Abstract;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Application.Common.Exceptions;
using RO.DevTest.Application.Contracts.Services;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IRepositorioUsuario repositorioUsuario, ITokenService tokenService)
        {
            _repositorioUsuario = repositorioUsuario;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repositorioUsuario.ObterPorNomeUsuarioAsync(request.Username);

            if (usuario == null)
                throw new NotFoundException("Usuário não encontrado");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
                throw new UnauthorizedException("Senha inválida");

            if (!usuario.Ativo)
                throw new UnauthorizedException("Usuário inativo");

            var token = _tokenService.GenerateToken(usuario);

            return new LoginResponse
            {
                Token = token,
                Usuario = new UsuarioDto
                {
                    Id = usuario.Id,
                    NomeUsuario = usuario.UserName,
                    Email = usuario.Email,
                    Funcao = usuario.Funcao
                }
            };
        }
    }
}
