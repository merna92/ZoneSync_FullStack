using ZoneSync.Domain.Enums;

namespace ZoneSync.Domain.ViewModels;

public class CropViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Season? Season { get; set; }
    public string? Category { get; set; }
    public IrrigationType? IrrigationType { get; set; }
    public int GrowthStagesCount { get; set; }

    public override string ToString()
    {
        return $"{Id} :: {Name} :: {Season} :: {IrrigationType}";
    }
}
