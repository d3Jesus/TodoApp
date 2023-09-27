namespace TodoApp.Features.Get;

public record TodoResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool WasCompleted { get; set; } = false;
    public string ItemCssClass { get; set; } = string.Empty;
}
