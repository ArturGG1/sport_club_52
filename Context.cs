using Microsoft.EntityFrameworkCore;

namespace sport_club_52;

public class SportClubContext : DbContext
{
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Cashier> Cashiers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=sportclub.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tariff>()
            .HasOne(t => t.Trainer)
            .WithMany()
            .HasForeignKey(t => t.TrainerId);
        modelBuilder.Entity<Client>()
            .HasOne(c => c.Membership)
            .WithMany()
            .HasForeignKey(c => c.MembershipId);
        modelBuilder.Entity<Membership>()
            .HasOne(m => m.Tariff)
            .WithMany()
            .HasForeignKey(m => m.TariffId);
        modelBuilder.Entity<Membership>()
            .HasOne(m => m.Payment)
            .WithMany()
            .HasForeignKey(m => m.PaymentId);
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Cashier)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.CashierId);
    }
}