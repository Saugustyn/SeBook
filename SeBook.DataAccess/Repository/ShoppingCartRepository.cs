using Microsoft.EntityFrameworkCore;
using SeBook.DataAccess.Data;
using SeBook.DataAccess.Repository.IRepository;
using SeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeBook.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AppDbContext _db;
        public ShoppingCartRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
