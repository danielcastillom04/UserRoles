using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserRoles.Models;
using UserRoles.Models;


namespace UserRoles.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)

        {
        }
        protected override void OnModelCreating(ModelBuilder builder)

        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling
            base.OnModelCreating(builder);

            builder.Entity<TicketStatus>()
            .ToTable("TablaTicketStatus");

            builder.Entity<Users>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");  // SQL Server

            builder.Entity<Users>()
            .Property(u => u.UpdatedAt)
            .HasDefaultValueSql("GETUTCDATE()");  // SQL Server}

            builder.Entity<TicketStatus>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");  // SQL Server}
            
            builder.Entity<TicketStatus>()
            .Property(u => u.UpdatedAt)
            .HasDefaultValueSql("GETUTCDATE()");  // SQL Server}

            builder.Entity<TicketStatus>()
            .HasIndex(ts => ts.Name)
            .IsUnique();
        }
    }
}
