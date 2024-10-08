using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Contracts.HarversterAnswer
{
    public record HarvesterRequest
    (
        int Id,
        string Name,
        DateTime ProductionYear,
        int OperatingHours,
        int Weight,
        int Engine,
        int EnginePower,
        int DrivingSpeed,
        string Description
    );
}
