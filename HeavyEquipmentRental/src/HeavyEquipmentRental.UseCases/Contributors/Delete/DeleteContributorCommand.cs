using Ardalis.Result;
using Ardalis.SharedKernel;

namespace HeavyEquipmentRental.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
