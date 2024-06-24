using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Domain.Users;
public class User
{
    public User(Guid id, string firstName, string lastName, string email,
        string password, DateTime createdOnUtc)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedOnUtc = createdOnUtc;
    }

    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

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
