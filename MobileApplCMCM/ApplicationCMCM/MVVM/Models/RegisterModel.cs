using Newtonsoft.Json;

namespace ApplicationCMCM.MVVM.Models;

public class RegisterModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentificationNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
}
