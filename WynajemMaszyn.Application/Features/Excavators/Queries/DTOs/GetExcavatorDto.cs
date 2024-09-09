namespace WynajemMaszyn.Application.Features.Excavators.Queries.DTOs
{
    public class GetExcavatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int ProductionYear { get; set; }
        public int OperatingHours { get; set; }
        public int Weight { get; set; }

        public string Engine { get; set; }
        public int EnginePower { get; set; }
        public int DrivingSpeed { get; set; }

    }
}
