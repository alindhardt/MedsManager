using System.ComponentModel.DataAnnotations;

namespace MedsManager.Models;

public class Medicine
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string Description { get; set; }

    public double DosePerUnit { get; set; }
    public MassUnit UnitOfMeasurement { get; set; }



    public string DosePerUnitText => $"{DosePerUnit} {AbbreviatedUnitOfMeasurement}";

    private string AbbreviatedUnitOfMeasurement => UnitOfMeasurement switch 
    {
        MassUnit.Microgram => "mcg",
        MassUnit.Milligram => "mg",
        MassUnit.Gram => "g",
        _ => throw new NotImplementedException()
    };
}
