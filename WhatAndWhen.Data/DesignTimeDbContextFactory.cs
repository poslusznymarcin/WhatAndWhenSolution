using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WhatAndWhen.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WhatAndWhenContext>
    {
        public WhatAndWhenContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WhatAndWhenContext>();
            optionsBuilder.UseSqlite("Data Source=WhatAndWhen.db");
            return new WhatAndWhenContext(optionsBuilder.Options);
        }
    }
}