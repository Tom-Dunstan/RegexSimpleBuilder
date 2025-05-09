namespace RegexSimpleBuilder.Tests;

internal static class ElementRenderTesterExtension
{
    public static void TestElement(this IRegexElement element, string expectedRender, ITestOutputHelper? output = default)
    {
        // Action
        var render = element.Render()
                            .ToString();

        output?.WriteFormated("Rendered", render);
        output?.WriteFormated("Expected", expectedRender);
        
        // Assert
        render.Should()
              .Be(expectedRender);
    }
}