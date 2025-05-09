namespace RegexSimpleBuilder;

/// <summary>
/// Matches on an exact number of repeats
/// </summary>
/// <param name="number">The exact number of repeats to match on</param>
public class RegexRepeaterExact(uint number) : RegexRepeaterLimited(number)
{
}