using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserRoles.Models;

namespace UserRoles.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuración de Tablas
            builder.Entity<TicketStatus>().ToTable("TablaTicketStatus");
            builder.Entity<TicketPriority>().ToTable("TablaTicketPriority");

            // Configuración de Users
            builder.Entity<Users>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<Users>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Configuración de TicketStatus
            builder.Entity<TicketStatus>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<TicketStatus>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<TicketStatus>()
                .HasIndex(ts => ts.Name)
                .IsUnique();

            // Configuración de TicketPriority
            builder.Entity<TicketPriority>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<TicketPriority>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Entity<TicketPriority>()
                .HasIndex(tp => tp.Name)
                .IsUnique();

        }
    }
}