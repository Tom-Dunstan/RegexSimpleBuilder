namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class RegexText_Testing
{
    public class Render(ITestOutputHelper output)
    {
        [Fact]
        public void When_TextHasSpecialCharacters_Then_ReturnsEscapedString()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"This Is a Test.+*?^$()[]{}|\"
                         , Expected = @"This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\"
                       };

            RegexText regexText = new(data.Test);

            // Action
            output.WriteFormated("Input Text", data.Test);
            var result = regexText.Render()
                                  .ToString();
            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Expected);
            result.Should()
                  .NotBe(data.Test, "Text must be escaped");
        }

        [Fact]
        public void When_TextHasNoSpecialCharacters_Then_ReturnsSameString()
        {
            // Arrange
            var data = new
                       {
                           Test = @"This Is a Test 0123456789"
                       };

            RegexText regexText = new(data.Test);

            // Action
            output.WriteFormated("Input Text", data.Test);
            var result = regexText.Render()
                                  .ToString();
            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Test);
        }

        [Fact]
        public void When_EmptyString_Then_ReturnsSameString()
        {
            // Arrange
            var data = new
                       {
                           Test = string.Empty
                       };

            RegexText regexText = new(data.Test);

            // Action
            output.WriteFormated("Input Text", data.Test);
            var result = regexText.Render()
                                  .ToString();
            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Test);
        }
    }
}