namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class ITestOutputHelperExtensions
{
    private const string OUTPUT_TEXT_FORMAT = "{0}: \"{1}\"";
    private const string OUTPUT_VALUE_FORMAT = "{0}: {1}";

    public static void WriteFormated(this ITestOutputHelper output, string header, string value)
    {
        output.WriteLine(OUTPUT_TEXT_FORMAT, header, value);
    }

    public static void WriteFormated(this ITestOutputHelper output, string header, bool value)
    {
        output.WriteLine(OUTPUT_VALUE_FORMAT, header, value);
    }

    public static void WriteFormated(this ITestOutputHelper output, string header, object value)
    {
        output.WriteLine(OUTPUT_VALUE_FORMAT, header, value);
    }
}