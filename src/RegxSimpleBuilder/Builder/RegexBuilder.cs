using System.Text;
using System.Text.RegularExpressions;

namespace RegexSimpleBuilder;

internal class RegexCollection : IRegexElementCollection, IRenderRegex
{
    private readonly List<IRegexElement> _elements = [];

    public void AddElement(IRegexElement element)
    {
        _elements.Add(element);
    }

    public ReadOnlySpan<char> Render()
    {
        return _elements.Aggregate(new StringBuilder(),
                                   AddRenderedElement, 
                                   RenderRegexString);

        StringBuilder AddRenderedElement(StringBuilder builder, IRegexElement element) => builder.Append(element.Render());
        string        RenderRegexString(StringBuilder  builder) => builder.ToString();
    }
}

/// <inheritdoc />
public sealed class RegexBuilder : IRegexBuilder
{
    private readonly RegexCollection _elements = new();

    private RegexBuilder() {}

    public static RegexBuilder Create()
    {
        return new RegexBuilder();
    }
    
    public RegexOptions Options { get; private set; }

    public string BuildString() => _elements.Render().ToString();

    public Regex Build()
    {
        return new Regex(BuildString(), Options);
    }

    public IRegexBuilder SetOptions(RegexOptions options)
    {
        Options |= options;
        return this;
    }

    public IRegexBuilder AddElements(Action<IRegexElementCollection> addElementRequest)
    {
        addElementRequest.Invoke(_elements);
        return this;
    }
}