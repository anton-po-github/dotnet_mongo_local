using System.ComponentModel.DataAnnotations;

public class User
{
    required
    public string Name
    { get; set; }

    [EmailAddress(ErrorMessage = "Invalid Email")]
    required
    public string Email
    { get; set; }

    required
    public string Password
    { get; set; }
}

public class Role
{
    required
    public string Name
    { get; set; }
}

