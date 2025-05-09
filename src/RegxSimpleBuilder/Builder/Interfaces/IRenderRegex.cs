namespace RegexSimpleBuilder;

/// <summary>
/// An object that can render to a raw regex search
/// </summary>
public interface IRenderRegex
{
    /// <summary>
    /// Renders the element as a raw regex search
    /// </summary>
    /// <returns>A string representing the regex segment of the element</returns>
    ReadOnlySpan<char> Render();
}