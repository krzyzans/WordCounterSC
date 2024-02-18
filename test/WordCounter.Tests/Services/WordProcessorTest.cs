using Moq;
using WordCounter.Services.Dictionary;
using WordCounter.Services.Files;
using WordCounter.Services.Printer;
using WordCounter.Services.Words;

namespace WordCounter.Tests.Services
{
    [TestFixture]
    public class WordProcessorTest
    {
        private WordsProcessor wordsProcessor;

        private Mock<IFileProvider> filesProviderMock;
        private Mock<IFileProcessor> fileProcessorMock;
        private Mock<IPrinter<IWordDictionary>> printerMock;

        [SetUp]
        public void Setup()
        {
            filesProviderMock = new Mock<IFileProvider>();
            fileProcessorMock = new Mock<IFileProcessor>();
            printerMock = new Mock<IPrinter<IWordDictionary>>();

            wordsProcessor = new WordsProcessor(filesProviderMock.Object, fileProcessorMock.Object, printerMock.Object);
        }

        [Test]
        public void CountWords_emptyFileList_dontThrowException()
        {
            filesProviderMock.Setup(f => f.GetFileDefinitionsPaths())
                .Returns(new List<string>());

            Assert.DoesNotThrowAsync(wordsProcessor.CountWords);
        }

        [Test]
        public async Task CountWords_noEmptyList_causeProcessFileExecution()
        {
            filesProviderMock.Setup(f => f.GetFileDefinitionsPaths())
                .Returns(new List<string>() { ""});

            await wordsProcessor.CountWords();

            fileProcessorMock.Verify(f => f.ProcessFile(It.IsAny<string>()), Times.Once);
        }
    }
}