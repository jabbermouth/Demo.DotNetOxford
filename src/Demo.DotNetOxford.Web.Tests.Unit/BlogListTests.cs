using Bunit;
using Demo.DotNetOxford.Blog;
using Demo.DotNetOxford.Web.Components.Shared;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Demo.DotNetOxford.Web.Tests.Unit;

public class BlogListTests : TestContext
{
    [Fact]
    public void OnRender_DisplayNoBlogsAvailable_WhenNoBlogs()
    {
        // Arrange
        IEnumerable<BlogDto> blogs = [];
        var blogRepository = Substitute.For<IBlogRepository>();
        blogRepository.Posts().Returns(blogs);

        Services.AddSingleton<IBlogRepository>(blogRepository);

        // Act
        var sut = RenderComponent<BlogList>();

        // Assert
        sut.FindAll("p").Count().Should().Be(1);
        sut.Find("p").MarkupMatches("<p>No blogs available</p>");
    }

    [Fact]
    public void OnRender_DisplayBlogs_WhenBlogsAvailable()
    {
        // Arrange
        IEnumerable<BlogDto> blogs = new[]
        {
            new BlogDto { Title = "Blog 1", Content = "Content for blog 1" },
            new BlogDto { Title = "Blog 2", Content = "Content for blog 2" }
        };
        var blogRepository = Substitute.For<IBlogRepository>();
        blogRepository.Posts().Returns(blogs);

        Services.AddSingleton<IBlogRepository>(blogRepository);

        // Act
        var sut = RenderComponent<BlogList>();

        // Assert
        var divs = sut.FindAll("div");
        divs.Count.Should().Be(2);
        divs[0].MarkupMatches("<div><h2>Blog 1</h2><p>Content for blog 1</p></div>");
        divs[1].MarkupMatches("<div><h2>Blog 2</h2><p>Content for blog 2</p></div>");
    }
}
