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

    public virtual DbSet<MapAppUser> MapAppUsers { get; set; }

    public virtual DbSet<Organzation> Organzations { get; set; }

    public virtual DbSet<UserEventList> UserEventLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MapAppConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC272A212B70");

            entity.HasOne(d => d.Organzation).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk EventType ID");

            entity.HasOne(d => d.OrganzationNavigation).WithMany(p => p.Events)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk Organzation ID");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventTyp__3214EC270F2F6D67");
        });

        modelBuilder.Entity<MapAppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MapAppUs__3214EC27F5742517");
        });

        modelBuilder.Entity<Organzation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organzat__3214EC27DD2A7686");
        });

        modelBuilder.Entity<UserEventList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEven__3214EC27CD7A6CFC");

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
