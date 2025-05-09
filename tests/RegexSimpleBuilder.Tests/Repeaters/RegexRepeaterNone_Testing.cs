namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class RegexRepeaterNone_Testing
{
    public class Render(ITestOutputHelper output)
    {
        [Fact]
        public void When_Called_Then_ReturnCorrectString()
        {
            // Arrange
            var nullRepeater              = new RegexRepeaterNone();
            var nullRepeaterFromInterface = IRegexRepeater.Default;

            // Action
            var render = nullRepeater.Render()
                                     .ToString();
            var renderInterface = nullRepeaterFromInterface.Render()
                                                           .ToString();
            output.WriteFormated("Render",           render);
            output.WriteFormated("Interface Render", renderInterface);

            // Assert
            render.Should()
                  .BeEmpty();
            renderInterface.Should()
                           .BeEmpty();
        }
    }
}