namespace RegexSimpleBuilder;

/// <summary>
/// A set of extension methods to add elements  
/// </summary>
// ReSharper disable once InconsistentNaming
public static class IRegexElementCollectionExtensions
{

    /// <summary>
    /// Adds a <see cref="RegexRaw"/> element to the collection
    /// </summary>
    /// <param name="collection">The collection to add the <see cref="RegexRaw"/></param>
    /// <param name="rawRegex">The raw regex string to add</param>
    /// <returns>a reference to the <see cref="IRegexElementCollection"/></returns>
    public static IRegexElementCollection AddRawText(this IRegexElementCollection collection, string rawRegex)
    {
        collection.AddElement(new RegexRaw(rawRegex));
        return collection;
    }

    /// <summary>
    /// Adds a <see cref="RegexText"/> element to the collection
    /// </summary>
    /// <param name="collection">The collection to add the <see cref="RegexText"/></param>
    /// <param name="text">The raw regex string to add</param>
    /// <returns>a reference to the <see cref="IRegexElementCollection"/></returns>
    public static IRegexElementCollection AddText(this IRegexElementCollection collection, string text)
    {
        collection.AddElement(new RegexText(text));
        return collection;
    }

    public static IRegexElementCollection AddCharacterClass(
        this IRegexElementCollection collection
      , string                       classDefinition
      , IRegexRepeater?              repeater = default
      , bool                         negated  = false)
    {
        collection.AddElement(new RegexCharacterClass(classDefinition
                                                    , repeater
                                                    , negated));
        return collection;
    }

    public static IRegexElementCollection AddGroup(this IRegexElementCollection collection, Action<IRegexGroup> groupFunction, RegexGroupType?  groupType = RegexGroupType.Capturing
                                                 , string?                      name     = default
                                                 , IRegexRepeater?              repeater = default)
    {
        var group = new RegexGroup(groupType: groupType
                                 , name: name
                                 , repeater: repeater);

        groupFunction.Invoke(group);

        collection.AddElement(group);

        return collection;
    }

    public static IRegexElementCollection AddStartAnchor(this IRegexElementCollection collection, bool isPermanent = false)
    {
        const string startAnchor     = "^";
        const string permanentAnchor = @"\A";

        var element = new RegexRaw(isPermanent ? permanentAnchor : startAnchor);

        collection.AddElement(element);

        return collection;

    }

    public static IRegexElementCollection AddEndAnchor(this IRegexElementCollection collection, bool isPermanent = false)
    {
        const string startAnchor     = "$";
        const string permanentAnchor = @"\Z";

        var element = new RegexRaw(isPermanent ? permanentAnchor : startAnchor);

        collection.AddElement(element);

        return collection;

    }

}