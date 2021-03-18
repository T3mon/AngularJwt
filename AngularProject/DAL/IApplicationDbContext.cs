using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IApplicationDbContext
    {
        public DbSet<User> User { get; set; }
    }
}
