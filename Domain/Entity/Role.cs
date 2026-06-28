namespace Domain.Entity;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
}