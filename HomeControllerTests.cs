using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MvcUniversity.Tests
{
    public class HomeControllerTests
    : IClassFixture<WebApplicationFactory<mvcTodo.Startup>>
    {
        private readonly WebApplicationFactory<mvcTodo.Startup> _factory;

        public HomeControllerTests(WebApplicationFactory<mvcTodo.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        [InlineData("/Environnement")]
        [InlineData("/Plante")]
        [InlineData("/Besoins")]
        [InlineData("/Besoins/Details/1")]


        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
