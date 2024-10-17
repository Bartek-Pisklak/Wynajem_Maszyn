using ErrorOr;

namespace WynajemMaszyn.Application.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static ErrorOr.Error DuplicateEmail =>
            ErrorOr.Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already taken");

        public static ErrorOr.Error BadData =>
            ErrorOr.Error.Conflict(
                code:"User.BadData", 
                description: "Wrong login data");
    }
}