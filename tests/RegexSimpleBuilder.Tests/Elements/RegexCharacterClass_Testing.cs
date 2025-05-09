namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public class RegexCharacterClass_Testing
{
    public class Render(ITestOutputHelper output)
    {

        [Fact]
        public void When_PositiveNoSpecialCharactersNoRepeater_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"a-z0-9-=.+"
                         , Expected = @"[a-z0-9-=.+]"
                       };

            var regexCharClass = new RegexCharacterClass(data.Test);

            // Action / Assert
            regexCharClass.TestElement(data.Expected, output);
        }

        [Fact]
        public void When_NegativeNoSpecialCharactersNoRepeater_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"a-z0-9-=.+"
                         , Expected = @"[^a-z0-9-=.+]"
                       };

            var regexCharClass = new RegexCharacterClass(data.Test, negated: true);

            // Action / Assert
            regexCharClass.TestElement(data.Expected, output);
        }

        [Fact]
        public void When_PositiveNoSpecialCharactersNoneOrMore_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"a-z0-9-=.+"
                         , Expected = @"[a-z0-9-=.+]*"
                       };

            var regexCharClass = new RegexCharacterClass(data.Test, IRegexRepeater.NoneOrMore);

            // Action / Assert
            regexCharClass.TestElement(data.Expected, output);
        }

        [Fact]
        public void When_PositiveNoSpecialCharactersAtLeastOne_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"a-z0-9-=.+"
                         , Expected = @"[a-z0-9-=.+]+"
                       };

            var regexCharClass = new RegexCharacterClass(data.Test, IRegexRepeater.AtLeastOne);

            // Action / Assert
            regexCharClass.TestElement(data.Expected, output);
        }

        [Fact]
        public void When_PositiveNoSpecialCharactersOptional_Then_ReturnsCorrectly()
        {
            // Arrange
            var data = new
                       {
                           Test     = @"a-z0-9-=.+"
                         , Expected = @"[a-z0-9-=.+]?"
                       };

            var regexCharClass = new RegexCharacterClass(data.Test, IRegexRepeater.Optional);

            // Action / Assert
            regexCharClass.TestElement(data.Expected, output);
        }
    }

    public class Ctor
    {
        [Fact]
        public void When_ClassDefinitionIsAnEmptyString_Throw_ArgumentException()
        {
            // Arrange
            var data = new
                       {
                           Text = string.Empty
                       };

            // Act
            Action constructor = () => _ = new RegexCharacterClass(classDefinition: data.Text);

            // Assert
            constructor.Should()
                       .Throw<ArgumentException>();
        }
    }
    
}