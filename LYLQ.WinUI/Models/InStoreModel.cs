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
    public class InStoreModel
    {
        public string Id { get; set; }
        public string UnitIds { get; set; }
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
        public int RemainNumber { get; set; }
        public decimal RemainTotalPrice { get; set; }        

        BizLayer.InStore _bizInStore = new BizLayer.InStore();
        BizLayer.StockService _bizStockService = new BizLayer.StockService();
        BizLayer.Material _bizMateriel = new BizLayer.Material();

        public Dictionary<string, string> GetMaterialKeyValuePaire()
        {
            return _bizMateriel.GetKeyValuePairs();
        }

        public List<InStoreModel> GetAll()
        {
            var mats = _bizInStore.GetAll();          
            var stores = new List<InStoreModel>();
            var i = 1;
            foreach (var mat in mats)
            {
                var store = new InStoreModel();
                store.Index = i.ToString().PadLeft(2, '0');
                store.Id = mat.Id;
                store.Code = mat.Code;
                store.Name = mat.Code;
                store.Number = mat.Number;
                store.RemainNumber = mat.RemainNumber;
                store.RemainTotalPrice = mat.RemainTotalPrice;                
                store.UnitPrice = mat.UnitPrice;
                store.TotalPrice = mat.TotalPrice;
                store.CreatedBy = mat.CreatedBy;
                store.CreatedDate = mat.CreatedDate;
                store.UpdatedBy = mat.UpdatedBy;
                store.UpdatedDate = mat.UpdatedDate;
                stores.Add(store);
                i++;
            }
            return stores;
        }

        public List<InStoreModel> GetInData(string type)
        {
            var mats = _bizMateriel.GetByType(type);
            var stores = new List<InStoreModel>();
            var i = 1;
            foreach (var mat in mats)
            {
                var store = new InStoreModel();
                store.Index = i.ToString().PadLeft(2,'0');
                store.Code = mat.Code;
                store.Name = mat.Name;
                stores.Add(store);
                i++;
            }
            return stores;
        }

        public InStoreModel GetById(string id)
        {
            var dbDpt = _bizInStore.GetById(id);

            return GetEntityFromBiz(dbDpt);
        }

        public List<InStoreModel> GetKCByType(string type, string code = null)
        {
            var bizInstores = _bizInStore.GetKCByType(type, code);            
            var inStoreModels = new List<InStoreModel>();
            if (bizInstores != null && bizInstores.Count > 0)
            {
                bizInstores = _bizInStore.MergeSameUnitPriceForSameCode(bizInstores);
                inStoreModels = GetEntitiesFromBiz(bizInstores);
                var i = 1;
                foreach (var instoreModel in inStoreModels)
                {
                    var store = new InStoreModel();
                    instoreModel.Index = i.ToString().PadLeft(2, '0');                   
                    instoreModel.Name = instoreModel.Code;                    
                    i++;
                }
            }            
            return inStoreModels;
        }

        public List<InStoreModel> GetByType(string type)
        {
            var mats = _bizInStore.GetByType(type);

            var stores = new List<InStoreModel>();
            var i = 1;
            foreach (var mat in mats)
            {
                var store = new InStoreModel();
                store.Index = i.ToString().PadLeft(2, '0');
                store.Id = mat.Id;
                store.Code = mat.Code;
                store.Name = mat.Code;
                store.Number = mat.Number;
                store.RemainNumber = mat.RemainNumber;
                store.RemainTotalPrice = mat.RemainTotalPrice;                
                store.UnitPrice = mat.UnitPrice;
                store.TotalPrice = mat.TotalPrice;
                store.CreatedBy = mat.CreatedBy;
                store.CreatedDate = mat.CreatedDate;
                store.UpdatedBy = mat.UpdatedBy;
                store.UpdatedDate = mat.UpdatedDate;
                stores.Add(store);
                i++;
            }
            return stores;
        }

        public void Create(InStoreModel instoreModel)
        {
            var bizStore = GetBizModel(instoreModel);
            //_bizInStore.Create(dbDpt);
            _bizStockService.Instock(bizStore);
        }

        public void Update(InStoreModel instoreModel)
        {
            var dbInstore = GetBizModel(instoreModel);
            _bizInStore.Update(dbInstore);
        }

        public void Delete(string id)
        {
            //_bizInStore.Delete(id);
            _bizStockService.CancelInStock(id);
        }

        public List<InStoreModel> Query(DateTime beginDate, DateTime endDate, string type, string code, string operatorStoreIn)
        {
            var bizInstores = _bizInStore.Query(beginDate, endDate, type, code, operatorStoreIn);
            var inStoreModels = new List<InStoreModel>();
            if(bizInstores != null &&　bizInstores.Count > 0)
            {
                inStoreModels　=　GetEntitiesFromBiz(bizInstores);
                var i = 1;
                foreach (var inStoreModel in inStoreModels)
                {
                    inStoreModel.Name = inStoreModel.Code;
                    inStoreModel.Index = i.ToString().PadLeft(2, '0');
                    i++;
                }
            }

            return inStoreModels;
        }

        public void ExportToExcel(string reportNme, List<InStoreModel> inStoreModels, string beginDate, string endDate)
        {
            if (inStoreModels.Count > 0)
            {
                //var _inStoreModels = (from store in inStoreModels
                //                       orderby store.Code
                //                       select store).ToList();
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("入库记录");


                const int TYPE_COLUMN = 0;
                const int NAME_COLUMN = 1;                
                const int NUMBER_COLUMN = 2;
                const int UNITPRICE_COLUMN = 3;
                const int TOTALPRICE_COLUMN = 4;
                const int OPERATOR_COLUMN = 5;

                //统计时间
                IRow row = sheet.CreateRow(0);
                ICell cell = row.CreateCell(TYPE_COLUMN);
                row.CreateCell(1);
                row.CreateCell(2);
                row.CreateCell(3);
                row.CreateCell(4);
                row.CreateCell(5);
                cell.SetCellValue(string.Format("统计时间：{0}-{1}", beginDate, endDate));
                row.Cells[0].CellStyle.Alignment = HorizontalAlignment.LEFT;
                row.Cells[0].CellStyle.VerticalAlignment = VerticalAlignment.CENTER;               
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 5));
                ExcelHelper.SetHeaderStyle(workbook, row, 6);

                sheet.SetColumnWidth(0, 16 * 256);
                sheet.SetColumnWidth(1, 30 * 256);
                sheet.SetColumnWidth(2, 10 * 256);
                sheet.SetColumnWidth(3, 10 * 256);
                sheet.SetColumnWidth(4, 10 * 256);
                sheet.SetColumnWidth(5, 12 * 256);

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

                cell = row.CreateCell(OPERATOR_COLUMN, CellType.STRING);
                cell.SetCellValue("操作员");
                ExcelHelper.SetHeaderStyle(workbook, row, 6);                
                                      

                row.Cells[0].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[1].CellStyle.Alignment = HorizontalAlignment.LEFT;
                row.Cells[2].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[3].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[4].CellStyle.Alignment = HorizontalAlignment.CENTER;
                row.Cells[5].CellStyle.Alignment = HorizontalAlignment.LEFT;

                

                var i = 2;
                foreach (var inStoreModel in inStoreModels)
                {
                    row = sheet.CreateRow(i);

                    cell = row.CreateCell(TYPE_COLUMN);
                    cell.SetCellValue(inStoreModel.Type);

                    cell = row.CreateCell(NAME_COLUMN);
                    cell.SetCellValue(inStoreModel.Name);                    

                    cell = row.CreateCell(NUMBER_COLUMN);
                    cell.SetCellValue(inStoreModel.Number);

                    cell = row.CreateCell(UNITPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(inStoreModel.UnitPrice.Value));

                    cell = row.CreateCell(TOTALPRICE_COLUMN, CellType.NUMERIC);
                    cell.SetCellValue(Convert.ToDouble(inStoreModel.TotalPrice.Value));

                    cell = row.CreateCell(OPERATOR_COLUMN, CellType.STRING);
                    cell.SetCellValue(inStoreModel.UpdatedBy);

                    ExcelHelper.SetBorderStyle(workbook, row, 6);
                    row.Cells[0].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[1].CellStyle.Alignment = HorizontalAlignment.LEFT;
                    row.Cells[2].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[3].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[4].CellStyle.Alignment = HorizontalAlignment.CENTER;
                    row.Cells[5].CellStyle.Alignment = HorizontalAlignment.LEFT;

                    i++;

                }
                MergeColum(inStoreModels, sheet);
                ExcelHelper.CreateExcel(reportNme, workbook);
            }
        }

        private void MergeColum(List<InStoreModel> inStoreModels, ISheet sheet)
        {
            var preModel = inStoreModels[0];
            int row_start = 2;
            int row_end = 2;

            for (int i = 1; i < inStoreModels.Count; i++)
            {
                if (preModel.Type == inStoreModels[i].Type)
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

                preModel = inStoreModels[i];
            }

            if (row_end > row_start)
            {
                sheet.AddMergedRegion(new CellRangeAddress(row_start, row_end, 0, 0));
            }
        }

        public InStoreModel GetEntityFromBiz(BizLayer.InStore bizInst)
        {
            InStoreModel inst = null;
            if (bizInst != null)
            {
                inst = new InStoreModel();
                inst.Code = bizInst.Code;
                inst.Id = bizInst.Id;
                inst.Number = bizInst.Number;
                inst.RemainNumber = bizInst.RemainNumber;
                inst.RemainTotalPrice = bizInst.RemainTotalPrice;                
                inst.UnitPrice = bizInst.UnitPrice;
                inst.TotalPrice = bizInst.TotalPrice;
                inst.Department = bizInst.Department;
                inst.Type = bizInst.Type;
                inst.CreatedBy = bizInst.CreatedBy;
                inst.CreatedDate = bizInst.CreatedDate;
                inst.UpdatedBy = bizInst.UpdatedBy;
                inst.UpdatedDate = bizInst.UpdatedDate;
            }
            return inst;
        }

        public List<InStoreModel> GetEntitiesFromBiz(List<BizLayer.InStore> bizInsts)
        {
            List<InStoreModel> insts = new List<InStoreModel>();
            if (bizInsts != null && bizInsts.Count > 0)
            {
                foreach (var dbInst in bizInsts)
                {
                    insts.Add(GetEntityFromBiz(dbInst));
                }
            }
            return insts;
        }

        public BizLayer.InStore GetBizModel(InStoreModel dpt)
        {
            BizLayer.InStore dbInst = null;
            if (dpt != null)
            {
                dbInst = new BizLayer.InStore();
                dbInst.Code = dpt.Code;
                dbInst.Id = dpt.Id;
                dbInst.Number = dpt.Number;
                dbInst.RemainNumber = dpt.RemainNumber;
                dbInst.RemainTotalPrice = dpt.RemainTotalPrice;                
                dbInst.UnitPrice = dpt.UnitPrice;
                dbInst.TotalPrice = dpt.TotalPrice;
                dbInst.Department = dpt.Department;
                dbInst.Type = dpt.Type;
                dbInst.CreatedBy = dpt.CreatedBy;
                dbInst.CreatedDate = dpt.CreatedDate;
                dbInst.UpdatedBy = dpt.UpdatedBy;
                dbInst.UpdatedDate = dpt.UpdatedDate;
            }
            return dbInst;
        }

        public List<BizLayer.InStore> GetBizModels(List<InStoreModel> insts)
        {
            var bizInsts = new List<BizLayer.InStore>();
            if (insts != null && insts.Count > 0)
            {
                foreach (var inst in insts)
                {
                    bizInsts.Add(GetBizModel(inst));
                }
            }
            return bizInsts;
        }
    }
}
