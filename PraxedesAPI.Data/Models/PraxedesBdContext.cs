using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PraxedesAPI.Data.Models;

public partial class PraxedesBdContext : DbContext
{
    //public PraxedesBdContext()
    //{
    //}

    public PraxedesBdContext(DbContextOptions<PraxedesBdContext> options): base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Body).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Body).IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
