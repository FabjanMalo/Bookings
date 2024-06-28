using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Users;
public class User(Guid id, string firstName, string lastName, string email,
    string password, DateTime createdOnUtc)
{
    [Key]
    public Guid Id { get; set; } = id;
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;

    public DateTime CreatedOnUtc { get; private set; } = createdOnUtc;

    public static User CreateUser(UserDto userDto)
    {
        Guid id = Guid.NewGuid();

        DateTime data = DateTime.UtcNow;

        return new User(id, userDto.FirstName, userDto.LastName,
            userDto.Email, userDto.Password, data);
    }
    public void ChangePassword(string newPassword)
    {
        Password = newPassword;
    }

}
