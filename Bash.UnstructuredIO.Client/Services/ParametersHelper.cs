using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using UnstructuredAPI.Models;

namespace UnstructuredAPI.Services
{
    internal static class ParametersHelper
    {
        internal static void AddFileFromPath(MultipartFormDataContent formContent, string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                AddFileFromStream(formContent, stream, filePath);
            }
        }
        internal static void AddFileFromStream(MultipartFormDataContent formContent, Stream fileStream, string fileName)
        {
            var streamContent = new StreamContent(fileStream);

            streamContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Octet);
            streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            streamContent.Headers.ContentDisposition.Name = "files";
            streamContent.Headers.ContentDisposition.FileName = fileName;
            formContent.Add(streamContent);
        }
        internal static void AddMappedParameters(MultipartFormDataContent formContent, ExtractionOptions options)
        {
            var parameters = new Dictionary<string, object>
            {
                { "strategy", options.Strategy },
                { "output_format", options.OutputFormat },
                { "coordinates", options.Coordinates },
                { "encoding", options.Encoding },
                { "include_page_breaks", options.IncludePageBreaks },
                { "multipage_sections", options.MultipageSections },
                { "combine_under_n_chars", options.CombineUnderNChars },
                { "new_after_n_chars", options.NewAfterNChars },
                { "max_characters", options.MaxCharacters },
                { "pdf_infer_table_structure", options.PdfInferTableStructure },
                { "xml_keep_tags", options.XmlKeepTags },
                { "extract_image_block_to_payload", options.ExtractImageBlockToPayload },
                { "chunking_strategy", options.ChunkingStrategy },
                { "gz_uncompressed_content_type", options.GzUncompressedContentType },
                { "hi_res_model_name", options.HiResModelName }
            };

            foreach (var parameter in parameters)
            {
                AddSingleParameter(formContent, parameter.Key, parameter.Value);
            }

            var listParameters = new Dictionary<string, List<string>>
            {
                { "languages", options.Languages },
                { "skip_infer_table_types", options.SkipInferTableTypes },
                { "extract_image_block_types", options.ExtractImageBlockTypes }
            };

            foreach (var parameter in listParameters)
            {
                AddListParameters(formContent, parameter.Key, parameter.Value);
            }
        }
        internal static void AddSingleParameter(MultipartFormDataContent formContent, string key, object value)
        {
            if (value != null)
            {
                string? parameterValue = value.ToString();
                if (parameterValue != null) formContent.Add(new StringContent(parameterValue), key);
            }
        }
        internal static void AddListParameters(MultipartFormDataContent formContent, string key, IEnumerable<string?> values)
        {
            if (values.Count() > 0)
                formContent.Add(new StringContent(JsonSerializer.Serialize(values)), key);
        }
    }
}
