using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Features.Rollers.Queries.DTOs;

public class GetRollerDto
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public string Name { get; set; }

    public int ProductionYear { get; set; }
    public int OperatingHours { get; set; }
    public int Weight { get; set; }
    public float RentalPricePerDay { get; set; }

    public int Engine { get; set; }
    public int EnginePower { get; set; }
    public int DrivingSpeed { get; set; }
    public int FuelConsumption { get; set; }
    public string FuelType { get; set; }
    public string Gearbox { get; set; }

    public int NumberOfDrums { get; set; }
    public string RollerType { get; set; }
    public int DrumWidth { get; set; }
    public int MaxCompactionForce { get; set; }
    public bool IsVibratory { get; set; }
    public bool KnigeAsfalt { get; set; }

    public string Description { get; set; }

}
