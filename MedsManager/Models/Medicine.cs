using System.ComponentModel.DataAnnotations;

namespace MedsManager.Models;

public class Medicine
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string Description { get; set; }
}
