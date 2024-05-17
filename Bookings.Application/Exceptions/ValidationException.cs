using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Application.Exceptions;
public class ValidationException : Exception
{
    List<ValidationFailure> Errors { get; set; } = [];

    public ValidationException(List<ValidationFailure> errors)
    {
        Errors = errors;
    }
} 
