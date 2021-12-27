using Microsoft.EntityFrameworkCore;
using P7.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using P7.Shared.Models;
namespace P7.Server.DB
{
    public class ClothDbContext : DbContext
    {
        public ClothDbContext(DbContextOptions<ClothDbContext> options)
        : base(options)
        {}
        public DbSet<Cloth> Clothes { get; set; }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
