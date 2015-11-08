using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel;

namespace LYLQ.WinUI.Models
{
    public static class ExcelHelper
    {
        public static void CreateExcel(string fileName, IWorkbook workbook)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream fs = File.Create(fileName))
            {                
                workbook.Write(fs);
                fs.Close();
            }
        }

        private static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }

        public static void SetHeaderStyle(IWorkbook workbook, IRow row, int columns)
        {
            row.Height = 16 * 30;
            IFont font18 = workbook.CreateFont();
            font18.FontName = "宋体";
            font18.FontHeightInPoints = 12;
            font18.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;            

            for (int i = 0; i < columns; i++)
            {
                ICellStyle style12 = workbook.CreateCellStyle();
                style12.SetFont(font18);
                // style12.Alignment = HorizontalAlignment.CENTER;
                style12.VerticalAlignment = VerticalAlignment.CENTER;


                style12.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                style12.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                style12.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                style12.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                //style12.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index2;
                row.GetCell(i).CellStyle = style12;
            }
        }

        public static void SetBorderStyle(IWorkbook workbook, IRow row, int columns)
        {
            row.Height = 14 * 30;
            IFont font18 = workbook.CreateFont();
            font18.FontName = "宋体";
            font18.FontHeightInPoints = 10;

            

            for (int i = 0; i < columns; i++)
            {
                ICellStyle style12 = workbook.CreateCellStyle();
                style12.SetFont(font18);
                //style12.Alignment = HorizontalAlignment.CENTER;
                style12.VerticalAlignment = VerticalAlignment.CENTER;

                style12.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                style12.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                style12.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                style12.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                row.GetCell(i).CellStyle = style12;
            }
        }
    }
}
