using ErrorOr;

namespace WynajemMaszyn.Application.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =>
            Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email is already taken");

        public static Error BadLoginData =>
            Error.Conflict(
                code: "User.BadLoginData", 
                description: "Wrong login or password");

        public static Error RequireConfirmedAccount =>
            Error.Conflict(
                code: "User.RequireConfirmedAccount",
                description: "Confirm Account");

        public static Error WeakPassword =>
            Error.Conflict(
                code: "User.WeakPassword",
                description: "The provided password is too weak");

        public static Error AccountLocked =>
            Error.Conflict(
                code: "User.AccountLocked",
                description: "Your account has been locked due to multiple failed login attempts");

        public static Error UnknownError(string details) =>
            Error.Conflict(
                code: "User.UnknownError",
                description: $"An unknown error occurred: {details}");
    }
}