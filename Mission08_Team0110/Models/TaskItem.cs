using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0110.Models;

public class TaskItem
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    [MaxLength(200)]
    public string TaskName { get; set; }

    public DateTime? DueDate { get; set; }

    [Required]
    [Range(1, 4)]
    public int Quadrant { get; set; }

    public bool Completed { get; set; } = false;

    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }

    public Category? Category { get; set; }
}