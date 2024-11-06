using Moq;
using FluentAssertions;
using WynajemMaszyn.Application.Features.Excavators.Command.EditExcavators;
using WynajemMaszyn.Application.UnitTests.TestUtils.Constants;

namespace WynajemMaszyn.Application.UnitTests.Excavators.TestUtils
{
    public class EditExcavatorCommandUtils
    {

        public static EditExcavatorCommand EditExcavatorCommand() =>
            new EditExcavatorCommand(
                Constants.Excavator.Id,
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
