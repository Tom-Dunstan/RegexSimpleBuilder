namespace RegexSimpleBuilder;

/// <summary>
/// A repeater that matches on a limited range
/// </summary>
/// <remarks>In the special case where the minimum is 0 and the maximum is 1, the repeater is renders as an optional (i.e. "?")</remarks>
/// <remarks>If the maximum is not provided and unlimitedMax is false, the match is treated as an exact match on the minimum number of repeats</remarks>
public class RegexRepeaterLimited : IRegexRepeater
{
    private readonly uint  _minimum;
    private readonly uint? _maximum;
    private readonly bool  _unlimitedMax;

    public RegexRepeaterLimited(uint minimum) : this(minimum
                                                   , maximum: default
                                                   , unlimitedMax: false)
    {
    }

    public RegexRepeaterLimited(uint minimum, uint? maximum) : this(minimum
                                                                  , maximum
                                                                  , unlimitedMax: false)
    {
    }

    public RegexRepeaterLimited(uint minimum, bool unlimited) : this(minimum
                                                                   , maximum: default
                                                                   , unlimited)
    {
    }

    private RegexRepeaterLimited(
        uint  minimum
      , uint? maximum      = default
      , bool  unlimitedMax = false)
    {
        if (maximum < minimum)
        {
            throw new InvalidMinMaxValueException(minimum, maximum.Value);
        }

        if (maximum == minimum)
        {
            maximum      = null;
            unlimitedMax = false;
        }

        _minimum      = minimum;
        _maximum      = maximum;
        _unlimitedMax = unlimitedMax;
    }

    public ReadOnlySpan<char> Render()
    {
        if (_maximum is not null)
        {
            // A range of 0-1 is the same as and optional
            return _minimum == 0 && _maximum == 1
                       ? "?"
                       : $"{{{_minimum},{_maximum}}}";
        }

        return $"{{{_minimum}{(_unlimitedMax ? "," : string.Empty)}}}";
    }
}