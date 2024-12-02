using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Identity.Client;
using TestSqliteApi.Users;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<SqliteConnection>(
        sp =>
        {
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            return new SqliteConnection(connectionString);
        }
    );

    builder.Services.AddSingleton<IUserService, UserService>();

    builder.Services.AddRouting(
        services => { services.LowercaseUrls = true; }
    );

    builder.Services.AddControllers();
}


WebApplication app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options => { options.EnableTryItOutByDefault(); }
        );
    }

    // var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
    
    // Create Users table when the application starts
    using (var scope = app.Services.CreateScope())
    {
        var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
        await userService.CreateUsersTableAsync();
    }

    app.MapControllers();
}

app.Run();