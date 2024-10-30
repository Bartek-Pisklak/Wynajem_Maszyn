using ErrorOr;
using MediatR;
using WynajemMaszyn.Application.Common.Errors;
using WynajemMaszyn.Application.Persistance;
using WynajemMaszyn.Domain.Entities;
using WynajemMaszyn.Application.Contracts.Authentication;

namespace WynajemMaszyn.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResponse>>
{
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var isExist = _userRepository.Any(request.Email);
        if (isExist)
        {
            return Errors.User.DuplicateEmail;
        }


        var user = new User
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password
        };

        var id = _userRepository.Add(user);

        return new RegisterResponse(id);
    }
}