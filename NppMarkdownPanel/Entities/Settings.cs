using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NppMarkdownPanel.Entities
{
    public class Settings
    {
        public const string DefaultCssFile = "style.css";
        public const string DefaultDarkModeCssFile = "style-dark.css";
        public const string DEFAULT_SUPPORTED_MKDN_EXT = "md,mkd,mdwn,mdown,mdtxt,markdown";
        public const string DEFAULT_SUPPORTED_HTML_EXT = "html,htm";

        public string CssFileName { get; set; }
        public string CssDarkModeFileName { get; set; }
        public int ZoomLevel { get; set; }
        public string HtmlFileName { get; set; }
        public string MkdnExtensions { get; set; }
        public string HtmlExtensions { get; set; }
        public bool IsDarkModeEnabled { get; set; }
        public bool ShowToolbar { get; set; }
        public bool ShowStatusbar { get; set; }
        public bool AutoShowPanel { get; set; }

        public const int FILTERS = 10;
        public string[] filterExts = new string[FILTERS];
        public string[] filterProgs = new string[FILTERS];
        public string[] filterArgs = new string[FILTERS];
        public int filtersFound = 0;

        public string PreProcessorCommandFilename { get; set; }
        public string PreProcessorArguments { get; set; }
        public string PostProcessorCommandFilename { get; set; }
        public string PostProcessorArguments { get; set; }

    }
}
