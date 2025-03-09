namespace YallaHaggz.Domain.Utilities;

using System.ComponentModel.DataAnnotations;

public static class Check
{
    public static void NotNull<T>(T value, string name)
    {
        if (value is null)
        {
            throw new ValidationException($"{name} cannot be null.");
        }
    }

    public static void NotEmpty(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ValidationException($"{name} cannot be empty.");
        }
    }

    public static void Email(string value, string name)
    {
        if (!new EmailAddressAttribute().IsValid(value))
        {
            throw new ValidationException($"{name} is not a valid email address.");
        }
    }

    public static void MaxLength(string value, int length, string name)
    {
        if (value.Length > length)
        {
            throw new ValidationException($"{name} cannot be longer than {length} characters.");
        }
    }

    public static void MinLength(string value, int length, string name)
    {
        if (value.Length < length)
        {
            throw new ValidationException($"{name} cannot be shorter than {length} characters.");
        }
    }

    public static void NotDefault<T>(T value, string name)
    {
        if (value.Equals(default(T)))
        {
            throw new ValidationException($"{name} cannot be the default value.");
        }
    }

    public static void NotFuture(DateTime value, string name)
    {
        if (value > DateTime.UtcNow)
        {
            throw new ValidationException($"{name} cannot be in the future.");
        }
    }

    public static void NotNegative(int value, string name)
    {
        if (value < 0)
        {
            throw new ValidationException($"{name} cannot be negative.");
        }
    }

    public static void FixedLength(string value, int length, string name)
    {
        if (value.Length != length)
        {
            throw new ValidationException($"{name} must be {length} characters long.");
        }
    }

    public static void FixedLength<T>(T[] value, int length, string name)
    {
        if (value.Length != length)
        {
            throw new ValidationException($"{name} must have {length} elements.");
        }
    }

    public static void FixedLength<T>(IEnumerable<T> value, int length, string name)
    {
        if (value.Count() != length)
        {
            throw new ValidationException($"{name} must have {length} elements.");
        }
    }

    public static void InRange(decimal value, decimal min, decimal max, string name)
    {
        if (value < min || value > max)
        {
            throw new ValidationException($"{name} must be between {min} and {max}.");
        }
    }

    public static void InRange(int value, int min, int max, string name)
    {
        if (value < min || value > max)
        {
            throw new ValidationException($"{name} must be between {min} and {max}.");
        }
    }

    public static void DateRange(DateTime value, DateTime minDate, DateTime maxDate, string name)
    {
        if (value < minDate || value > maxDate)
        {
            throw new ValidationException($"{name} must be between {minDate} and {maxDate}.");
        }
    }

    public static void NotNullOrEmpty<T>(IEnumerable<T> value, string name)
    {
        if (value is null || !value.Any())
        {
            throw new ValidationException($"{name} cannot be null or empty.");
        }
    }

    public static void NotEmpty(Guid value, string name)
    {
        if (value == Guid.Empty)
        {
            throw new ValidationException($"{name} cannot be empty.");
        }
    }
}