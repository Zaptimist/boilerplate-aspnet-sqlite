namespace TestSqliteApi.Users;

public record User
{
    public int Id { get; init; }
    public string Name { get; set; }
}