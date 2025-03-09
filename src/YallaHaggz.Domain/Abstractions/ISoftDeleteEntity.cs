namespace YallaHaggz.Domain.Abstractions;

public interface ISoftDeleteEntity
{
    bool IsDeleted { get; }
    DateTime? DeletedOnUtc { get; }

    void Delete();

    void Restore();
}