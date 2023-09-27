namespace TodoApp.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedDateUtc { get; private init; } = DateTime.UtcNow;
    public bool WasCompleted { get; private init; } = false;
}
