using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PackIt.Infrastructure.PackingList.EF;

internal class PackingListDbContext : DbContext
{
    public DbSet<Domain.Entities.PackingList> PackingLists { get; set; }

	public PackingListDbContext(DbContextOptions<PackingListDbContext> options) : base(options)
    {
    }

	protected override void OnModelCreating(ModelBuilder builder)
	{
        builder
            .HasDefaultSchema("packing")
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
