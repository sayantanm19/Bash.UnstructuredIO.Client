using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UnstructuredAPI.Models
{
    public partial class Element
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("element_id")]
        public string? ElementId { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }
    }

    public partial class Metadata
    {
        [JsonPropertyName("coordinates")]
        public Coordinates? Coordinates { get; set; }

        [JsonPropertyName("languages")]
        public List<string>? Languages { get; set; }

        [JsonPropertyName("page_number")]
        public int? PageNumber { get; set; }

        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("file_directory")]
        public string? FileDirectory { get; set; }

        [JsonPropertyName("last_modified")]
        public DateTime? LastModified { get; set; }

        [JsonPropertyName("filetype")]
        public string? Filetype { get; set; }

        [JsonPropertyName("parent_id")]
        public string? ParentId { get; set; }

        [JsonPropertyName("category_depth")]
        public int? CategoryDepth { get; set; }

        [JsonPropertyName("text_as_html")]
        public string? TextAsHtml { get; set; }

        [JsonPropertyName("emphasized_text_contents")]
        public List<string>? EmphasizedTextContents { get; set; }

        [JsonPropertyName("emphasized_text_tags")]
        public List<string>? EmphasizedTextTags { get; set; }

        [JsonPropertyName("is_continuation")]
        public bool? IsContinuation { get; set; }

        [JsonPropertyName("detection_class_prob")]
        public Dictionary<string, double>? DetectionClassProb { get; set; }

        [JsonPropertyName("links")]
        public List<Link>? Links { get; set; }

        [JsonPropertyName("page_name")]
        public string? PageName { get; set; }

        [JsonPropertyName("sent_from")]
        public string? SentFrom { get; set; }

        [JsonPropertyName("sent_to")]
        public string? SentTo { get; set; }

        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName("attached_to_filename")]
        public string? AttachedToFilename { get; set; }

        [JsonPropertyName("header_footer_type")]
        public string? HeaderFooterType { get; set; }

        [JsonPropertyName("link_urls")]
        public List<string>? LinkUrls { get; set; }

        [JsonPropertyName("link_texts")]
        public List<string>? LinkTexts { get; set; }

        [JsonPropertyName("section")]
        public string? Section { get; set; }
    }

    public partial class Coordinates
    {
        [JsonPropertyName("points")]
        public double[][]? Points { get; set; }
        [JsonPropertyName("system")]
        public string? System { get; set; }
        [JsonPropertyName("layout_width")]
        public double? LayoutWidth { get; set; }
        [JsonPropertyName("layout_height")]
        public double? LayoutHeight { get; set; }
    }

    public partial class Link
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("start_index")]
        public int? StartIndex { get; set; }
    }
}
