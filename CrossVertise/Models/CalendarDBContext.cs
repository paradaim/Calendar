using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrossVertise.Models
{
    public partial class CalendarDBContext : DbContext
    {
        public CalendarDBContext()
        {
        }

        public CalendarDBContext(DbContextOptions<CalendarDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAttendee> TblAttendees { get; set; } = null!;
        public virtual DbSet<TblAttendeesTask> TblAttendeesTasks { get; set; } = null!;
        public virtual DbSet<TblTask> TblTasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Server=.;Database=CalendarDB;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("server=157.90.138.111,2019;database=CalendarDB;uid=CalendarUser;pwd=CalendarUser;Max Pool Size=2024;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAttendee>(entity =>
            {
                entity.HasKey(e => e.AttenderId);

                entity.Property(e => e.AttenderId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("AttenderID")
                    .HasDefaultValueSql("('(NewID)')");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAttendeesTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TblAttendeesTask");

                entity.Property(e => e.AttenderId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("AttenderID");

                entity.Property(e => e.TaskId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("TaskID");

                entity.HasOne(d => d.Attender)
                    .WithMany()
                    .HasForeignKey(d => d.AttenderId)
                    .HasConstraintName("FK_TblAttendeesTask_TblAttendees");

                entity.HasOne(d => d.Task)
                    .WithMany()
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_TblAttendeesTask_TblTask");
            });

            modelBuilder.Entity<TblTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK_TblTask_1");

                entity.ToTable("TblTask");

                entity.Property(e => e.TaskId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("TaskID")
                    .HasDefaultValueSql("('(NewID)')");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Organizer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
