using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        private IUserResolverService _userResolverService;

        public AppDbContext(DbContextOptions<AppDbContext> options, IUserResolverService userResolverService) : base(options)
        {
            _userResolverService = userResolverService;
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableBaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((AuditableBaseEntity)entityEntry.Entity).ModifiedAt = DateTime.Now;
                ((AuditableBaseEntity)entityEntry.Entity).ModifiedBy = _userResolverService.GetUserId();

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableBaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                    ((AuditableBaseEntity)entityEntry.Entity).CreatedBy = _userResolverService.GetUserId();
                }
            }

            return base.SaveChanges();  
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<IdentityUser> Users { get; set; }
    }
}
