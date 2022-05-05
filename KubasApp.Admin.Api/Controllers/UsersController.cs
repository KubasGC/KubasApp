using KubasApp.Admin.Api.Controllers.Base;
using KubasApp.Admin.Api.DTOs;
using KubasApp.Database.Context;
using KubasApp.Database.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KubasApp.Admin.Api.Controllers;

public class UsersController : KubasAppController
{
    private readonly PostgresDbContext _dbContext;

    public UsersController(PostgresDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _dbContext.Users.AsNoTracking().ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        
        
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequestDto request)
    {
        var user = new UserDbModel
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            EmailAddress = request.Email,
            FirstName = "Jakub",
            LastName = "Skakuj",
            PasswordHash = request.Password,
            SecondName = "Kacper",
            DateCreatedUtc = DateTime.UtcNow
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return Created("/users/" + user.Id, user);
    }
}