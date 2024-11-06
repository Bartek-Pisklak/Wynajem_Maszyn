using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;
using WynajemMaszyn.Application.Features.Excavators.Command.CreateExcavators;

namespace WynajemMaszyn.Application.UnitTests.Excavators.TestUtils
{
    public class CreateExcavatorCommandUtils
    {
        public static CreateExcavatorCommand CreateExcavatorCommand() =>
            new CreateExcavatorCommand(
                    Constants.Excavator.Name,
                    Constants.Excavator.Type,
                    Constants.Excavator.TypeChassis,
                    Constants.Excavator.RentalPricePerDay,

                    Constants.Excavator.ProductionYear,
                    Constants.Excavator.OperatingHours,
                    Constants.Excavator.Weight,
                    Constants.Excavator.Engine,

                    Constants.Excavator.EnginePower,
                    Constants.Excavator.DrivingSpeed,
                    Constants.Excavator.FuelConsumption,
                    Constants.Excavator.FuelType,

                    Constants.Excavator.Gearbox,
                    Constants.Excavator.MaxDiggingDepth,
                    Constants.Excavator.ImagePath,
                    Constants.Excavator.Description
            );

    }
}
