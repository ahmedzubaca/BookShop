﻿using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private BookShopDbContext _db;

        public ApplicationUserRepository(BookShopDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
