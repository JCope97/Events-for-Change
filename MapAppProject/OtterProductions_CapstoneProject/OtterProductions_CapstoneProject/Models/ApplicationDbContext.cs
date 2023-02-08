using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Organzation> Organzations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserEventList> UserEventLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC27D5C3107F");

            entity.HasOne(d => d.Organzation).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk Organzation ID");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventTyp__3214EC277C4891D4");
        });

        modelBuilder.Entity<Organzation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organzat__3214EC27BD00E3BF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC273079B92B");
        });

        modelBuilder.Entity<UserEventList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEven__3214EC2775F410E3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
