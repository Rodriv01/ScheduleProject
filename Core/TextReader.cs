using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;
using System.Text.RegularExpressions;

namespace Core
{
    public class TextReader
    {
        public string Text { get; set; }
        public string Path { get; set; }

        public TextReader(string text, string path)
        {
            this.Text = text;
            this.Path = path;
        }
    }
}
