namespace RegexSimpleBuilder.Tests;

// ReSharper disable once InconsistentNaming
public static class RegexGroup_Testing
{
    public class Render(ITestOutputHelper output)
    {

        [Fact]
        public void When_IsCapturingAndTextElementIsAdded_Then_ReturnsSameString()
        {
            // Arrange
            var data = new
                       {
                           Text      = @"This Is a Test.+*?^$()[]{}|\"
                         , GroupType = RegexGroupType.Capturing
                         , Expected  = @"(This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\)"
                       };

            RegexGroup regexGroup         = new();
            RegexGroup regexGroupExplicit = new(groupType: data.GroupType);
            RegexText  regexText          = new(data.Text);

            regexGroup.AddElement(regexText);
            regexGroupExplicit.AddElement(regexText);

            // Action
            output.WriteFormated("Group Type", data.GroupType);
            output.WriteFormated("Input Text", data.Text);
            var result = regexGroup.Render()
                                   .ToString();
            output.WriteFormated("Rendered Text", result);
            var resultExplicit = regexGroupExplicit.Render()
                                                   .ToString();
            output.WriteFormated("Rendered Text", resultExplicit);

            // Assert
            result.Should()
                  .Be(data.Expected);
            resultExplicit.Should()
                          .Be(data.Expected);
        }

        [Fact]
        public void When_IsNonCapturingAndTextElementIsAdded_Then_ReturnsSameString()
        {
            // Arrange
            var data = new
                       {
                           Text      = @"This Is a Test.+*?^$()[]{}|\"
                         , GroupType = RegexGroupType.NonCapturing
                         , Expected  = @"(?:This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\)"
                       };

            RegexGroup regexGroup = new(groupType: data.GroupType);
            RegexText  regexText  = new(data.Text);

            regexGroup.AddElement(regexText);

            // Action
            output.WriteFormated("Group Type", data.GroupType);
            output.WriteFormated("Input Text", data.Text);
            var result = regexGroup.Render()
                                   .ToString();
            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Expected);
        }

        [Fact]
        public void When_IsAtomicAndTextElementIsAdded_Then_ReturnsSameString()
        {
            // Arrange
            var data = new
                       {
                           Text      = @"This Is a Test.+*?^$()[]{}|\"
                         , GroupType = RegexGroupType.Atomic
                         , Expected  = @"(?>This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\)"
                       };

            RegexGroup regexGroup = new(groupType: data.GroupType);
            RegexText  regexText  = new(data.Text);

            regexGroup.AddElement(regexText);

            // Action
            output.WriteFormated("Group Type", data.GroupType);
            output.WriteFormated("Input Text", data.Text);
            var result = regexGroup.Render()
                                   .ToString();
            output.WriteFormated("Rendered Text", result);

            // Assert
            result.Should()
                  .Be(data.Expected);
        }

        [Fact]
        public void When_IsNamedAndTextElementIsAdded_Then_ReturnsSameString()
        {
            // Arrange
            var data = new
                       {
                           Text      = @"This Is a Test.+*?^$()[]{}|\"
                         , GroupType = RegexGroupType.Named
                         , GroupName = "Test Group"
                         , Expected  = @"(?<Test Group>This Is a Test\.\+\*\?\^\$\(\)\[\]\{\}\|\\)"
                       };

            RegexGroup regexGroup = new(groupType: data.GroupType, name: data.GroupName);
            RegexText  regexText  = new(data.Text);

            regexGroup.AddElement(regexText);

            // Action
            output.WriteFormated("Group Type", data.GroupType);
            output.WriteFormated("Input Text", data.Text);
            var result = regexGroup.Render()
                                   .ToString();
            output.WriteFormated("Rendered Text", result);
            output.WriteFormated("Expected Text", data.Expected);

            // Assert
            result.Should()
                  .Be(data.Expected);
        }

        [Fact]
        public void When_IsCapturingAndNoElementAdded_Throw_MissingGroupElementsException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.Capturing
                       };

            RegexGroup regexGroup         = new();
            RegexGroup regexGroupExplicit = new(groupType: data.GroupType);

            // Action
            output.WriteFormated("Group Type", data.GroupType);

            Action render         = () => regexGroup.Render();
            Action renderExplicit = () => regexGroupExplicit.Render();

            // Assert
            render.Should()
                  .Throw<MissingGroupElementsException>();
            renderExplicit.Should()
                          .Throw<MissingGroupElementsException>();
        }

        [Fact]
        public void When_IsCapturingAndElementIsEmptyString_Throw_MissingGroupElementsException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.Capturing
                         , Text      = string.Empty
                       };

            RegexText regexText = new(data.Text);

            RegexGroup regexGroup         = new();
            RegexGroup regexGroupExplicit = new(groupType: data.GroupType);

            regexGroup.AddElement(regexText);
            regexGroupExplicit.AddElement(regexText);

            // Action
            output.WriteFormated("Group Type", data.GroupType);

            Action render         = () => regexGroup.Render();
            Action renderExplicit = () => regexGroupExplicit.Render();

            // Assert
            render.Should()
                  .Throw<MissingGroupElementsException>();
            renderExplicit.Should()
                          .Throw<MissingGroupElementsException>();
        }

        [Fact]
        public void When_IsNonCapturingAndNoElementAdded_Throw_MissingGroupElementsException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.NonCapturing
                       };

            RegexGroup regexGroup = new(groupType: data.GroupType);

            // Action
            output.WriteFormated("Group Type", data.GroupType);

            Action render = () => regexGroup.Render();

            // Assert
            render.Should()
                  .Throw<MissingGroupElementsException>();
        }

        [Fact]
        public void When_IsNonCapturingAndElementIsEmptyString_Throw_MissingGroupElementsException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.NonCapturing
                         , Text      = string.Empty
                       };

            RegexText regexText = new(data.Text);

            RegexGroup regexGroup = new(groupType: data.GroupType);

            regexGroup.AddElement(regexText);

            // Action
            output.WriteFormated("Group Type", data.GroupType);

            Action render = () => regexGroup.Render();

            // Assert
            render.Should()
                  .Throw<MissingGroupElementsException>();
        }

        [Fact]
        public void When_IsNamedAndNoElementAdded_Throw_MissingGroupElementsException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.Named
                         , GroupName = "Test Group"
                       };

            RegexGroup regexGroup = new(groupType: data.GroupType, name: data.GroupName);

            // Action
            output.WriteFormated("Group Type", data.GroupType);

            Action render = () => regexGroup.Render();

            // Assert
            render.Should()
                  .Throw<MissingGroupElementsException>();
        }

        [Fact]
        public void When_IsNamedAndElementIsEmptyString_Throw_MissingGroupElementsException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.Named
                         , GroupName = "Test Group"
                         , Text      = string.Empty
                       };

            RegexText regexText = new(data.Text);

            RegexGroup regexGroup = new(groupType: data.GroupType, name: data.GroupName);

            regexGroup.AddElement(regexText);

            // Action
            output.WriteFormated("Group Type", data.GroupType);

            Action render = () => regexGroup.Render();

            // Assert
            render.Should()
                  .Throw<MissingGroupElementsException>();
        }

        [Fact]
        public void When_IsNamedAndNameIsMissing_Throw_ArgumentNullException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.Named
                         , GroupName = ""
                       };

            output.WriteFormated("Group Type", data.GroupType);

            Action render = () =>
                            {
                                _ = new RegexGroup(groupType: data.GroupType);
                            };
            Action renderEmpty = () =>
                                 {
                                     _ = new RegexGroup(groupType: data.GroupType, name: data.GroupName);
                                 };

            // Action
            // Assert
            render.Should()
                  .Throw<ArgumentNullException>();
            renderEmpty.Should()
                       .Throw<ArgumentNullException>();
        }

        [Fact]
        public void When_IsAtomicAndNoElementAdded_Throw_MissingGroupElementsException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.Atomic
                       };

            RegexGroup regexGroup = new(groupType: data.GroupType);

            // Action
            output.WriteFormated("Group Type", data.GroupType);

            Action render = () => regexGroup.Render();

            // Assert
            render.Should()
                  .Throw<MissingGroupElementsException>();
        }

        [Fact]
        public void When_IsAtomicAndElementIsEmptyString_Throw_MissingGroupElementsException()
        {
            // Arrange
            var data = new
                       {
                           GroupType = RegexGroupType.Atomic
                         , Text      = string.Empty
                       };

            RegexText regexText = new(data.Text);

            RegexGroup regexGroup = new(groupType: data.GroupType);

            regexGroup.AddElement(regexText);

            // Action
            output.WriteFormated("Group Type", data.GroupType);

            Action render = () => regexGroup.Render();

            // Assert
            render.Should()
                  .Throw<MissingGroupElementsException>();
        }
    }
}