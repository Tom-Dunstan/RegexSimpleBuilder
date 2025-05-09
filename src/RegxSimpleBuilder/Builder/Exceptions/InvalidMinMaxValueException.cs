namespace RegexSimpleBuilder;

public sealed class InvalidMinMaxValueException(uint minimum, uint maximum) : Exception
{
    public override string Message { get; } = $"Supplied maximum value ({maximum}) must be less than supplied minimum ({minimum})";
}