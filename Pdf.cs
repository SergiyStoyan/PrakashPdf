//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Data.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf.parser;
using System.Windows.Forms;

namespace Cliver.PrakashPdf
{
    class Pdf
    {
        static public IEnumerable<List<string>> Get(string pdf_file, Action<float> progress)
        {
            PdfReader.unethicalreading = true;
            PdfReader pr = new PdfReader(pdf_file);

            System.util.RectangleJ[] rs = {
                new System.util.RectangleJ(350, 555, 340, 50),
                new System.util.RectangleJ(350, 515, 340, 35),
                new System.util.RectangleJ(350, 495, 340, 20),
                new System.util.RectangleJ(350, 470, 340, 15),

                new System.util.RectangleJ(220, 445, 340, 20),
                new System.util.RectangleJ(220, 425, 340, 20),

                new System.util.RectangleJ(0, 400, 120, 10),
                new System.util.RectangleJ(120, 400, 90, 10),
                new System.util.RectangleJ(210, 400, 150, 10),
                new System.util.RectangleJ(360, 400, 120, 10),
                new System.util.RectangleJ(480, 400, 150, 10),
            } ;
            List<RenderFilter[]> fs = new List<RenderFilter[]>();
            foreach (System.util.RectangleJ r in rs)
            {
                fs.Add( new RenderFilter[] { new RegionTextRenderFilter(r) });
            }

            for (int i = 1; i <= pr.NumberOfPages; i++)
            {
                //string t = PdfTextExtractor.GetTextFromPage(pr, i, new SimpleTextExtractionStrategy());

                List<string> vs = new List<string>();
                foreach (RenderFilter[] f in fs)
                {
                    ITextExtractionStrategy s = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), f);
                    vs.Add(PdfTextExtractor.GetTextFromPage(pr, i, s).Trim());
                }
                progress?.Invoke((float)i / pr.NumberOfPages);
                yield return vs;
                //break;
            }
        }
    }
}