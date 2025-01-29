using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatAndWhen.Data.Entities;
using Task = WhatAndWhen.Data.Entities.Task;

namespace WhatAndWhen.Data
{
    public class WhatAndWhenContext : DbContext
    {
        public WhatAndWhenContext(DbContextOptions<WhatAndWhenContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WhatAndWhen.db");
        }
    }
}