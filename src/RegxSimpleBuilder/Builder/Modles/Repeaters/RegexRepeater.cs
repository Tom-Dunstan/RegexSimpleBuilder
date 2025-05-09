namespace RegexSimpleBuilder;

/// <summary>
/// Renders a 
/// </summary>
/// <param name="atLeastOne"></param>
/// <param name="isLazy"></param>
public class RegexRepeater(bool atLeastOne = false, bool isLazy = false) : IRegexRepeater
{
    private const char   ONE_OR_MORE  = '+';
    private const char   NONE_OR_MORE = '*';
    private const string LAZY         = "?";

    private char   RepeaterSymbol => atLeastOne ? ONE_OR_MORE : NONE_OR_MORE;
    private string LazySymbol     => isLazy ? LAZY : string.Empty;

    public ReadOnlySpan<char> Render() { return $"{RepeaterSymbol}{LazySymbol}"; }
}

