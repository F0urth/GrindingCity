namespace Domain.Building.Command;

using CSharpFunctionalExtensions;
using MediatR;

public record RemoveBuildingById(Guid Id) : IRequest<Result<Unit, string>>;