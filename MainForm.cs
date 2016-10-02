using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliver;
using OfficeOpenXml;
using System.IO;


namespace Cliver.PrakashPdf
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InputFile.Text = "Sakhamuru_res.pdf";

            if (string.IsNullOrWhiteSpace(OutputFolder.Text))
                OutputFolder.Text = Log.AppDir;
        }

        private void bInputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if(string.IsNullOrWhiteSpace(d.InitialDirectory))
                d.InitialDirectory = Log.AppDir;
            d.Filter = "PDF|*.pdf|"
                + "All files (*.*)|*.*";
            if (d.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            InputFile.Text = d.FileName;
        }

        private void bOutputFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            if (string.IsNullOrWhiteSpace(d.SelectedPath))
                d.SelectedPath= Log.AppDir;
            if (d.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            OutputFolder.Text = d.SelectedPath;
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(InputFile.Text))
                {
                    Message.Error("InputFile is empty.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(OutputFolder.Text))
                {
                    Message.Error("OutputFolder is empty.");
                    return;
                }
                List<string> s2s = new List<string>();
                const char delimiter = '\t';
                foreach (List<string> ss in Pdf.Get(InputFile.Text))
                {
                    //Match m = Regex.Match(s, @".* సనసస(.*)\sPage \d+ of", RegexOptions.Singleline);
                    //s2s.Add(m.Groups["1"].Value + delimiter + m.Groups["2"].Value + delimiter + m.Groups["3"].Value + delimiter + m.Groups["4"].Value + delimiter + m.Groups["5"].Value + delimiter + m.Groups["6"].Value + delimiter + m.Groups["7"].Value + delimiter + m.Groups["8"].Value + delimiter + m.Groups["9"].Value + delimiter + m.Groups[""].Value + delimiter);
                    s2s.Add(string.Join("\t", ss));
//                    A V L Narasimha Murthy,ANANDARAO
//                    ANASUYA, Anandarao Meenakshi Thayi, Anandarao
//Raghavendra Rao, Avathapalli Kamakshi
//272103727275,374463410002,570262104829, 
//844447862425,G5186283
//SPUNIT1905009259
//SPUNIT1905009259 - 1C29
// 7 568 1213 C29 14
//7 - 568 - 1213 - C29
// 1320
//Page 1 of 1821
                }
                //Application app = new Application();
                //Workbook wb = app.Workbooks.Open(@"C:\testcsv.csv", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //wb.SaveAs(@"C:\testcsv.xlsx", XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //wb.Close();
                //app.Quit();   
                var format = new ExcelTextFormat();
                format.Delimiter = delimiter;
                format.EOL = "\r\n";
                // format.TextQualifier = '"';
                string of = OutputFolder.Text + "\\" + Regex.Replace(InputFile.Text, @"(?:.*\\|^)(.*)\..*$", "$1.xls");
                using (ExcelPackage package = new ExcelPackage(new FileInfo(of)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("1");
                    //worksheet.Cells["A1"].LoadFromText(string.Join("\t", s2s), format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
                    worksheet.Cells["A1"].LoadFromText(string.Join("\r\n", s2s), format);
                    package.Save();
                }
            }
            catch (Exception ex)
            {
                Message.Error(ex);
            }
        }

        private void bAbout_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }
    }
}
