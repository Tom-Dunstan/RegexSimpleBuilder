namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class RegexRaw_Testing
{
    public class Render(ITestOutputHelper output)
    {
        [Fact]
        public void When_TextHasSpecialCharacters_Then_ReturnsSameString()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"This Is a Test.+*?^$()[]{}|\"
                         , Expected = @"This Is a Test.+*?^$()[]{}|\"
                       };

            var regexText = new RegexRaw(data.Test);

            // Action
            output.WriteFormated("Input Text", data.Test);
            var result = regexText.Render()
                                  .ToString();
            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Expected);
        }
    }
}