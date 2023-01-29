using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SeBook.DataAccess.Data;
using SeBook.DataAccess.Repository;
using SeBook.Models;

namespace SeBook.UnitTests
{
    public class TestShoppingCartRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _options;
        private readonly TestShoppingCartRepository _repository;
        private readonly ShoppingCart _shoppingCartTest;

        public TestShoppingCartRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestShoppingCartDb")
                .Options;

            _repository = new TestShoppingCartRepository(_options);
            _shoppingCartTest = new ShoppingCart()
            {
                Count = 25
            };
        }

        [Fact]
        public void TestDecrementCount()
        {
            var count = 5;
            var result = _repository.DecrementCount(_shoppingCartTest, count);
            Assert.Equal(_shoppingCartTest.Count, result);
        }

        [Fact]
        public void TestIncrementCount()
        {
            var count = 5;
            var result = _repository.IncrementCount(_shoppingCartTest, count);
            Assert.Equal(_shoppingCartTest.Count, result);
        }
    }
}