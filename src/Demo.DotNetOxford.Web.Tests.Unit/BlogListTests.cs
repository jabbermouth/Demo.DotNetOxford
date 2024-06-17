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
}
