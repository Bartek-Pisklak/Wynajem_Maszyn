using ErrorOr;

namespace WynajemMaszyn.Application.Common.Errors
{
    public static partial class Error
    {
        public static class Harvester
        {
            public static ErrorOr.Error NotEnoughData => ErrorOr.Error.Conflict(
            code: "not enough information",
            description: "not enough information"
                );

            public static ErrorOr.Error UserDoesNotLogged => ErrorOr.Error.Conflict(
                code: "You does not logged!",
                description: "You should loggin before action!"
                );

            public static ErrorOr.Error NotDataToDisplay => ErrorOr.Error.Conflict(
                code: "Data error",
                description: "You have not data to dispaly"
                );
        }

    }
}
