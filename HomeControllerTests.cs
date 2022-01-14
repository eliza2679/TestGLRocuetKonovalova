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
        [InlineData("/Besoins/Create")]
        [InlineData("/Besoins/Delete/1")]
        [InlineData("/Besoins/Edit/1")]
        [InlineData("/Environnement/Create")]
        [InlineData("/Environnement/Details/1")]
        [InlineData("/Environnement/Delete/1")]
        [InlineData("/Environnement/Edit/1")]
        [InlineData("/Plante/Create")]
        [InlineData("/Plante/Details/1")]
        [InlineData("/Plante/Delete/1")]
        [InlineData("/Plante/Edit/1")]


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
