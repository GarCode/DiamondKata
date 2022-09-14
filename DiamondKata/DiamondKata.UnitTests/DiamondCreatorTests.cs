using DiamondKata.Exceptions;

namespace DiamondKata.UnitTests
{
    public class DiamondCreatorTests
    {
        private const string InvalidInputNotSingleCharacterMessage = "Input must be a single character.";

        private DiamondCreator _diamondCreator;

        [SetUp]
        public void Setup()
        {
            _diamondCreator = new DiamondCreator();
        }

        [Test]
        public void Create_InputValueIsLargerThanOneCharacter_ThrowInputValidationException()
        {
            // Act/Assert
            var exception = Assert.Throws<InvalidInputException>(() => _diamondCreator.Create("Test"));
            Assert.That(exception.Message, Is.EqualTo(InvalidInputNotSingleCharacterMessage));
        }

        [Test]
        public void Create_InputValueIsEmpty_ThrowInputValidationException()
        {
            // Act/Assert
            var exception = Assert.Throws<InvalidInputException>(() => _diamondCreator.Create(string.Empty));
            Assert.That(exception.Message, Is.EqualTo(InvalidInputNotSingleCharacterMessage));
        }

        [TestCase("1")]
        [TestCase(" ")]
        [TestCase("£")]
        [TestCase(".")]
        [TestCase("\"")]
        [TestCase("?")]
        [TestCase("â")]
        public void Create_InputValueIsNotALetter_ThrowInputValidationException(string testCharacter)
        {
            // Act/Assert
            var exception = Assert.Throws<InvalidInputException>(() => _diamondCreator.Create(testCharacter));
            Assert.That(exception.Message, Is.EqualTo("Input must be a letter (a - z)."));
        }

        [Test]
        public void Create_InputIsA_OutputSingleA()
        {
            // Arrange
            var testCharacter = "a";

            // Act
            var result = _diamondCreator.Create(testCharacter);

            // Assert
            Assert.That(result, Is.EqualTo(testCharacter));
        }

        [Test]
        public void Create_InputIsB_BDiamondIsOutputted()
        {
            //Arrange
            var testCharacter = "b";
            var expectedDiamond = string.Empty // This is here to make it easier to read the expected diamond below.
                + " a " + Environment.NewLine
                + "b b" + Environment.NewLine
                + " a " + Environment.NewLine;

            // Act
            var result = _diamondCreator.Create(testCharacter);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDiamond));
        }

        [Test]
        public void Create_InputIsC_CDiamondIsOutputted()
        {
            //Arrange
            var testCharacter = "c";
            var expectedDiamond = string.Empty // This is here to make it easier to read the expected diamond below.
                + "  a  " + Environment.NewLine
                + " b b " + Environment.NewLine
                + "c   c" + Environment.NewLine
                + " b b " + Environment.NewLine
                + "  a  " + Environment.NewLine;

            // Act
            var result = _diamondCreator.Create(testCharacter);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDiamond));
        }

        [Test]
        public void Create_InputIsUpperCaseC_LowerCaseCDiamondIsOutputted()
        {
            //Arrange
            var testCharacter = "C";
            var expectedDiamond = string.Empty // This is here to make it easier to read the expected diamond below.
                + "  a  " + Environment.NewLine
                + " b b " + Environment.NewLine
                + "c   c" + Environment.NewLine
                + " b b " + Environment.NewLine
                + "  a  " + Environment.NewLine;

            // Act
            var result = _diamondCreator.Create(testCharacter);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDiamond));
        }
    }
}