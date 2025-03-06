using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("[controller]")]
public class IdentityController : Controller
{
    private UserManager<ApplicationUser> _userManager;

    private RoleManager<ApplicationRole> _roleManager;

    public IdentityController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Add MongoIdentityUser = Microsoft.AspNetCore.Identity
    [HttpPost("user")]
    public async Task<IdentityResult> Create(User user)
    {
        ApplicationUser appUser = new ApplicationUser
        {
            UserName = user.Name,
            Email = user.Email,
            // Tokens = List<>
        };

        IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

        // await userManager.AddToRoleAsync(appUser, "Admin");

        if (result.Succeeded)
            ViewBag.Message = "User Created Successfully";
        else
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        return result;
    }

    [HttpPost("role")]
    public async Task<IdentityResult> CreateRole([Required] Role role)
    {
        IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole() { Name = role.Name });
        if (result.Succeeded)
            ViewBag.Message = "Role Created Successfully";
        else
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        return result;
    }
}

