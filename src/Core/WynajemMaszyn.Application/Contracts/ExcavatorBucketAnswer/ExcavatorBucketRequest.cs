using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WynajemMaszyn.Application.Contracts.ExcavatorBucketAnswer;

public record ExcavatorBucketRequest(
    int Id,
    string Name,
    string BucketType,
    int ProductionYear,
    int BucketCapacity,
    int Weight,
    int Width,
    int PinDiameter,
    int ArmWidth,
    int PinSpacing,
    string Material,
    int MaxLoadCapacity,
    float RentalPricePerDay,
    //string CompatibleExcavators,
    string ImagePath,
    string Description,
     bool IsRepair
    );
