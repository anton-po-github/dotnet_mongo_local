using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>
{
}

