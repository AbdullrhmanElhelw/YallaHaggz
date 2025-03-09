namespace YallaHaggz.Domain.Abstractions;

public interface IDomainDataSeeder
{
    Task SeedEssentialDataAsync();
}