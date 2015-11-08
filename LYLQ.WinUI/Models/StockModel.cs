using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLayer = LYLQ.Business;

namespace LYLQ.WinUI.Models
{
    public class StockModel
    {
        public string Id { get; set; }
        public string InstoreId { get; set; }
        public string Index { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public int Number { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public bool CanMerge { get; set; }
        public int BoundHeight { get; set; }
        public string Department { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Type { get; set; }

        BizLayer.Stock _bizStock = new BizLayer.Stock();
        BizLayer.Material _bizMateriel = new BizLayer.Material();
        BizLayer.StockService _bizStockService = new BizLayer.StockService();

        public Dictionary<string, string> GetMaterialKeyValuePaire()
        {
            return _bizMateriel.GetKeyValuePairs();
        }

        public StockModel GetByInstoreId(string id)
        {
            var dbStock = _bizStock.GetByInstoreId(id);

            return GetEntityFromBiz(dbStock);
        }

        public void SyncInstockToStockForCurrentDay()
        {
            var beginDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00");            
            var endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59:59");

            UIContext.SyncInstockToStockTask = _bizStockService.SyncInStockToStock(beginDate, endDate, null, null);
            UIContext.SyncInstockToStockTask.Start();
        }

        public void Create(StockModel dpt)
        {
            var dbStock = GetBizModel(dpt);
            _bizStock.Create(dbStock);
        }

        public void Update(StockModel instoreModel)
        {
            var dbInstore = GetBizModel(instoreModel);
            _bizStock.Update(dbInstore);
        }

        public void Delete(string id)
        {
            _bizStock.Delete(id);
        }

        public List<StockModel> Query(DateTime beginDate, DateTime endDate, string type, string code)
        {
            var bizInstores = _bizStock.Query(beginDate, endDate, type, code);
            var stockModels = new List<StockModel>();
            if (bizInstores != null && bizInstores.Count > 0)
            {
                stockModels = GetEntitiesFromBiz(bizInstores);
                var i = 1;
                foreach (var inStoreModel in stockModels)
                {
                    inStoreModel.Name = inStoreModel.Code;
                    inStoreModel.Index = i.ToString().PadLeft(2, '0');
                    i++;
                }
            }

            return stockModels;
        }

        public List<StockModel> QueryPre(DateTime beginDate, DateTime endDate, string type, string code)
        {
            var bizInstores = _bizStock.QueryPre(beginDate, endDate, type, code);
            var stockModels = new List<StockModel>();
            if (bizInstores != null && bizInstores.Count > 0)
            {
                stockModels = GetEntitiesFromBiz(bizInstores);
                var i = 1;
                foreach (var inStoreModel in stockModels)
                {
                    inStoreModel.Name = inStoreModel.Code;
                    inStoreModel.Index = i.ToString().PadLeft(2, '0');
                    i++;
                }
            }

            return stockModels;
        }

        public List<StockModel> QueryNext(DateTime beginDate, DateTime endDate, string type, string code)
        {
            var bizInstores = _bizStock.QueryNext(beginDate, endDate, type, code);
            var stockModels = new List<StockModel>();
            if (bizInstores != null && bizInstores.Count > 0)
            {
                stockModels = GetEntitiesFromBiz(bizInstores);
                var i = 1;
                foreach (var inStoreModel in stockModels)
                {
                    inStoreModel.Name = inStoreModel.Code;
                    inStoreModel.Index = i.ToString().PadLeft(2, '0');
                    i++;
                }
            }

            return stockModels;
        }

        public void ExportToExcel(string reportNme, List<StockModel> stockModels, string beginDate)
        {
            if (stockModels.Count > 0)
            {                
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("库存");

                const int TYPE_COLUMN = 0;
                const int NAME_COLUMN = 1;
                const int NUMBER_COLUMN = 2;
                const int UNITPRICE_COLUMN = 3;
                const int TOTALPRICE_COLUMN = 4;

                IRow row = sheet.CreateRow(0);
                ICell cell = row.CreateCell(TYPE_COLUMN);
                row.CreateCell(1);
                row.CreateCell(2);
                row.CreateCell(3);
                row.CreateCell(4);
                cell.SetCellValue(string.Format("统计时间：{0}", beginDate));
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));
                ExcelHelper.SetHeaderStyle(workbook, row, 5);

                //标题
                row = sheet.CreateRow(1);
                cell = row.CreateCell(TYPE_COLUMN);
                cell.SetCellValue("类 型");

                cell = row.CreateCell(NAME_COLUMN);
                cell.SetCellValue("名 称");

                cell = row.CreateCell(NUMBER_COLUMN);
                cell.SetCellValue("数 量");

                cell = row.CreateCell(UNITPRICE_COLUMN, CellType.NUMERIC);
                cell.SetCellValue("单 价");

                cell = row.CreateCell(TOTALPRICE_COLUMN, CellType.NUMERIC);
                cell.SetCellValue("总 价");

                ExcelHelper.SetHeaderStyle(workbook, row, 5);

                row.Cells[0].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[1].CellStyle.Alignment = HorizontalAlignment.LEFT;
                row.Cells[2].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[3].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[4].CellStyle.Alignment = HorizontalAlignment.CENTER;

                sheet.SetColumnWidth(0, 16 * 256);
                sheet.SetColumnWidth(1, 30 * 256);
                sheet.SetColumnWidth(2, 10 * 256);
                sheet.SetColumnWidth(3, 10 * 256);
                sheet.SetColumnWidth(4, 10 * 256);

                var i = 2;

                foreach (var _stockModel in stockModels)
                {
                    row = sheet.CreateRow(i);

                    cell = row.CreateCell(TYPE_COLUMN);
                    cell.SetCellValue(_stockModel.Type);

                    cell = row.CreateCell(NAME_COLUMN);
                    cell.SetCellValue(_stockModel.Name);

                    cell = row.CreateCell(NUMBER_COLUMN);
                    cell.SetCellValue(_stockModel.Number);

                    cell = row.CreateCell(UNITPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(_stockModel.UnitPrice.Value));

                    cell = row.CreateCell(TOTALPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(_stockModel.TotalPrice.Value));

                    ExcelHelper.SetBorderStyle(workbook, row, 5);
                    row.Cells[0].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[1].CellStyle.Alignment = HorizontalAlignment.LEFT;
                    row.Cells[2].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[3].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[4].CellStyle.Alignment = HorizontalAlignment.CENTER;

                    i++;

                }
                MergeColum(stockModels, sheet);
                ExcelHelper.CreateExcel(reportNme, workbook);
            }
        }

        private void MergeColum(List<StockModel> stockModels, ISheet sheet)
        {
            var preModel = stockModels[0];
            int row_start = 2;
            int row_end = 2;

            for (int i = 1; i < stockModels.Count; i++)
            {
                if (preModel.Type == stockModels[i].Type)
                {
                    row_end++;
                }
                else
                {
                    if (row_end > row_start)
                    {
                        sheet.AddMergedRegion(new CellRangeAddress(row_start, row_end, 0, 0));

                        row_start = row_end;
                    }
                    row_end++;
                    row_start++;
                }

                preModel = stockModels[i];
            }

            if (row_end > row_start)
            {
                sheet.AddMergedRegion(new CellRangeAddress(row_start, row_end, 0, 0));
            }
        }

        public StockModel GetEntityFromBiz(BizLayer.Stock bizStock)
        {
            StockModel inst = null;
            if (bizStock != null)
            {
                inst = new StockModel();
                inst.Code = bizStock.Code;
                inst.Id = bizStock.Id;
                inst.InstoreId = bizStock.InstoreId;
                inst.Number = bizStock.Number;
                inst.UnitPrice = bizStock.UnitPrice;
                inst.TotalPrice = bizStock.TotalPrice;
                inst.Department = bizStock.Department;
                inst.Type = bizStock.Type;
                inst.CreatedBy = bizStock.CreatedBy;
                inst.CreatedDate = bizStock.CreatedDate;
                inst.UpdatedBy = bizStock.UpdatedBy;
                inst.UpdatedDate = bizStock.UpdatedDate;
            }
            return inst;
        }

        public List<StockModel> GetEntitiesFromBiz(List<BizLayer.Stock> bizStocks)
        {
            List<StockModel> insts = new List<StockModel>();
            if (bizStocks != null && bizStocks.Count > 0)
            {
                foreach (var bizStock in bizStocks)
                {
                    insts.Add(GetEntityFromBiz(bizStock));
                }
            }
            return insts;
        }

        public BizLayer.Stock GetBizModel(StockModel stockModel)
        {
            BizLayer.Stock bizStock = null;
            if (stockModel != null)
            {
                bizStock = new BizLayer.Stock();
                bizStock.Code = stockModel.Code;
                bizStock.Id = stockModel.Id;
                bizStock.InstoreId = stockModel.InstoreId;
                bizStock.Number = stockModel.Number;
                bizStock.UnitPrice = stockModel.UnitPrice;
                bizStock.TotalPrice = stockModel.TotalPrice;
                bizStock.Department = stockModel.Department;
                bizStock.Type = stockModel.Type;
                bizStock.CreatedBy = stockModel.CreatedBy;
                bizStock.CreatedDate = stockModel.CreatedDate;
                bizStock.UpdatedBy = stockModel.UpdatedBy;
                bizStock.UpdatedDate = stockModel.UpdatedDate;
            }
            return bizStock;
        }

        public List<BizLayer.Stock> GetBizModels(List<StockModel> stockModels)
        {
            var bizStocks = new List<BizLayer.Stock>();
            if (stockModels != null && stockModels.Count > 0)
            {
                foreach (var stockModel in stockModels)
                {
                    bizStocks.Add(GetBizModel(stockModel));
                }
            }
            return bizStocks;
        }
    }
}
