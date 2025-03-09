namespace YallaHaggz.Domain.Abstractions;

public abstract class Entity : IAuditableEntity, ISoftDeleteEntity
{
    protected Entity()
    {
        CreatedOnUtc = DateTime.UtcNow;
        ModifiedOnUtc = CreatedOnUtc;
    }

    public int Id { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? ModifiedOnUtc { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime? DeletedOnUtc { get; private set; }

    public void Update()
    {
        ModifiedOnUtc = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        DeletedOnUtc = DateTime.UtcNow;
    }

    public void Restore()
    {
        IsDeleted = false;
        DeletedOnUtc = null;
    }
}