using System.ComponentModel.DataAnnotations.Schema;

namespace MotocycleManagement.Domain.Models;

public record MotocycleModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    [Column("Production_Year")]
    public int ProductionYear { get; set; }
    public Guid BrandId { get; set; }
    public virtual Brand? Brand { get; set; }
}
