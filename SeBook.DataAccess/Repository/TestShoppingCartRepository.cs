using SeBook.DataAccess.Data;
using SeBook.DataAccess.Repository.IRepository;
using SeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeBook.DataAccess.Repository
{
    public class TestShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly List<ShoppingCart> _shoppingCarts;
        public TestShoppingCartRepository(AppDbContext db) : base(db)
        {
            _shoppingCarts = new List<ShoppingCart>();
        }
        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;
        }
        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;
        }

    }
}
