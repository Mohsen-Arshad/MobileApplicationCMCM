using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ApplicationCMCM.MVVM.Models;

public class UserModel
{

    public int id { get; set; }

    [MinLength(3)]
    [MaxLength(30)]
    public string? FirstName { get; set; }

    [MinLength(3)]
    [MaxLength(30)]
    public string? LastName { get; set; }

    public string? IdentificationNumber { get; set; }

    [EmailAddress]
    public string? EmailAddress { get; set; }

    [PasswordPropertyText]
    public string? Password { get; set; }
}
