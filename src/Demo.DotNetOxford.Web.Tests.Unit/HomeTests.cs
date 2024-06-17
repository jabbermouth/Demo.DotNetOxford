using Bunit;
using Demo.DotNetOxford.Blog;
using Demo.DotNetOxford.Web.Components.Pages;
using Demo.DotNetOxford.Web.Components.Shared;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Demo.DotNetOxford.Web.Tests.Unit;

public class HomeTests : TestContext
{
    [Fact]
    public void OnRender_DisplayBlogListComponent()
    {
        // Arrange
        var blogRepository = Substitute.For<IBlogRepository>();

        Services.AddSingleton<IBlogRepository>(blogRepository);

        // Act
        var sut = RenderComponent<Home>();

        // Assert
        sut.HasComponent<BlogList>().Should().BeTrue();
    }
}
