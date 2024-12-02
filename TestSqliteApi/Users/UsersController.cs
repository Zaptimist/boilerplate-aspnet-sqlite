using Microsoft.AspNetCore.Mvc;

namespace TestSqliteApi.Users;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [Route("/create-users-table")]
    public async Task<IActionResult> CreateUsersTable()
    {
        await userService.CreateUsersTableAsync();

        return Ok();
    }

    [HttpPost]
    [Route("/add-user")]
    public async Task<IActionResult> AddUser([FromQuery] string name)
    {
        await userService.AddUserAsync(name);

        return Ok();
    }

    [HttpGet]
    [Route("/users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userService.GetUsersAsync();
        
        return Ok(users);
    }

}