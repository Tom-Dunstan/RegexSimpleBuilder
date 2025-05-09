namespace RegexSimpleBuilder;

/// <summary>
/// A simple block of text to search for. The characters in the suplied text are treated as literal characters
/// </summary>
/// <remarks>Any special characters in the text string will be escaped when rendering</remarks>
/// <param name="text">The text string to search for with Regex</param>
public class RegexText(string text) : IRegexElement
{
    public ReadOnlySpan<char> Render() => EscapeString(text);

    /// <summary>
    /// List of special characters in Regex that must be escaped to be literal
    /// </summary>
    private static readonly char[] SpecialCharacters = [ '.', '+', '*', '?', '^', '$', '(', ')', '[', ']', '{', '}', '|', '\\'];

    /// <summary>
    /// Escapes any special characters in a supplied <seealso cref="ReadOnlySpan{T}"/>
    /// </summary>
    /// <param name="text2Esc">The text to escape</param>
    /// <returns>A <see cref="ReadOnlySpan{T}"/></returns>
    private static ReadOnlySpan<char> EscapeString(ReadOnlySpan<char> text2Esc)
    {
        if (text2Esc.Length == 0)
        {
            return string.Empty.AsSpan();
        }

        if (!text2Esc.ContainsAny(SpecialCharacters))
        {
            return text2Esc;
        }

        var output = new char[text2Esc.Length * 2];
        var size   = 0;

        foreach (var character in text2Esc)
        {
            if (SpecialCharacters.Contains(character))
            {
                output[size] = '\\';
                size++;
            }

            output[size] = character;
            size++;
        }

        ReadOnlySpan<char> returnValue = output.ToArray();

        return returnValue[..size];
    }
}