using Ardalis.Result;
using Ardalis.SharedKernel;

namespace HeavyEquipmentRental.UseCases.Contributors.List;

public record ListContributorsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ContributorDTO>>>;
