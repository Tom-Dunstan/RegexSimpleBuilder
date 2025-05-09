namespace RegexSimpleBuilder;

/// <summary>
/// Represents the default regex repeater where the repeater is not to be rendered 
/// </summary>
/// <remarks>This does not render any regex. It is used to represent the default/null object for a repeater property</remarks>
public class RegexRepeaterNone : IRegexRepeater
{
    public ReadOnlySpan<char> Render() => string.Empty;
}