namespace Demo.DotNetOxford.Blog;

public interface IBlogRepository
{
    IEnumerable<BlogDto> Posts();
}