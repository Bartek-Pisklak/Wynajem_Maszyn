﻿using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WynajemMaszyn.Application.Common.Interfaces.Authentication;

namespace WynajemMaszyn.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions, IHttpContextAccessor contextAccessor)
    {
        _jwtSettings = jwtOptions.Value;
        _httpContextAccessor = contextAccessor;
    }



    public string GenerateToken(int userId, string firstName, string lastName, string permission)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, $"{firstName} {lastName}"),
            new Claim("Permission", permission)
        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes);

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: expires,
            signingCredentials: cred
            );


        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}