using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WynajemMaszyn.Application.Contracts.HarversterAnswer;

namespace WynajemMaszyn.Application.Features.Harvesters.Command.CreateHarvesters
{
    public record CreateHarvesterCommand
    (
    string Name,
    int ProductionYear,
    int OperatingHours,
    int Weight,
    int EnginePower,
    string FuelType,
    int FuelConsumption,
    int MaxSpeed,
    int CuttingDiameter,
    int MaxReach,
    string WheelType,
    float RentalPricePerDay,
    string ImagePath,
    string Description

        ) : IRequest<ErrorOr<HarvesterResponse>>;
}
