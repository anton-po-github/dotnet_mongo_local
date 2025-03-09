using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>
{
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

