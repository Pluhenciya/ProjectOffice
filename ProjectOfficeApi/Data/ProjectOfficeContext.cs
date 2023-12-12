using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectOfficeApi.Models;

namespace ProjectOfficeApi.Data;

public partial class ProjectOfficeContext : DbContext
{
    public ProjectOfficeContext()
    {
    }

    public ProjectOfficeContext(DbContextOptions<ProjectOfficeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ProjectOffice;Integrated Security=True;User ID=DESKTOP-RKMQ39T\\vanya;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.HasIndex(e => e.Login, "UQ_Login").IsUnique();

            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
