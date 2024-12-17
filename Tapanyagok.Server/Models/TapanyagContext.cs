using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Tapanyagok.Server.Models;

public partial class TapanyagContext : DbContext
{
    public TapanyagContext()
    {
    }

    public TapanyagContext(DbContextOptions<TapanyagContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tapanyag> tapanyagok { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user id=root;database=tapanyag", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Tapanyag>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
