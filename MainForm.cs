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
using System.Threading;


namespace Cliver.PrakashPdf
{
    public partial class MainForm : BaseForm //Form// 
    {
        public MainForm()
        {
            InitializeComponent();

            Text = Application.ProductName;
            InputFile.Text = "Sakhamuru_res.pdf";

            Rectangles.Text = @"(350, 555, 340, 50)
                                (350, 515, 340, 35)
                                (350, 495, 340, 20)
                                (350, 470, 340, 15)
                                (220, 445, 340, 20)
                                (220, 425, 340, 20)
                                (0, 400, 120, 10),
                                (120, 400, 90, 10),
                                (210, 400, 150, 10)
                                (360, 400, 120, 10)
                                (480, 400, 150, 10)";

            progress.Maximum = 10000;

            if (string.IsNullOrWhiteSpace(OutputFolder.Text))
                OutputFolder.Text = Log.AppDir;
        }

        private void bInputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (string.IsNullOrWhiteSpace(d.InitialDirectory))
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
                d.SelectedPath = Log.AppDir;
            if (d.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            OutputFolder.Text = d.SelectedPath;
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            if (t != null && t.IsAlive)
            {
                if (!Message.YesNo("Extraction is running. Would you like to abort it and restart?"))
                    return;
                t.Abort();
            }
            t = Cliver.ThreadRoutines.StartTry(()=> { run(InputFile.Text, OutputFolder.Text, Rectangles.Text); });
        }

        Thread t = null;

        private void run(string input_file, string output_folder, string rectangles_string)
        {
            progress.Value = 0;
            if (string.IsNullOrWhiteSpace(input_file))
            {
                Message.Error("InputFile is empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(output_folder))
            {
                Message.Error("OutputFolder is empty.");
                return;
            }
            List<System.util.RectangleJ> rectangles = new List<System.util.RectangleJ>();
            if (string.IsNullOrWhiteSpace(rectangles_string))
            {
                Message.Error("Rectangles is empty.");
                return;
            }
            rectangles_string = Regex.Replace(rectangles_string, @"\s+", "", RegexOptions.Singleline);
            for (Match m = Regex.Match(rectangles_string, @"\((\d+),(\d+),(\d+),(\d+)\)", RegexOptions.Singleline); m.Success; m = m.NextMatch())
                rectangles.Add(new System.util.RectangleJ(float.Parse(m.Groups[1].Value), float.Parse(m.Groups[2].Value), float.Parse(m.Groups[3].Value), float.Parse(m.Groups[4].Value)));
         
            //string csv = OutputFolder.Text + "\\" + Regex.Replace(InputFile.Text, @"(?:.*\\|^)(.*)\..*$", "$1.csv");
            //if (File.Exists(csv))
            //    File.Delete(csv);
            //List<string> ls = new List<string>();

            string xls = OutputFolder.Text + "\\" + Regex.Replace(InputFile.Text, @"(?:.*\\|^)(.*)\..*$", "$1.xlsx");
            if (File.Exists(xls))
                File.Delete(xls);
            using (ExcelPackage package = new ExcelPackage(new FileInfo(xls)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(Regex.Replace(InputFile.Text, @"(?:.*\\|^)(.*)\..*$", "$1"));
                int i = 0;
                foreach (List<string> ss in Pdf.Get(InputFile.Text, rectangles,
                    (float pv) =>
                    {
                        float p = (float)progress.Maximum * pv;
                        progress.Invoke(() => { progress.Value = (int)p; });
                    }
                    )
                    )
                {
                    i++;
                    for (int j = 0; j < ss.Count; j++)
                        worksheet.Cells[i, j + 1].Value = ss[j];

                    //ls.Add(Cliver.FieldPreparation.GetCsvLine(ss));
                }
                worksheet.Cells.Style.Numberformat.Format = "@";
                package.Save();

                //File.WriteAllLines(csv, ls);
            }
            Message.Inform("Completed");
        }

        private void bAbout_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            if (t != null && t.IsAlive)
            {
                if(!Message.YesNo("Extraction is running. Would you like to abort it?"))
                    return;
            }
            Close();
            Environment.Exit(0);
        }
    }
}