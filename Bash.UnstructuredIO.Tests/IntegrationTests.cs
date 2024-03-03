using System.Reflection;
using UnstructuredAPI;
using UnstructuredAPI.Models;

namespace Bash.UnstructuredIO.Tests
{
    public class IntegrationTests
    {
        UnstructuredClient unstructuredClient = new UnstructuredClient("http://localhost:8000", "my-key-123");

        [Fact]
        public async Task Should_Partition_WordDocument()
        {
            var filePath = AssemblyDirectory + "\\SampleFiles\\lorem_ipsum.docx";            
            var result = await unstructuredClient.PartitionAsync(filePath, CancellationToken.None);

            Assert.NotNull(result.Data);
            Assert.Equal("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc ac faucibus odio.", result.Data[1].Text);
        }

        [Fact]
        public async Task Should_Partition_Pdf()
        {
            var filePath = AssemblyDirectory + "\\SampleFiles\\Benefit_Options.pdf";

            var options = new ExtractionOptions()
            {
                Coordinates = true
            };
            var result = await unstructuredClient.PartitionAsync(filePath, options, CancellationToken.None);

            Assert.NotNull(result.Data);
            Assert.Equal("Contoso Electronics Plan and Benefit Packages", result.Data[0].Text);
            Assert.NotEmpty(result.Data[0].Metadata.Coordinates.Points);
        }

        [Fact]
        public async Task Should_Partition_TextFile()
        {
            var filePath = AssemblyDirectory + "\\SampleFiles\\sample_text.txt";
            FileStream stream = File.OpenRead(filePath);

            var result = await unstructuredClient.PartitionAsync(stream, filePath, CancellationToken.None);

            Assert.NotNull(result.Data);
            Assert.Equal(UnstructuredConstants.ElementTypes.NarrativeText, result.Data[0].Type);
        }

        [Fact]
        public async Task Should_Partition_ImageFile()
        {
            var filePath = AssemblyDirectory + "\\SampleFiles\\sample_image.PNG";
            FileStream stream = File.OpenRead(filePath);

            var options = new ExtractionOptions()
            {
                Strategy = UnstructuredConstants.Strategy.HighResolution,
                Coordinates = true
            };
            var result = await unstructuredClient.PartitionAsync(stream, filePath, options, CancellationToken.None);

            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data[0].Metadata.Coordinates.Points);
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().Location;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path) ?? "";
            }
        }
    }
}