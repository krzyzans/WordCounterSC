using Moq;
using WordCounter.Services.Dictionary;
using WordCounter.Services.Files;

namespace WordCounter.Tests.Services
{
    [TestFixture]
    internal class FileProcessorTests
    {
        private FileProcessor fileProcessor;
        private Mock<IFileProvider> fileProviderMock;
        private Mock<IWordDictionary> wordDictionaryMock;
        private Mock<IFileDefinition> fileDefinitionMock;

        private string file = "filesToProcess/1.txt";
        private string fileContent;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            fileContent = File.ReadAllText(file);
        }

        [SetUp]
        public void Setup()
        {
            fileProviderMock = new Mock<IFileProvider>();
            wordDictionaryMock = new Mock<IWordDictionary>();
            fileDefinitionMock = new Mock<IFileDefinition>();

            fileProcessor = new FileProcessor(fileProviderMock.Object, wordDictionaryMock.Object);

            fileProviderMock.Setup(f => f.GetFileDefinition(It.IsAny<string>()))
                .Returns(fileDefinitionMock.Object);
            fileDefinitionMock.Setup(f => f.ReadPartSize())
                .ReturnsAsync(fileContent.ToCharArray());
            fileDefinitionMock.Setup(f => f.EOF)
                .Returns(true);
        }

        [Test]
        public async Task ProcessFile_correctNumberOfWords()
        {
            await fileProcessor.ProcessFile(string.Empty);

            wordDictionaryMock.Verify(w => w.Add(It.IsAny<string>()), Times.Exactly(9));
        }

        [Test]
        public async Task ProcessFile_onlyAllowedWords()
        {
            string[] allowedWords = new [] { "Go", "do", "that", "thing", "that", "you", "do", "so", "well" };

            await fileProcessor.ProcessFile(string.Empty);

            wordDictionaryMock.Verify(w => w.Add(It.Is<string>(arg => allowedWords.Contains(arg))), Times.Exactly(9));
        }
    }
}
