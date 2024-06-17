using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_BodyBuilder.ApplicationData;

public partial class GymtoDbContext : DbContext
{
    public GymtoDbContext()
    {
    }

    public GymtoDbContext(DbContextOptions<GymtoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DailyStatisticHealth> DailyStatisticHealths { get; set; }

    public virtual DbSet<DailyStatisticTraining> DailyStatisticTrainings { get; set; }

    public virtual DbSet<ExercisesView> ExercisesViews { get; set; }

    public virtual DbSet<PhysElement> PhysElements { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

    public virtual DbSet<TrainingPhysElement> TrainingPhysElements { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IgorPc\\SQLEXPRESS; Database=GymtoDb; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DailyStatisticHealth>(entity =>
        {
            entity.HasKey(e => e.StatisticHealthId);

            entity.ToTable("DailyStatisticHealth");

            entity.Property(e => e.StatisticHealthId).HasColumnName("statistic_health_id");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.SpentTime)
                .HasPrecision(0)
                .HasColumnName("spent_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.DailyStatisticHealths)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailyStatisticHealth_Users");
        });

        modelBuilder.Entity<DailyStatisticTraining>(entity =>
        {
            entity.HasKey(e => e.StatisticTrainingId).HasName("PK_DailyCompletedTrainings");

            entity.Property(e => e.StatisticTrainingId).HasColumnName("statistic_training_id");
            entity.Property(e => e.Completed).HasColumnName("completed");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.TrainingId).HasColumnName("training_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Training).WithMany(p => p.DailyStatisticTrainings)
                .HasForeignKey(d => d.TrainingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DailyCompletedTrainings_Trainings");
        });

        modelBuilder.Entity<ExercisesView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ExercisesView");

            entity.Property(e => e.CoverImage).HasColumnName("cover_image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PhysElementId).HasColumnName("phys_element_id");
            entity.Property(e => e.RequiredTime)
                .HasPrecision(0)
                .HasColumnName("required_time");
            entity.Property(e => e.TrainingElementId).HasColumnName("training_element_id");
            entity.Property(e => e.TrainingId).HasColumnName("training_id");
        });

        modelBuilder.Entity<PhysElement>(entity =>
        {
            entity.Property(e => e.PhysElementId).HasColumnName("phys_element_id");
            entity.Property(e => e.CoverImage).HasColumnName("cover_image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.RequiredTime)
                .HasPrecision(0)
                .HasColumnName("required_time");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.Property(e => e.TrainingId).HasColumnName("training_id");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CoverImage).HasColumnName("cover_image");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.TrainingTime)
                .HasPrecision(0)
                .HasColumnName("training_time");

            entity.HasOne(d => d.Category).WithMany(p => p.Training)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainings_Categories");
        });

        modelBuilder.Entity<TrainingPhysElement>(entity =>
        {
            entity.HasKey(e => e.TrainingElementId);

            entity.Property(e => e.TrainingElementId).HasColumnName("training_element_id");
            entity.Property(e => e.PhysElementId).HasColumnName("phys_element_id");
            entity.Property(e => e.TrainingId).HasColumnName("training_id");

            entity.HasOne(d => d.PhysElement).WithMany(p => p.TrainingPhysElements)
                .HasForeignKey(d => d.PhysElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingPhysElements_PhysElements");

            entity.HasOne(d => d.Training).WithMany(p => p.TrainingPhysElements)
                .HasForeignKey(d => d.TrainingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingPhysElements_Trainings");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
