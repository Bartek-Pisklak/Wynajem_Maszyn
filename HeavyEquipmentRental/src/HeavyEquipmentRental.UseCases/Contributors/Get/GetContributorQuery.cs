using Ardalis.Result;
using Ardalis.SharedKernel;

namespace HeavyEquipmentRental.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
