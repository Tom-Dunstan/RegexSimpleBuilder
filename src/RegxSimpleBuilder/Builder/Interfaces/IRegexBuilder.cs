using System.Text.RegularExpressions;

namespace RegexSimpleBuilder;

/// <summary>
/// Builder that can generate a Regex Object
/// </summary>
public interface IRegexBuilder
{
    /// <summary>
    /// Builds the regular expression as a string
    /// </summary>
    /// <remarks>Does not include options that may have been set</remarks>
    /// <returns></returns>
    string BuildString();

    /// <summary>
    /// Builds a Regex object from it's <see cref="IRegexElement"/> objects
    /// </summary>
    /// <returns>A <seealso cref="Regex"/></returns>
    Regex Build();

    /// <summary>
    /// Sets one or more <see cref="RegexOptions"/> to the builder
    /// </summary>
    /// <param name="options">The <see cref="RegexOptions"/> to add</param>
    IRegexBuilder SetOptions(RegexOptions options);
    
    /// <summary>
    /// Adds an <see cref="IRegexElement"/> to the collection
    /// </summary>
    /// <param name="addElementRequest">Callback method to add elements to the collection</param>
    IRegexBuilder AddElements(Action<IRegexElementCollection> addElementRequest);
}