namespace IrentaFormTestBackend.Data;

using System.Globalization;
using IrentaFormTestBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class ApplicationDbContext: DbContext
{
    public DbSet<OwnershipFormModel> OwnershipFormModels { get; set; } = null!;
    public DbSet<OwnershipBankDetails> OwnershipBankDetailsEnumerable { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OwnershipBankDetails>()
            .Property(e => e.CheckingAccount)
            .HasConversion(new BigIntegerConverter())
            .HasMaxLength(20);;
        modelBuilder.Entity<OwnershipBankDetails>()
            .Property(p => p.CorrespondentAccount)
            .HasConversion(new BigIntegerConverter())
            .HasMaxLength(20);;
    }

}