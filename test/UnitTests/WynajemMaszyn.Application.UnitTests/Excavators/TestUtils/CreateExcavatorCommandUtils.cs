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
                Constants.Excavator.mockHttpContext.Object,
                    Constants.Excavator.Name,
                    Constants.Excavator._TypeExcavator,
                    Constants.Excavator._TypeChassis,
                    Constants.Excavator.RentalPricePerDay,

                    Constants.Excavator.ProductionYear,
                    Constants.Excavator.OperatingHours,
                    Constants.Excavator.Weight,
                    Constants.Excavator.Engine,

                    Constants.Excavator.EnginePower,
                    Constants.Excavator.DrivingSpeed,
                    Constants.Excavator.FuelConsumption,
                    Constants.Excavator._FuelType,

                    Constants.Excavator.Gearbox,
                    Constants.Excavator.MaxDiggingDepth,
                    Constants.Excavator.ImagePath,
                    Constants.Excavator.Description
            );

    }
}
