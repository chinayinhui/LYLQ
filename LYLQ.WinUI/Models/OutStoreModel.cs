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
    public class OutStoreModel
    {
        public string Id { get; set; }
        public string InstoreId { get; set; }
        public string Index { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public int Number { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<decimal> SumPrice { get; set; }
        public int BoundHeight { get; set; }
        public bool CanMerge { get; set; }
        public string Department { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Type { get; set; }

        BizLayer.OutStore _bizOutStore = new BizLayer.OutStore();
        BizLayer.InStore _bizInStore = new BizLayer.InStore();
        BizLayer.Material _bizMateriel = new BizLayer.Material();
        BizLayer.StockService _outStoreService = new BizLayer.StockService();

        public Dictionary<string, string> GetMaterialKeyValuePaire()
        {
            return _bizMateriel.GetKeyValuePairs();
        }

        public List<OutStoreModel> GetAll()
        {
            var bizOutStores = _bizOutStore.GetAll();
            var outStoreModels = new List<OutStoreModel>();
            if (bizOutStores != null && bizOutStores.Count > 0)
            {
                outStoreModels = GetEntitiesFromBiz(bizOutStores);
                var i = 1;
                foreach (var outStoreModel in outStoreModels)
                {
                    outStoreModel.Index = i.ToString().PadLeft(2, '0');
                    outStoreModel.Name = outStoreModel.Code;
                    i++;
                }
            }
            
            return outStoreModels;
        }

        public OutStoreModel GetById(string id)
        {
            var bizOst = _bizOutStore.GetById(id);

            return GetEntityFromBiz(bizOst);
        }

        public List<OutStoreModel> GetByType(string type)
        {
            var bizOutStores = _bizOutStore.GetByType(type);
            var outStoreModels = new List<OutStoreModel>();
            if (bizOutStores != null && bizOutStores.Count > 0)
            {
                outStoreModels = GetEntitiesFromBiz(bizOutStores);
                var i = 1;
                foreach (var outStoreModel in outStoreModels)
                {
                    outStoreModel.Index = i.ToString().PadLeft(2, '0');
                    outStoreModel.Name = outStoreModel.Code;
                    i++;
                }
            }

            return outStoreModels;
        }

        public void Create(OutStoreModel ost)
        {
            var dbDpt = GetBizModel(ost);
            _bizOutStore.Create(dbDpt);
        }

        public void Update(OutStoreModel ost)
        {
            var bizOst = GetBizModel(ost);
            _bizOutStore.Update(bizOst);
        }

        public void Delete(string id)
        {
            if (!UIContext.SyncInstockToStockTask.IsCompleted)
            {
                UIContext.SyncInstockToStockTask.Wait();
            }

            var outStore = _bizOutStore.GetById(id);
            _outStoreService.CancelOutStock(outStore, UIContext.LoginUser.Account);            
        }

        public void OutStore(OutStoreModel outStoreModel)
        {
            if (!UIContext.SyncInstockToStockTask.IsCompleted)
            {
                UIContext.SyncInstockToStockTask.Wait();
            }

            var outStore = GetBizModel(outStoreModel);
            _outStoreService.OutStcok(outStore, UIContext.LoginUser.Account);
        }

        public List<OutStoreModel> Query(DateTime beginDate, DateTime endDate, string type, string code, string operatorStoreOut, string deptCode = null)
        {
            var bizOutStores = _bizOutStore.Query(beginDate, endDate, type, code, operatorStoreOut, deptCode);
            var outStoreModels = new List<OutStoreModel>();
            if (bizOutStores != null && bizOutStores.Count > 0)
            {
                outStoreModels = GetEntitiesFromBiz(bizOutStores);
                var i = 1;
                foreach (var outStoreModel in outStoreModels)
                {
                    outStoreModel.Index = i.ToString().PadLeft(2, '0');
                    outStoreModel.Name = outStoreModel.Code;
                    i++;
                }
            }

            return outStoreModels;
        }

        public List<OutStoreModel> QueryCount(DateTime beginDate, DateTime endDate, string type, string code, string operatorStoreOut, string deptCode = null)
        {
            var bizOutStores = _bizOutStore.Query(beginDate, endDate, type, code, operatorStoreOut, deptCode);
            var outStoreModels = new List<OutStoreModel>();
            if (bizOutStores != null && bizOutStores.Count > 0)
            {
                bizOutStores = _bizOutStore.MergeSameUnitPriceForSameCode(bizOutStores);
                outStoreModels = GetEntitiesFromBiz(bizOutStores);
                var i = 1;
                foreach (var outStoreModel in outStoreModels)
                {
                    outStoreModel.Index = i.ToString().PadLeft(2, '0');
                    outStoreModel.Name = outStoreModel.Code;
                    i++;
                }
            }

            return outStoreModels;
        }

        public OutStoreModel GetEntityFromBiz(BizLayer.OutStore bizOst)
        {
            OutStoreModel ost = null;
            if (bizOst != null)
            {
                ost = new OutStoreModel();
                ost.Code = bizOst.Code;
                ost.Id = bizOst.Id;
                ost.InstoreId = bizOst.InstoreId;
                ost.Number = bizOst.Number;
                ost.Department = bizOst.Department;
                ost.UnitPrice = bizOst.UnitPrice;
                ost.TotalPrice = bizOst.TotalPrice;
                ost.Department = bizOst.Department;
                ost.Type = bizOst.Type;
                ost.CreatedBy = bizOst.CreatedBy;
                ost.CreatedDate = bizOst.CreatedDate;
                ost.UpdatedBy = bizOst.UpdatedBy;
                ost.UpdatedDate = bizOst.UpdatedDate;
            }
            return ost;
        }

        public void ExportToReportExcel(string reportNme, List<OutStoreModel> outStoreModels, string beginDate, string endDate)
        {
            if (outStoreModels.Count > 0)
            {                
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("统计");
                
                const int DEPARTMENT_COLUMN = 0;
                const int NAME_COLUMN = 1;
                const int TYPE_COLUMN = 2;
                const int NUMBER_COLUMN = 3;
                const int UNITPRICE_COLUMN = 4;
                const int TOTALPRICE_COLUMN = 5;
                const int SUMPRICE_COLUMN = 6;

                IRow row = sheet.CreateRow(0);
                ICell cell = row.CreateCell(DEPARTMENT_COLUMN);
                row.CreateCell(1);                
                row.CreateCell(2);
                row.CreateCell(3);
                row.CreateCell(4);
                row.CreateCell(5);
                row.CreateCell(6);
                cell.SetCellValue(string.Format("统计时间：{0}-{1}", beginDate, endDate));
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));

                ExcelHelper.SetHeaderStyle(workbook, row, 7);
                row.Cells[0].CellStyle.Alignment = HorizontalAlignment.LEFT;                

                sheet.SetColumnWidth(0, 20 * 256);
                sheet.SetColumnWidth(1, 30 * 256);
                sheet.SetColumnWidth(2, 16 * 256);
                sheet.SetColumnWidth(3, 10 * 256);
                sheet.SetColumnWidth(4, 10 * 256);
                sheet.SetColumnWidth(5, 10 * 256);
                sheet.SetColumnWidth(6, 12 * 256);             


                //标题
                row = sheet.CreateRow(1);
                cell = row.CreateCell(DEPARTMENT_COLUMN);
                cell.SetCellValue("网 点");

                cell = row.CreateCell(NAME_COLUMN);
                cell.SetCellValue("名 称");

                cell = row.CreateCell(TYPE_COLUMN);
                cell.SetCellValue("类 型");

                cell = row.CreateCell(NUMBER_COLUMN);
                cell.SetCellValue("数 量");

                cell = row.CreateCell(UNITPRICE_COLUMN, CellType.NUMERIC);
                cell.SetCellValue("单 价");

                cell = row.CreateCell(TOTALPRICE_COLUMN, CellType.NUMERIC);
                cell.SetCellValue("总 价");

                cell = row.CreateCell(SUMPRICE_COLUMN, CellType.NUMERIC);
                cell.SetCellValue("总 计");

                ExcelHelper.SetHeaderStyle(workbook, row, 7);
                row.Cells[0].CellStyle.Alignment = HorizontalAlignment.LEFT;
                row.Cells[1].CellStyle.Alignment = HorizontalAlignment.LEFT;
                row.Cells[2].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[3].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[4].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[5].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[6].CellStyle.Alignment = HorizontalAlignment.CENTER;

                var allSumPrice = GetAllSumPrice(outStoreModels);
                var i = 2;

                foreach (var outModel in outStoreModels)
                {
                    row = sheet.CreateRow(i);

                    cell = row.CreateCell(DEPARTMENT_COLUMN);
                    cell.SetCellValue(outModel.Department);

                    cell = row.CreateCell(NAME_COLUMN);
                    cell.SetCellValue(outModel.Name);

                    cell = row.CreateCell(TYPE_COLUMN);
                    cell.SetCellValue(outModel.Type);

                    cell = row.CreateCell(NUMBER_COLUMN);
                    cell.SetCellValue(outModel.Number);

                    cell = row.CreateCell(UNITPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(outModel.UnitPrice.Value));

                    cell = row.CreateCell(TOTALPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(outModel.TotalPrice.Value));

                    cell = row.CreateCell(SUMPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(allSumPrice[outModel.Department]));

                    ExcelHelper.SetBorderStyle(workbook, row, 7);
                    row.Cells[0].CellStyle.Alignment = HorizontalAlignment.LEFT;
                    row.Cells[1].CellStyle.Alignment = HorizontalAlignment.LEFT;
                    row.Cells[2].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[3].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[4].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[5].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[6].CellStyle.Alignment = HorizontalAlignment.CENTER;

                    i++;

                }
                MergeReportExcelColum(outStoreModels, sheet);
                ExcelHelper.CreateExcel(reportNme, workbook);
            }
        }

        private Dictionary<string, decimal> GetAllSumPrice(List<OutStoreModel> outStoreModels)
        {
            Dictionary<string, decimal> metailSumPrice = new Dictionary<string, decimal>();
            //var _outStoreModels = outStoreModels.OrderBy(ot => ot.Department).ToList();          
            var sumPrice = outStoreModels[0].TotalPrice.Value;
            var pre = outStoreModels[0];
            for (var i = 1; i < outStoreModels.Count; i++)
            {
                if (pre.Department == outStoreModels[i].Department)
                {
                    sumPrice += outStoreModels[i].TotalPrice.Value;
                }
                else
                {
                    metailSumPrice.Add(pre.Department, sumPrice);
                    pre = outStoreModels[i];
                    sumPrice = outStoreModels[i].TotalPrice.Value;
                }

                if (i == outStoreModels.Count - 1 && !metailSumPrice.ContainsKey(outStoreModels.Last().Department))
                {
                    metailSumPrice.Add(outStoreModels.Last().Department, sumPrice);
                }
            }
            return metailSumPrice;
        }

        private void MergeReportExcelColum(List<OutStoreModel> outStoreModels, ISheet sheet)
        {
            var preModel = outStoreModels[0];
            int row_start = 2;
            int row_end = 2;

            for (int i = 1; i < outStoreModels.Count; i++)
            {
                if (preModel.Department == outStoreModels[i].Department)
                {
                    row_end++;
                }
                else
                {
                    if (row_end > row_start)
                    {
                        sheet.AddMergedRegion(new CellRangeAddress(row_start, row_end, 0, 0));
                        sheet.AddMergedRegion(new CellRangeAddress(row_start, row_end, 6, 6));

                        row_start = row_end;
                    }
                    row_end++;
                    row_start++;
                }

                preModel = outStoreModels[i];
            }

            if (row_end > row_start)
            {
                sheet.AddMergedRegion(new CellRangeAddress(row_start, row_end, 0, 0));
                sheet.AddMergedRegion(new CellRangeAddress(row_start, row_end, 6, 6));
            }
        }

        public void ExportToOutStoreExcel(string reportNme, List<OutStoreModel> outStoreModels, string beginDate, string endDate)
        {
            if (outStoreModels.Count > 0)
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("出库记录");

                const int DEPARTMENT_COLUMN = 0;
                const int NAME_COLUMN = 1;
                const int TYPE_COLUMN = 2;
                const int NUMBER_COLUMN = 3;
                const int UNITPRICE_COLUMN = 4;
                const int TOTALPRICE_COLUMN = 5;
                const int OPERATOR_COLUMN = 6;

                IRow row = sheet.CreateRow(0);
                ICell cell = row.CreateCell(DEPARTMENT_COLUMN);
                row.CreateCell(1);
                row.CreateCell(2);
                row.CreateCell(3);
                row.CreateCell(4);
                row.CreateCell(5);
                row.CreateCell(6);
                cell.SetCellValue(string.Format("统计时间：{0}-{1}", beginDate, endDate));
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 6));

                ExcelHelper.SetHeaderStyle(workbook, row, 7);
                row.Cells[0].CellStyle.Alignment = HorizontalAlignment.LEFT;

                sheet.SetColumnWidth(0, 20 * 256);
                sheet.SetColumnWidth(1, 30 * 256);
                sheet.SetColumnWidth(2, 16 * 256);
                sheet.SetColumnWidth(3, 10 * 256);
                sheet.SetColumnWidth(4, 10 * 256);
                sheet.SetColumnWidth(5, 10 * 256);
                sheet.SetColumnWidth(6, 12 * 256);


                //标题
                row = sheet.CreateRow(1);
                cell = row.CreateCell(DEPARTMENT_COLUMN);
                cell.SetCellValue("网 点");

                cell = row.CreateCell(NAME_COLUMN);
                cell.SetCellValue("名 称");

                cell = row.CreateCell(TYPE_COLUMN);
                cell.SetCellValue("类 型");

                cell = row.CreateCell(NUMBER_COLUMN);
                cell.SetCellValue("数 量");

                cell = row.CreateCell(UNITPRICE_COLUMN, CellType.NUMERIC);
                cell.SetCellValue("单 价");

                cell = row.CreateCell(TOTALPRICE_COLUMN, CellType.NUMERIC);
                cell.SetCellValue("总 价");

                cell = row.CreateCell(OPERATOR_COLUMN, CellType.STRING);
                cell.SetCellValue("操作员");

                ExcelHelper.SetHeaderStyle(workbook, row, 7);
                row.Cells[0].CellStyle.Alignment = HorizontalAlignment.LEFT;
                row.Cells[1].CellStyle.Alignment = HorizontalAlignment.LEFT;
                row.Cells[2].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[3].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[4].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[5].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[6].CellStyle.Alignment = HorizontalAlignment.LEFT;

                var allSumPrice = GetAllSumPrice(outStoreModels);
                var i = 2;

                foreach (var outModel in outStoreModels)
                {
                    row = sheet.CreateRow(i);

                    cell = row.CreateCell(DEPARTMENT_COLUMN);
                    cell.SetCellValue(outModel.Department);

                    cell = row.CreateCell(NAME_COLUMN);
                    cell.SetCellValue(outModel.Name);

                    cell = row.CreateCell(TYPE_COLUMN);
                    cell.SetCellValue(outModel.Type);

                    cell = row.CreateCell(NUMBER_COLUMN);
                    cell.SetCellValue(outModel.Number);

                    cell = row.CreateCell(UNITPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(outModel.UnitPrice.Value));

                    cell = row.CreateCell(TOTALPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(outModel.TotalPrice.Value));

                    cell = row.CreateCell(OPERATOR_COLUMN, CellType.STRING);
                    cell.SetCellValue(outModel.UpdatedBy);

                    ExcelHelper.SetBorderStyle(workbook, row, 7);
                    row.Cells[0].CellStyle.Alignment = HorizontalAlignment.LEFT;
                    row.Cells[1].CellStyle.Alignment = HorizontalAlignment.LEFT;
                    row.Cells[2].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[3].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[4].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[5].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[6].CellStyle.Alignment = HorizontalAlignment.LEFT;

                    i++;
                }
                MergeOutStoreExcelColum(outStoreModels, sheet);
                ExcelHelper.CreateExcel(reportNme, workbook);
            }
        }        

        private void MergeOutStoreExcelColum(List<OutStoreModel> outStoreModels, ISheet sheet)
        {
            var preModel = outStoreModels[0];
            int row_start = 2;
            int row_end = 2;
           
            for (int i = 1; i < outStoreModels.Count; i++)
            {
                if (preModel.Department == outStoreModels[i].Department)
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

                preModel = outStoreModels[i];
            }

            if (row_end > row_start)
            {
                sheet.AddMergedRegion(new CellRangeAddress(row_start, row_end, 0, 0));
            }
        }

        public List<OutStoreModel> GetEntitiesFromBiz(List<BizLayer.OutStore> bizOsts)
        {
            List<OutStoreModel> osts = new List<OutStoreModel>();
            if (bizOsts != null && bizOsts.Count > 0)
            {
                foreach (var bizOst in bizOsts)
                {
                    osts.Add(GetEntityFromBiz(bizOst));
                }
            }
            return osts;
        }

        public BizLayer.OutStore GetBizModel(OutStoreModel ost)
        {
            BizLayer.OutStore bizOst = null;
            if (ost != null)
            {
                bizOst = new BizLayer.OutStore();
                bizOst.Code = ost.Code;
                bizOst.Id = ost.Id;
                bizOst.Number = ost.Number;
                bizOst.UnitPrice = ost.UnitPrice;
                bizOst.TotalPrice = ost.TotalPrice;
                bizOst.Department = ost.Department;
                bizOst.InstoreId = ost.InstoreId;
                bizOst.Type = ost.Type;
                bizOst.CreatedBy = ost.CreatedBy;
                bizOst.CreatedDate = ost.CreatedDate;
                bizOst.UpdatedBy = ost.UpdatedBy;
                bizOst.UpdatedDate = ost.UpdatedDate;
            }
            return bizOst;
        }

        public List<BizLayer.OutStore> GetBizModels(List<OutStoreModel> osts)
        {
            var bizOsts = new List<BizLayer.OutStore>();
            if (osts != null && osts.Count > 0)
            {
                foreach (var ost in osts)
                {
                    bizOsts.Add(GetBizModel(ost));
                }
            }
            return bizOsts;
        }
    }
}
