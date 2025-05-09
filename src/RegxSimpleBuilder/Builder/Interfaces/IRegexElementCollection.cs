namespace RegexSimpleBuilder;

/// <summary>
/// An object that can hold a collection of <see cref="IRegexElement"/> objects 
/// </summary>
public interface IRegexElementCollection
{
    /// <summary>
    /// Adds an <see cref="IRegexElement"/> to the collection
    /// </summary>
    /// <param name="element">The <see cref="IRegexElement"/> to add to the collection</param>
    void AddElement(IRegexElement element);
}
