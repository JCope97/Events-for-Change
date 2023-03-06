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
    //Get information

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<MapAppUser> MapAppUsers { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<UserEventList> UserEventLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MapAppConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC2726B95BDA");

            entity.HasOne(d => d.Organization).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk EventType ID");

            entity.HasOne(d => d.OrganizationNavigation).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk Organzation ID");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventTyp__3214EC27C715A1DA");
        });

        modelBuilder.Entity<MapAppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MapAppUs__3214EC27085551E5");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organzat__3214EC27E4991DB4");
        });

        modelBuilder.Entity<UserEventList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEven__3214EC27DEE07ADF");

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
