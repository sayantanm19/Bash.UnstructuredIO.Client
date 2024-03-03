namespace UnstructuredAPI.Models
{
    public static class UnstructuredConstants
    {
        public static class Language
        {
            public static readonly string Afrikaans = "afr";
            public static readonly string Amharic = "amh";
            public static readonly string Arabic = "ara";
            public static readonly string Assamese = "asm";
            public static readonly string Azerbaijani = "aze";
            public static readonly string AzerbaijaniCyrillic = "aze_cyrl";
            public static readonly string Belarusian = "bel";
            public static readonly string Bengali = "ben";
            public static readonly string Tibetan = "bod";
            public static readonly string Bosnian = "bos";
            public static readonly string Breton = "bre";
            public static readonly string Bulgarian = "bul";
            public static readonly string Catalan = "cat";
            public static readonly string Cebuano = "ceb";
            public static readonly string Czech = "ces";
            public static readonly string ChineseSimplified = "chi_sim";
            public static readonly string ChineseSimplifiedVertical = "chi_sim_vert";
            public static readonly string ChineseTraditional = "chi_tra";
            public static readonly string ChineseTraditionalVertical = "chi_tra_vert";
            public static readonly string Cherokee = "chr";
            public static readonly string Corsican = "cos";
            public static readonly string Welsh = "cym";
            public static readonly string Danish = "dan";
            public static readonly string German = "deu";
            public static readonly string Divehi = "div";
            public static readonly string Dzongkha = "dzo";
            public static readonly string Greek = "ell";
            public static readonly string English = "eng";
            public static readonly string MiddleEnglish = "enm";
            public static readonly string Esperanto = "epo";
            public static readonly string Basque = "eus";
            public static readonly string Faroese = "fao";
            public static readonly string Persian = "fas";
            public static readonly string Filipino = "fil";
            public static readonly string Finnish = "fin";
            public static readonly string French = "fra";
            public static readonly string Frankish = "frk";
            public static readonly string OldFrench = "frm";
            public static readonly string Frisian = "fry";
            public static readonly string ScottishGaelic = "gla";
            public static readonly string Irish = "gle";
            public static readonly string Galician = "glg";
            public static readonly string AncientGreek = "grc";
            public static readonly string Gujarati = "guj";
            public static readonly string HaitianCreole = "hat";
            public static readonly string Hebrew = "heb";
            public static readonly string Hindi = "hin";
            public static readonly string Croatian = "hrv";
            public static readonly string Hungarian = "hun";
            public static readonly string Armenian = "hye";
            public static readonly string Inuktitut = "iku";
            public static readonly string Indonesian = "ind";
            public static readonly string Icelandic = "isl";
            public static readonly string Italian = "ita";
            public static readonly string OldItalian = "ita_old";
            public static readonly string Javanese = "jav";
            public static readonly string Japanese = "jpn";
            public static readonly string JapaneseVertical = "jpn_vert";
            public static readonly string Kannada = "kan";
            public static readonly string Georgian = "kat";
            public static readonly string OldGeorgian = "kat_old";
            public static readonly string Kazakh = "kaz";
            public static readonly string Khmer = "khm";
            public static readonly string Kirghiz = "kir";
            public static readonly string Kurdish = "kmr";
            public static readonly string Korean = "kor";
            public static readonly string KoreanVertical = "kor_vert";
            public static readonly string Lao = "lao";
            public static readonly string Latin = "lat";
            public static readonly string Latvian = "lav";
            public static readonly string Lithuanian = "lit";
            public static readonly string Luxembourgish = "ltz";
            public static readonly string Malayalam = "mal";
            public static readonly string Marathi = "mar";
            public static readonly string Macedonian = "mkd";
            public static readonly string Maltese = "mlt";
            public static readonly string Mongolian = "mon";
            public static readonly string Maori = "mri";
            public static readonly string Malay = "msa";
            public static readonly string Burmese = "mya";
            public static readonly string Nepali = "nep";
            public static readonly string Dutch = "nld";
            public static readonly string Norwegian = "nor";
            public static readonly string Occitan = "oci";
            public static readonly string Oriya = "ori";
            public static readonly string Ossetic = "osd";
            public static readonly string Punjabi = "pan";
            public static readonly string Polish = "pol";
            public static readonly string Portuguese = "por";
            public static readonly string Pashto = "pus";
            public static readonly string Quechua = "que";
            public static readonly string Romanian = "ron";
            public static readonly string Russian = "rus";
            public static readonly string Sanskrit = "san";
            public static readonly string Sinhala = "sin";
            public static readonly string Slovak = "slk";
            public static readonly string Slovenian = "slv";
            public static readonly string Sindhi = "snd";
            public static readonly string Sumerian = "snum";
            public static readonly string Spanish = "spa";
            public static readonly string OldSpanish = "spa_old";
            public static readonly string Albanian = "sqi";
            public static readonly string Serbian = "srp";
            public static readonly string SerbianLatin = "srp_latn";
            public static readonly string Sundanese = "sun";
            public static readonly string Swahili = "swa";
            public static readonly string Swedish = "swe";
            public static readonly string Syriac = "syr";
            public static readonly string Tamil = "tam";
            public static readonly string Tatar = "tat";
            public static readonly string Telugu = "tel";
            public static readonly string Tajik = "tgk";
            public static readonly string Thai = "tha";
            public static readonly string Tigrinya = "tir";
            public static readonly string Tongan = "ton";
            public static readonly string Turkish = "tur";
            public static readonly string Uighur = "uig";
            public static readonly string Ukrainian = "ukr";
            public static readonly string Urdu = "urd";
            public static readonly string Uzbek = "uzb";
            public static readonly string UzbekCyrillic = "uzb_cyrl";
            public static readonly string Vietnamese = "vie";
            public static readonly string Yiddish = "yid";
            public static readonly string Yoruba = "yor";
        }
        public static class Strategy
        {
            public static readonly string Auto = "auto";
            public static readonly string HighResolution = "hi_res";
            public static readonly string Fast = "fast";
        }
        public static class ChunkingStrategy
        {
            public static readonly string ByTitle = "by_title";
            public static readonly string Basic = "basic";
        }
        public static class ElementTypes
        {
            public static readonly string Title = "Title";
            public static readonly string Text = "Text";
            public static readonly string UncategorizedText = "UncategorizedText";
            public static readonly string NarrativeText = "NarrativeText";
            public static readonly string BulletedText = "BulletedText";
            public static readonly string Abstract = "Abstract";
            public static readonly string Threading = "Threading";
            public static readonly string Form = "Form";
            public static readonly string FieldName = "Field-Name";
            public static readonly string Value = "Value";
            public static readonly string Link = "Link";
            public static readonly string CompositeElement = "CompositeElement";
            public static readonly string Image = "Image";
            public static readonly string Picture = "Picture";
            public static readonly string FigureCaption = "FigureCaption";
            public static readonly string Figure = "Figure";
            public static readonly string Caption = "Caption";
            public static readonly string List = "List";
            public static readonly string ListItem = "ListItem";
            public static readonly string ListItemOther = "List-item";
            public static readonly string Checked = "Checked";
            public static readonly string Unchecked = "Unchecked";
            public static readonly string Address = "Address";
            public static readonly string EmailAddress = "EmailAddress";
            public static readonly string PageBreak = "PageBreak";
            public static readonly string Formula = "Formula";
            public static readonly string Table = "Table";
            public static readonly string Header = "Header";
            public static readonly string Headline = "Headline";
            public static readonly string SubHeadline = "Subheadline";
            public static readonly string PageHeader = "Page-header";
            public static readonly string SectionHeader = "Section-header";
            public static readonly string Footer = "Footer";
            public static readonly string Footnote = "Footnote";
            public static readonly string PageFooter = "Page-footer";
        }
        public enum FileType
        {
            UNK = 0,
            EMPTY = 1,

            // MS Office Types
            DOC = 10,
            DOCX = 11,
            XLS = 12,
            XLSX = 13,
            PPT = 14,
            PPTX = 15,
            MSG = 16,

            // Adobe Types
            PDF = 20,

            // Image Types
            JPG = 30,
            PNG = 31,
            TIFF = 32,
            BMP = 33,
            HEIC = 34,

            // Plain Text Types
            EML = 40,
            RTF = 41,
            TXT = 42,
            JSON = 43,
            CSV = 44,
            TSV = 45,

            // Markup Types
            HTML = 50,
            XML = 51,
            MD = 52,
            EPUB = 53,
            RST = 54,
            ORG = 55,

            // Compressed Types
            ZIP = 60,

            // Open Office Types
            ODT = 70,

            // Audio Files
            WAV = 80
        }
        public static FileType GetFileTypeFromMimeType(string mimeType)
        {
            switch (mimeType)
            {
                case "application/pdf":
                    return FileType.PDF;
                case "application/msword":
                    return FileType.DOC;
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    return FileType.DOCX;
                case "image/jpeg":
                    return FileType.JPG;
                case "image/png":
                    return FileType.PNG;
                case "image/heic":
                    return FileType.HEIC;
                case "image/tiff":
                    return FileType.TIFF;
                case "image/bmp":
                    return FileType.BMP;
                case "application/yaml":
                case "application/x-yaml":
                case "text/x-yaml":
                case "text/yaml":
                case "text/plain":
                    return FileType.TXT;
                case "text/x-csv":
                case "application/csv":
                case "application/x-csv":
                case "text/comma-separated-values":
                case "text/x-comma-separated-values":
                case "text/csv":
                    return FileType.CSV;
                case "text/tsv":
                    return FileType.TSV;
                case "text/markdown":
                case "text/x-markdown":
                    return FileType.MD;
                case "text/org":
                    return FileType.ORG;
                case "text/x-rst":
                    return FileType.RST;
                case "application/epub":
                case "application/epub+zip":
                    return FileType.EPUB;
                case "application/json":
                    return FileType.JSON;
                case "application/rtf":
                case "text/rtf":
                    return FileType.RTF;
                case "text/html":
                    return FileType.HTML;
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    return FileType.XLSX;
                case "application/vnd.ms-excel":
                    return FileType.XLS;
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                    return FileType.PPTX;
                case "application/vnd.ms-powerpoint":
                    return FileType.PPT;
                case "application/xml":
                    return FileType.XML;
                case "application/vnd.oasis.opendocument.text":
                    return FileType.ODT;
                case "message/rfc822":
                    return FileType.EML;
                case "application/x-ole-storage":
                case "application/vnd.ms-outlook":
                    return FileType.MSG;
                case "audio/vnd.wav":
                case "audio/vnd.wave":
                case "audio/wave":
                case "audio/x-pn-wav":
                case "audio/x-wav":
                    return FileType.WAV;
                case "inode/x-empty":
                    return FileType.EMPTY;
                default:
                    return FileType.UNK;
            }
        }
    }
}
