using System;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Collections;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.Converter;
using NPOI.XSSF.UserModel;

namespace ExcelToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            //object refTrue = true;
            //object refFalse = false;
            //object refMissing = Type.Missing;
            //string refSourceFileName = @"F:\Hung\Test\Book.xlsx";
            //string refTargetDirectory = @"F:\Hung\Test\test.html";
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");

            //Excel.Application excel = null;
            //Excel.Workbook workbook = null;

            //try
            //{
            //    excel = new Excel.Application();
            //    excel.Visible = false;
            //    excel.DisplayAlerts = false;
            //    excel.Interactive = false;
            //    workbook = excel.Workbooks.Open(refSourceFileName.ToString(),
            //        refMissing, refTrue, refMissing, refMissing,
            //        refMissing, refMissing, refMissing, refMissing,
            //        refMissing, refMissing, refMissing, refMissing,
            //        refMissing, refMissing);

            //    object xlHtml = Excel.XlFileFormat.xlHtml;

            //    IEnumerator wsEnumerator = excel.ActiveWorkbook.Worksheets.GetEnumerator();

            //    //string worksheetFileName = null;
            //    string fileName = Path.GetFileName(refSourceFileName.ToString());
            //    string webPath = refTargetDirectory.Replace(fileName, String.Empty);

            //    while (wsEnumerator.MoveNext())
            //    {
            //        Excel.Worksheet wsCurrent = (Excel.Worksheet)wsEnumerator.Current;
            //        //worksheetFileName = Path.Combine(refTargetDirectory, wsCurrent.Name + ".htm");
            //        wsCurrent.SaveAs(refTargetDirectory, xlHtml, refMissing, refMissing, refMissing, refMissing, refMissing, refMissing, refMissing, refMissing);
            //    }
            //}
            //catch (System.Runtime.InteropServices.COMException exception)
            //{
            //    Console.WriteLine(exception.Message);
            //}
            //finally
            //{
            //    excel.Interactive = true;
            //    excel.Application.Quit();
            //    excel.Quit();
            //    excel = null;
            //}
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            XSSFWorkbook book;
            //HSSFWorkbook workbook;
            // Excel file to convert
            string fileName = @"F:\Hung\Test\DuToanSmartCE.xlsx";
            //fileName = Path.Combine(Environment.CurrentDirectory, fileName);
            //workbook = ExcelToHtmlUtils.LoadXls(fileName);
            book = new XSSFWorkbook(fileName);
            ExcelToHtmlConverter excelToHtmlConverter = new ExcelToHtmlConverter();

            // Set output parameters
            excelToHtmlConverter.OutputColumnHeaders = false;
            excelToHtmlConverter.OutputHiddenColumns = true;
            excelToHtmlConverter.OutputHiddenRows = true;
            excelToHtmlConverter.OutputLeadingSpacesAsNonBreaking = false;
            excelToHtmlConverter.OutputRowNumbers = true;
            excelToHtmlConverter.UseDivsToSpan = true;

            // Process the Excel file
            excelToHtmlConverter.ProcessWorkbook(book);

            // Output the HTML file
            excelToHtmlConverter.Document.Save(@"F:\Hung\Test\DuToanSmartCE.html");
            Console.ReadKey(true);
        }
    }
}
