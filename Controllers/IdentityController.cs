using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("[controller]")]
public class IdentityController : Controller
{
    private UserManager<ApplicationUser> _userManager;
    private RoleManager<ApplicationRole> _roleManager;
    private SignInManager<ApplicationUser> _signInManager;

    private readonly TokenService _tokenService;

    public IdentityController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    //[Authorize]
    [HttpGet("all")]
    public IEnumerable<ApplicationUser> GetAllUsers()
    {
        return _userManager.Users.ToList();
    }

    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    [HttpPost("login")]
    public async Task<ActionResult<ApplicationUser>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null) return Unauthorized(new ApiResponse(401));

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

        return new ApplicationUser
        {
            Email = user.Email
        };
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Add MongoIdentityUser = Microsoft.AspNetCore.Identity
    [HttpPost("register")]
    public async Task<IdentityResult> Create(User user)
    {

        var newToken = new Token();

        newToken.Name = "Identity";
        newToken.Value = await _tokenService.CreateToken(user);

        var appUser = new ApplicationUser
        {
            UserName = user.Name,
            Email = user.Email,
            Tokens = new List<Token>() { newToken }
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

