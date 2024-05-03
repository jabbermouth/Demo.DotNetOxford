namespace Demo.DotNetOxford.Blog;

public class BlogRepository : IBlogRepository
{
    public IEnumerable<BlogDto> Posts()
    {
        return
        [
            new BlogDto { Title = "Hello World", Content = "Welcome to my blog!" },
            new BlogDto { Title = "Goodbye World", Content = "Thanks for reading!" }
        ];
    }
}
