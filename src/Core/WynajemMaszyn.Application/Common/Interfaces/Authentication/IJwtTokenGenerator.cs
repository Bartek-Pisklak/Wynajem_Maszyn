﻿namespace WynajemMaszyn.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(int userId, string firstName, string lastName, string permission);
}