using System.Text;

namespace RegexSimpleBuilder;

public enum RegexGroupType
{
    Capturing,
    NonCapturing,
    Named,
    Atomic
}

public class RegexGroup : IRegexGroup
{
    private readonly RegexGroupType      _groupType;
    private readonly string?             _name;
    private readonly List<IRegexElement> _elements = [];
    private readonly IRegexRepeater      _repeater;

    public RegexGroup(
        RegexGroupType? groupType = RegexGroupType.Capturing
      , string?         name      = default
      , IRegexRepeater? repeater  = default)
    {
        if (groupType == RegexGroupType.Named && string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), $"If {nameof(groupType)} is {nameof(RegexGroupType.Named)}, then argument {nameof(name)} cannot be null, empty, or whitespace");
        }

        _groupType = groupType ?? RegexGroupType.Capturing;
        _name      = name;

        _repeater = repeater ?? IRegexRepeater.Default;

    }

    public RegexGroup(RegexGroupType groupType, 
                      IRegexRepeater? repeater = default)
        : this(groupType: groupType
             , name: default
             , repeater: repeater)
    {
    }

    public void AddElement(IRegexElement element) { _elements.Add(element); }

    public ReadOnlySpan<char> Render()
    {
        if (_elements.Count == 0)
        {
            throw new MissingGroupElementsException();
        }
        
        const string openBrackets    = "(";
        const char   closingBrackets = ')';

        StringBuilder builder = new(openBrackets);
        builder.Append(GetGroupPrefix());
        
        StringBuilder groupRenderer = new(); 
        _elements.ForEach(element => groupRenderer.Append(element.Render()));

        if (groupRenderer.Length == 0)
        {
            throw new MissingGroupElementsException();
        }
        
        builder.Append(groupRenderer);
        
        builder.Append(closingBrackets);
        builder.Append(_repeater.Render());

        return builder.ToString();

        ReadOnlySpan<char> GetGroupPrefix()
        {
            const string nonCapturing = "?:";

            switch (_groupType)
            {
                case RegexGroupType.NonCapturing: return nonCapturing;
                case RegexGroupType.Named:        return $"?<{_name}>";
                case RegexGroupType.Atomic:       return $"?>";
                case RegexGroupType.Capturing:
                default:
                    return string.Empty;
            }
        }
    }
}