using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer = LYLQ.SqLite;

namespace LYLQ.Business
{
    public class Stock
    {
        public string Id { get; set; }
        public string InstoreId { get; set; }
        public string Code { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public int Number { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public string Department { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Type { get; set; }
       

        DBLayer.Stock _dbStock = new DBLayer.Stock();

        public Stock GetByInstoreId(string id)
        {
            var dbStock = _dbStock.GetByInstoreId(id);

            return GetEntityFromDB(dbStock);
        }        

        public void Create(Stock stock)
        {
            var dbStock = GetDBModel(stock);
            _dbStock.Create(dbStock);
        }

        public void Update(Stock stock)
        {
            var dbStock = GetDBModel(stock);
            _dbStock.Update(dbStock);
        }

        public void Delete(string id)
        {
            _dbStock.Delete(id);
        }

        public void Delete()
        {
            _dbStock.Delete();
        }

        public List<Stock> Query(DateTime beginDate, DateTime endDate, string type, string code)
        {
            var dbInstores = _dbStock.Query(beginDate, endDate, type, code);
            return GetEntitiesFromDB(dbInstores);
        }

        public List<Stock> QueryPre(DateTime beginDate, DateTime endDate, string type, string code)
        {
            var dbInstores = _dbStock.QueryPre(beginDate, endDate, type, code);
            return GetEntitiesFromDB(dbInstores);
        }

        public List<Stock> QueryNext(DateTime beginDate, DateTime endDate, string type, string code)
        {
            var dbInstores = _dbStock.QueryNext(beginDate, endDate, type, code);
            return GetEntitiesFromDB(dbInstores);
        }

        public List<Stock> MergeSameUnitPriceForSameCode(List<Stock> stocks)
        {
            var orderStocks = (from stock in stocks
                                orderby stock.Code, stock.UnitPrice
                                select stock).ToList();

            var prevInstore = orderStocks.First();
            for (var i = 0; i < orderStocks.Count; i++)
            {
                var instoreMode = orderStocks[i];
                if (prevInstore.Id != instoreMode.Id &&
                    prevInstore.Code == instoreMode.Code &&
                    prevInstore.UnitPrice == instoreMode.UnitPrice)
                {
                    prevInstore.Number += instoreMode.Number;
                    prevInstore.TotalPrice += instoreMode.TotalPrice;
                    orderStocks.Remove(instoreMode);
                    i--;
                }
                else
                {
                    prevInstore = instoreMode;
                }
            }

            return orderStocks;
        }        

        public Stock GetEntityFromDB(DBLayer.Stock dbStock)
        {
            Stock stock = null;
            if (dbStock != null)
            {
                stock = new Stock();
                stock.Code = dbStock.Code;                
                stock.Id = dbStock.Id;
                stock.InstoreId = dbStock.InstoreId;
                stock.Number = dbStock.Number;
                stock.UnitPrice = dbStock.UnitPrice;
                stock.TotalPrice = dbStock.TotalPrice;
                stock.Department = dbStock.Department;
                stock.Type = dbStock.Type;
                stock.CreatedBy = dbStock.CreatedBy;
                stock.CreatedDate = dbStock.CreatedDate;
                stock.UpdatedBy = dbStock.UpdatedBy;
                stock.UpdatedDate = dbStock.UpdatedDate;
            }
            return stock;
        }

        public List<Stock> GetEntitiesFromDB(List<DBLayer.Stock> dbInsts)
        {
            List<Stock> insts = new List<Stock>();
            if (dbInsts != null && dbInsts.Count > 0)
            {
                foreach (var dbInst in dbInsts)
                {
                    insts.Add(GetEntityFromDB(dbInst));
                }
            }
            return insts;
        }

        public DBLayer.Stock GetDBModel(Stock stock)
        {
            DBLayer.Stock dbStock = null;
            if (stock != null)
            {
                dbStock = new DBLayer.Stock();
                dbStock.Code = stock.Code;
                dbStock.Id = stock.Id;
                dbStock.InstoreId = stock.InstoreId;
                dbStock.Number = stock.Number;
                dbStock.UnitPrice = stock.UnitPrice;
                dbStock.TotalPrice = stock.TotalPrice;
                dbStock.Department = stock.Department;
                dbStock.Type = stock.Type;
                dbStock.CreatedBy = stock.CreatedBy;
                dbStock.CreatedDate = stock.CreatedDate;
                dbStock.UpdatedBy = stock.UpdatedBy;
                dbStock.UpdatedDate = stock.UpdatedDate;
            }
            return dbStock;
        }

        public List<DBLayer.Stock> GetDBModels(List<Stock> stocks)
        {
            var dbStocks = new List<DBLayer.Stock>();
            if (stocks != null && stocks.Count > 0)
            {
                foreach (var dpt in stocks)
                {
                    dbStocks.Add(GetDBModel(dpt));
                }
            }
            return dbStocks;
        }
    }
}
