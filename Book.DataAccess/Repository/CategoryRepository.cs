using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private BookShopDbContext _db;
        public CategoryRepository(BookShopDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
