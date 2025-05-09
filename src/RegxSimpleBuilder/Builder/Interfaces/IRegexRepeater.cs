namespace RegexSimpleBuilder;

/// <summary>
/// Represents how a regex element can be repeated in a search
/// </summary>
public interface IRegexRepeater : IRenderRegex
{
    /// <summary>
    /// Returns an instance of the default repeater
    /// </summary>M
    public static IRegexRepeater Default { get; } = new RegexRepeaterNone();

    /// <summary>
    /// Returns a repeater that finds none or more match
    /// </summary>
    /// <remarks>This repeater is a singleton</remarks>
    public static IRegexRepeater NoneOrMore { get; } = new RegexRepeater();

    /// <summary>
    /// Returns a repeater that finds one or more match
    /// </summary>
    /// <remarks>This repeater is a singleton</remarks>
    public static IRegexRepeater AtLeastOne { get; } = new RegexRepeater(atLeastOne: true);

    /// <summary>
    /// Returns a repeater that finds none or more match with a lazy search
    /// </summary>
    /// <remarks>This repeater is a singleton</remarks>
    public static IRegexRepeater NoneOrMoreLazy { get; } = new RegexRepeater(isLazy: true);

    /// <summary>
    /// Returns a repeater that finds one or more match with a lazy search
    /// </summary>
    /// <remarks>This repeater is a singleton</remarks>
    public static IRegexRepeater AtLeastOneLazy { get; } = new RegexRepeater(atLeastOne: true, isLazy: true);

    /// <summary>
    /// Returns a repeater that matches optional, i.e. one or no times
    /// </summary>
    /// <remarks>This repeater is a singleton</remarks>
    public static IRegexRepeater Optional { get; } = new RegexOptional();

    /// <summary>
    /// Returns a repeater that matches exactly number of repeats
    /// </summary>
    /// <param name="number">The number of repeats to match</param>
    /// <returns>An <see cref="IRegexRepeater"/></returns>
    public static IRegexRepeater Exact(uint number) => new RegexRepeaterExact(number);

    /// <summary>
    /// Returns a repeater that matches at least a minimum number of repeats
    /// </summary>
    /// <param name="minimum">The minimum number of repeats</param>
    /// <remarks>If the value for minimum is either 0 or 1 then NoneOrMore or AtLeastOne are called instead</remarks>
    /// <returns>An <see cref="IRegexRepeater"/></returns>
    public static IRegexRepeater AtLeast(uint minimum)
    {
        if (minimum == 0)
        {
            return NoneOrMore;
        }

        return minimum == 1
                   ? AtLeastOne
                   : new RegexRepeaterLimited(minimum, unlimited: true);
    }

    /// <summary>
    /// Returns a repeater that matches a range of repeats
    /// </summary>
    /// <param name="minimum">The minimum number of repeats to match</param>
    /// <param name="maximum">The maximum number of repeats to match</param>
    /// <returns>An <see cref="IRegexRepeater"/></returns>
    public static IRegexRepeater Range(uint minimum, uint maximum)
        => minimum == 0 && maximum == 1
               ? Optional
               : minimum == maximum
                   ? new RegexRepeaterExact(minimum)
                   : new RegexRepeaterLimited(minimum, maximum);
}