namespace RegexSimpleBuilder;

/// <summary>
/// A regex element used to include raw regex code into the builder
/// </summary>
/// <remarks>This element is useful for including unaltered regex strings, particularly for regex code that isn't supported by the <see cref="RegexBuilder"/></remarks>
/// <param name="rawRegex"></param>
public class RegexRaw(string rawRegex) : IRegexElement
{
    /// <inheritdoc />
    public ReadOnlySpan<char> Render() => rawRegex.AsSpan();
}