using System.Threading.Tasks;
using InsulinResistanceApp.Server.Services;
using Xunit;

namespace InsulinResistanceApp.Server.TestExamples
{
    public class UnitTests
    {
        private readonly IProduktService _produktService;

        public UnitTests(IProduktService produktService)
        {
            _produktService = produktService;
        }
        // Test case for GetProduktAsync method
        [Fact]
        public async Task GetProduktAsync_Test()
        {
            // Arrange
            var produktId = 2;

            // Act
            var result = await _produktService.GetProduktAsync(produktId);

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal(2, result.Data.Id);
            Assert.Equal("Banany", result.Data.Nazwa);
            Assert.Equal(89, result.Data.kcal);
            Assert.Equal(23, result.Data.weglowodany);
            Assert.Equal(0, result.Data.tluszcze);
            Assert.Equal(1, result.Data.bialko);
            Assert.Equal(51, result.Data.indeksglikemiczny);
            Assert.Equal(1, result.Data.KategoriaId);
        }
        [Fact]
        public async Task GetProduktByCategory_Test()
        {
            // Arrange
            var categoryName = "Owoce";

            // Act
            var result = await _produktService.GetProduktByCategory(categoryName);

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.True(result.Data.All(p => p.Kategoria.Nazwa.ToLower() == categoryName.ToLower()));
        }

        [Fact]
        public async Task GetProduktAsync_NoProductId_Test()
        {

            // Act
            var result = await _produktService.GetProduktAsync();

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task GetProduktAsync_NonExistingProduct_Test()
        {
            // Arrange
            var nonExistingProduktId = 999;

            // Act
            var result = await _produktService.GetProduktAsync(nonExistingProduktId);

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.Equal("Przepraszamy, ten produkt nie istnieje.", result.Message);
        }


    }
}



