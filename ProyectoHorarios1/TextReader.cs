using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;
using System.Text.RegularExpressions;

namespace ProyectoHorarios1
{
    public class TextReader
    {
        protected string BaseText { get; }
        private List<string> SplittedText { get; }
        public TextReader(string path)
        {
            this.BaseText = new TextExtractor().Extract(path).Text;

            this.SplittedText = TextSplitter.SplitPDF(this.BaseText);
        }
        public void Insert()
        {
            int cont = 0;
            foreach (var line in this.SplittedText)
            {
                TextSplitter.SplitLine(this.SplittedText[cont]);
                cont++;
            }
        }
        public void Print()
        {
            TextSplitter.Print();
        }
    }
}
