using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0110.Models;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ---- Category rules ----
        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();

        // Seed categories (dropdown)
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Home" },
            new Category { CategoryId = 2, Name = "School" },
            new Category { CategoryId = 3, Name = "Work" },
            new Category { CategoryId = 4, Name = "Church" }
        );

        // ---- Task rules ----
        modelBuilder.Entity<TaskItem>()
            .Property(t => t.TaskName)
            .HasMaxLength(200)
            .IsRequired();

        // Relationship: Category 1 -> many Tasks (CategoryId optional)
        modelBuilder.Entity<TaskItem>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        // DB-level constraints/defaults
        modelBuilder.Entity<TaskItem>()
            .Property(t => t.Completed)
            .HasDefaultValue(false);

        modelBuilder.Entity<TaskItem>()
            .ToTable(t => t.HasCheckConstraint("CK_Tasks_Quadrant", "Quadrant IN (1,2,3,4)"));
    }
}