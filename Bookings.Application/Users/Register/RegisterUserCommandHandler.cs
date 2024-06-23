using BCrypt.Net;
using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using Bookings.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Users.Register;
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IApplicationContext _applicationContext;
    private readonly RegisterUserCommandValidation _validation ;


    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IApplicationContext applicationContext)
    {
        _userRepository = userRepository;
        _applicationContext = applicationContext;
        _validation = new RegisterUserCommandValidation();
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validation.Validate(request);

        if (!validationResult.IsValid) {

            throw new ValidationException(validationResult.Errors);
        }

        var uniqueUser = await _userRepository.IsEmailUnique(request.UserDto.Email, cancellationToken);

        if (!uniqueUser)
        {
            throw new Exception("Email is not unique. Try another!");
        }

       var password = request.UserDto.Password;

        request.UserDto.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);

        var user = User.CreateUser(request.UserDto);

        await _userRepository.Add(user);

        await _applicationContext.SaveChangesAsync(cancellationToken);

        return user.Id;

    }
}
