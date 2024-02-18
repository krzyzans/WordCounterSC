using WordCounter.Services.Files;

namespace WordCounter.Tests.Services
{
    [TestFixture]
    internal class FileDefinitionTests
    {
        private FileDefinition fileDefinition;
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
            fileDefinition = new FileDefinition(file, Int16.MaxValue);
        }

        [Test]
        public async Task ReadPartSize_contentIsEqual()
        {
            char[] result = await fileDefinition.ReadPartSize();
            string resultString = new String(result);

            Assert.That(resultString.Equals(fileContent), Is.True);
        }

        [Test]
        public async Task ReadPartSize_EOF_setAtTheEnd()
        {
            await fileDefinition.ReadPartSize();

            Assert.That(fileDefinition.EOF, Is.True);
        }


        [TearDown]
        public void TearDown()
        {
            fileDefinition.Dispose();
        }
    }
}
