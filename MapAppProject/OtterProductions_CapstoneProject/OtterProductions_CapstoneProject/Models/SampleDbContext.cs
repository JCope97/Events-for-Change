using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

public partial class SampleDbContext : DbContext
{
    public SampleDbContext()
    {
    }

    public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<MapAppUser> MapAppUsers { get; set; }

    public virtual DbSet<Organization> Organzations { get; set; }

    public virtual DbSet<UserEventList> UserEventLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MapAppConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC27F20A5B4D");

            entity.HasOne(d => d.Organization).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk EventType ID");

            entity.HasOne(d => d.OrganizationNavigation).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk Organzation ID");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventTyp__3214EC2790ABD178");
        });

        modelBuilder.Entity<MapAppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MapAppUs__3214EC272BA05FE5");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organzat__3214EC2713547959");
        });

        modelBuilder.Entity<UserEventList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEven__3214EC27E6E8AD72");

            entity.HasOne(d => d.Event).WithMany(p => p.UserEventLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk Event ID");

            entity.HasOne(d => d.MapAppUser).WithMany(p => p.UserEventLists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk MapAppUser ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
