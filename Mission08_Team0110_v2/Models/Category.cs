using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0110_v2.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}