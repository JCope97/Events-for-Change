using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OtterProductions_CapstoneProject.Models;

namespace OtterProductions_CapstoneProject.Data;

public partial class MapAppDbContext : DbContext
{
    public MapAppDbContext()
    {
    }

    public MapAppDbContext(DbContextOptions<MapAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Organzation> Organzations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserEventList> UserEventLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MapAppConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC2754C62FC4");

            entity.HasOne(d => d.Organzation).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk Organzation ID");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventTyp__3214EC27BCBCF9E3");
        });

        modelBuilder.Entity<Organzation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organzat__3214EC27C1074F9F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27C1068E42");
        });

        modelBuilder.Entity<UserEventList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEven__3214EC27CA176C9E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
