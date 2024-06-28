using AutoMapper;
using Bookings.Application.Abstractions.Database;
using Bookings.Application.Exceptions;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Users.ChangePassword;
public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
{
    private readonly IApplicationContext _applicationContext;
    private readonly IUserRepository _userRepository;
    private readonly ChangePasswordUserValidation _validations;

    public ChangePasswordCommandHandler(
        IApplicationContext applicationContext,
        IUserRepository userRepository
       )
    {
        _applicationContext = applicationContext;
        _userRepository = userRepository;
        _validations = new ChangePasswordUserValidation();
    }
    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validations.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }


        var user = await _applicationContext.Users
             .FirstOrDefaultAsync(c => c.Email == request.ChangePasswordDto.Email, cancellationToken);

        if (user is null)
        {
            throw new Exception("Wrong Email! ");
        }

        bool isIdentical = BCrypt.Net.BCrypt
            .EnhancedVerify(request.ChangePasswordDto.Password, user.Password);

        if (!isIdentical)
        {
            throw new Exception("Incorrect Password");
        }

        var newPassword = BCrypt.Net.BCrypt.
                EnhancedHashPassword(request.ChangePasswordDto.NewPassword, 13);

        user.ChangePassword(newPassword);

        _userRepository.Update(user);

        await _applicationContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
