using System.Text.RegularExpressions;

namespace RegexSimpleBuilder;

// ReSharper disable once InconsistentNaming
public static class IRegexBuilderExtensions
{
    public static IRegexBuilder SetCompiled(this IRegexBuilder builder)
    {
        builder.SetOptions(RegexOptions.Compiled);
        return builder;
    }

    public static IRegexBuilder SetIgnoreCase(this IRegexBuilder builder)
    {
        builder.SetOptions(RegexOptions.IgnoreCase);
        return builder;
    }

}