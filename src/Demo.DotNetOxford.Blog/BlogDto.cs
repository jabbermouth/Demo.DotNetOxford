namespace Demo.DotNetOxford.Blog;

public record BlogDto
{
    public required string Title { get; init; }
    public required string Content { get; init; }
}
