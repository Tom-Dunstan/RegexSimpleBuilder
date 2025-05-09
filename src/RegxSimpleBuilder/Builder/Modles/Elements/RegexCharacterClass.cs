namespace RegexSimpleBuilder;

public class RegexCharacterClass : IRegexElement
{
    private readonly string         _classDefinition;
    private readonly bool           _negated;
    public RegexCharacterClass(string          classDefinition
                             , IRegexRepeater? repeater = default
                             , bool            negated  = false)
    {
        if (string.IsNullOrEmpty(classDefinition))
        {
            throw new ArgumentException($"The parameter {nameof(classDefinition)} must be a string of at least 1 character in length"
                                      , nameof(classDefinition));
        }

        _classDefinition = classDefinition;
        _negated         = negated;
        Repeater         = repeater ?? IRegexRepeater.Default;
    }
    private          IRegexRepeater Repeater { get; }

    public ReadOnlySpan<char> Render()
    {
        ReadOnlySpan<char> escaped = _classDefinition.Replace("]", @"\]")
                                                    .ToCharArray();

        return $"[{(_negated ? "^" : string.Empty)}{escaped}]{Repeater.Render()}";
    }
}