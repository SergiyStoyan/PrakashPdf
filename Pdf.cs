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

namespace Cliver.PrakashPdf
{
    class Pdf
    {
        static public IEnumerable<List<string>> Get(string pdf_file)
        {
            PdfReader.unethicalreading = true;
            PdfReader pr = new PdfReader(pdf_file);

            System.util.RectangleJ[] rs = {
                new System.util.RectangleJ(300, 555, 340, 40),
                new System.util.RectangleJ(300, 515, 340, 35),
                new System.util.RectangleJ(300, 495, 340, 20),
                new System.util.RectangleJ(300, 470, 340, 15),
                new System.util.RectangleJ(220, 445, 340, 20),
                new System.util.RectangleJ(220, 425, 340, 20),

                new System.util.RectangleJ(0, 400, 120, 10),
                new System.util.RectangleJ(120, 400, 90, 10),
                new System.util.RectangleJ(210, 400, 100, 10),

                new System.util.RectangleJ(310, 400, 120, 10),
                new System.util.RectangleJ(430, 400, 150, 10),
            } ;
            List<ITextExtractionStrategy> ss = new List<ITextExtractionStrategy>();
            foreach (System.util.RectangleJ r in rs)
            {
                RenderFilter[] f = { new RegionTextRenderFilter(r) };
                ss.Add(new FilteredTextRenderListener(new LocationTextExtractionStrategy(), f));
            }

            for (int i = 1; i <= pr.NumberOfPages; i++)
            {
                //string t = PdfTextExtractor.GetTextFromPage(pr, i, new SimpleTextExtractionStrategy());

                List<string> vs = new List<string>();
                foreach (ITextExtractionStrategy s in ss)
                    vs.Add(PdfTextExtractor.GetTextFromPage(pr, i, s));
                yield return vs;
                break;
            }
        }
    }
}