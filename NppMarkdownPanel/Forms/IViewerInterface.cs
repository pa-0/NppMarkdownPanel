using NppMarkdownPanel.Entities;
using System;

namespace NppMarkdownPanel.Forms
{
    public interface IViewerInterface
    {
        IntPtr Handle { get; }
        void SetMarkdownFilePath(string filepath);
        void UpdateSettings(Settings settings);
        void RenderMarkdown(string currentText, string filepath, bool preserveVerticalScrollPosition = true);
        void ScrollToHtmlLineNo(double percent);
        void ScrollToElementWithLineNo(int lineNo);
        bool IsValidMkdnExtension(string filename);
        bool IsValidHtmlExtension(string filename);
        int ValidateFilterExtension(string filename);
    }
}
