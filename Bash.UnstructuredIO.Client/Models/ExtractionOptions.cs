namespace UnstructuredAPI.Models
{
    public class ExtractionOptions
    {
        // strategy
        public string Strategy { get; set; } = "auto";

        // gz_uncompressed_content_type
        public string? GzUncompressedContentType { get; set; }

        // output_format
        public string OutputFormat { get; set; } = "application/json";

        // coordinates
        public bool Coordinates { get; set; } = false;

        // encoding
        public string Encoding { get; set; } = "utf-8";

        // hi_res_model_name
        public string? HiResModelName { get; set; }

        // include_page_breaks
        public bool IncludePageBreaks { get; set; } = false;

        // languages
        public List<string> Languages { get; set; } = new List<string>();

        // pdf_infer_table_structure
        public bool PdfInferTableStructure { get; set; } = false;

        // skip_infer_table_types
        public List<string> SkipInferTableTypes { get; set; } = new List<string> { "pdf", "jpg", "png" };

        // xml_keep_tags
        public bool XmlKeepTags { get; set; }

        // chunking_strategy
        public string? ChunkingStrategy { get; set; }

        // multipage_sections
        public bool MultipageSections { get; set; } = true;

        // combine_under_n_chars
        public int CombineUnderNChars { get; set; } = 500;

        // new_after_n_chars
        public int NewAfterNChars { get; set; } = 1500;

        // max_characters
        public int MaxCharacters { get; set; } = 1500;

        // extract_image_block_types
        public List<string> ExtractImageBlockTypes { get; set; } = new List<string>();

        // extract_image_block_to_payload
        public bool ExtractImageBlockToPayload { get; set; }
    }
}
