using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMS.DB.Models;

public partial class AlekhyaEmployeeDbContext : DbContext
{
    public AlekhyaEmployeeDbContext()
    {
    }

    public AlekhyaEmployeeDbContext(DbContextOptions<AlekhyaEmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.0.0.27;Database=AlekhyaEmployeeDB;Integrated Security=true;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC0740EE7845");

            entity.ToTable("Department");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07D5D75116");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Uid, "UQ__Employee__C5B69A4BB0DE559C").IsUnique();

            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Uid)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__Depart__25518C17");

            entity.HasOne(d => d.Location).WithMany(p => p.Employees)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Employee__Projec__245D67DE");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Employee__Manage__2739D489");

            entity.HasOne(d => d.Project).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Employee__Projec__282DF8C2");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Employee__RoleId__2645B050");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC070C5CF648");

            entity.ToTable("Location");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC07D7F7871D");

            entity.ToTable("Project");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC0709038711");

            entity.ToTable("Role");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Roles)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Role__Department__5BE2A6F2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
