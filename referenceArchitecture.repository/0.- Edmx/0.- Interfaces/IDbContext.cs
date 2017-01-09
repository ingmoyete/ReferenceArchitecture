using referenceArchitecture.repository._0.__Edmx;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referenceArchitecture.repository.Edmx.Interfaces
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        DbSet<Example> Examples { get; set; }
    }
}
