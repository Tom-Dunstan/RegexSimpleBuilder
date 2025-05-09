namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class IRegexElementCollectionExtensions_Testing
{
    public class AddText(ITestOutputHelper output)
    {
        [Fact]
        public void When_TextIsAdded_Then_RenderedAsExpected()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"This Is a Test.+*?^$()[]{}|\"
                         , Expected = @"This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\"
                       };

            var builder = RegexBuilder.Create();

            // Action
            builder.AddElements(elements =>
                                {
                                    output.WriteFormated("Input Text", data.Test);
                                    elements.AddText(data.Test);
                                });
            var result = builder.BuildString();
            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Expected);

            result.Should()
                  .NotBe(data.Test);

        }

        [Fact]
        public void When_MultipleElementsAreAdded_Then_RenderedAsExpected()
        {
            // Arrange
            var data = new
                       {
                           Text     = @"This Is a Test.+*?^$()[]{}|\"
                         , RawText  = @"This Is a Test.+*?^$()[]{}|\"
                         , Expected = @"This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\This Is a Test.+*?^$()[]{}|\"
                       };

            var builder = RegexBuilder.Create();

            // Action
            builder.AddElements(elementCollection =>
                                {
                                    output.WriteFormated("Adding Text", data.Text);
                                    elementCollection.AddText(data.Text);

                                    output.WriteFormated("Adding Raw Text", data.RawText);
                                    elementCollection.AddRawText(data.RawText);
                                });

            var result = builder.BuildString();

            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Expected);

        }
    }
}