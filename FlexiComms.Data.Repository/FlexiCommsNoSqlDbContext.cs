using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Repository
{
    public class FlexiCommsNoSqlDbContext : DbContext
    {
        public FlexiCommsNoSqlDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
