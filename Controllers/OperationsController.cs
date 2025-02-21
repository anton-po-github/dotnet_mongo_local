using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("[controller]")]
public class OperationsController : Controller
{
    private UserManager<ApplicationUser> userManager;

    private RoleManager<ApplicationRole> roleManager;

    public OperationsController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public ViewResult Create() => View();

    [HttpPost("user")]
    public async Task<IdentityResult> Create(User user)
    {
        ApplicationUser appUser = new ApplicationUser
        {
            UserName = user.Name,
            Email = user.Email,
            // Tokens = List<>
        };

        IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

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
        IdentityResult result = await roleManager.CreateAsync(new ApplicationRole() { Name = role.Name });
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

