using WynajemMaszyn.Application.Features.Rollers.Command.EditRollers;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;


namespace WynajemMaszyn.Application.UnitTests.Rollers.TestUtils
{
    public class EditRollerCommandUtils
    {

        public static EditRollerCommand EditRollerCommand() =>
            new EditRollerCommand(
                Constants.Roller.Id,
                Constants.Roller.Name,
                Constants.Roller.ProductionYear,
                Constants.Roller.OperatingHours,
                Constants.Roller.Weight,
                Constants.Roller.Engine,
                Constants.Roller.EnginePower,
                Constants.Roller.DrivingSpeed,
                Constants.Roller.FuelConsumption,
                Constants.Roller.FuelType,
                Constants.Roller.Gearbox,
                Constants.Roller.NumberOfDrums,
                Constants.Roller.RollerType,
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
