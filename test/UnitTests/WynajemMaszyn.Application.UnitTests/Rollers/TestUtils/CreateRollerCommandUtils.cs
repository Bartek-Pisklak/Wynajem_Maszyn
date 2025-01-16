using WynajemMaszyn.Application.Features.Rollers.Command.CreateRollers;
using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;

namespace WynajemMaszyn.Application.UnitTests.Rollers.TestUtils
{
    public class CreateRollerCommandUtils
    {
        public static CreateRollerCommand CreateRollerCommand() =>
            new CreateRollerCommand(
                Constants.Excavator.mockHttpContext.Object,
                Constants.Roller.Name,
                Constants.Roller.ProductionYear,
                Constants.Roller.OperatingHours,
                Constants.Roller.Weight,
                Constants.Roller.Engine,
                Constants.Roller.EnginePower,
                Constants.Roller.DrivingSpeed,
                Constants.Roller.FuelConsumption,
                Constants.Roller._FuelType,
                Constants.Roller.Gearbox,
                Constants.Roller.NumberOfDrums,
                Constants.Roller._RollerType,
                Constants.Roller.DrumWidth,
                Constants.Roller.MaxCompactionForce,
                Constants.Roller.IsVibratory,
                Constants.Roller.KnigeAsfalt,
                Constants.Roller.RentalPricePerDay,
                Constants.Roller.ImagePath,
                Constants.Roller.Description
            );
    }
}
