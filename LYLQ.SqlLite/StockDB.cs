using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLQ.SqLite
{
    public partial class Stock
    {
        public Stock GetByInstoreId(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbStocks = from stock in ctx.Stocks
                              where stock.InstoreId == id 
                              //orderby UpdatedDate descending
                              select stock;

                var stocks = dbStocks.ToList().OrderByDescending(st => st.UpdatedDate);

                return stocks.FirstOrDefault();
            }
        }

        public List<Stock> Query(DateTime beginDate, DateTime endDate, string type, string code)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbStocks = from stock in ctx.Stocks
                               where (stock.UpdatedDate >= beginDate && stock.UpdatedDate <= endDate) && 
                                     (type != null ? stock.Type == type : 1== 1) && 
                                     (code != null ? stock.Code == code : 1== 1)
                               select stock;

                

                return dbStocks.ToList();
            }
        }

        public List<Stock> QueryPre(DateTime beginDate, DateTime endDate, string type, string code)
        {
            using (var ctx = new LYLQEntities())
            {
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", beginDate));

                string sql = @"SELECT *  FROM  Stock WHERE UpdatedDate < @UpdatedDate ORDER BY UpdatedDate DESC";

                var stockRow = ctx.Database.SqlQuery<Stock>(sql, sqlParams.ToArray()).FirstOrDefault();
                if (stockRow != null)
                {
                    beginDate = Convert.ToDateTime(stockRow.UpdatedDate.Value.ToShortDateString() + " 00:00:00");
                    endDate = Convert.ToDateTime(stockRow.UpdatedDate.Value.ToShortDateString() + " 23:59:59");
                    var dbStocks = from stock in ctx.Stocks
                                   where (stock.UpdatedDate >= beginDate && stock.UpdatedDate <= endDate) &&
                                         (type != null ? stock.Type == type : 1 == 1) &&
                                         (code != null ? stock.Code == code : 1 == 1)
                                   select stock;

                    return dbStocks.ToList();
                }

                return new List<Stock>();
            }
        }

        public List<Stock> QueryNext(DateTime beginDate, DateTime endDate, string type, string code)
        {
            using (var ctx = new LYLQEntities())
            {
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", beginDate));

                string sql = @"SELECT *  FROM  Stock WHERE UpdatedDate > @UpdatedDate ORDER BY UpdatedDate ASC";

                var stockRow = ctx.Database.SqlQuery<Stock>(sql, sqlParams.ToArray()).FirstOrDefault();
                if (stockRow != null)
                {
                    beginDate = Convert.ToDateTime(stockRow.UpdatedDate.Value.ToShortDateString() + " 00:00:00");
                    endDate = Convert.ToDateTime(stockRow.UpdatedDate.Value.ToShortDateString() + " 23:59:59");
                    var dbStocks = from stock in ctx.Stocks
                                   where (stock.UpdatedDate >= beginDate && stock.UpdatedDate <= endDate) &&
                                         (type != null ? stock.Type == type : 1 == 1) &&
                                         (code != null ? stock.Code == code : 1 == 1)
                                   select stock;

                    return dbStocks.ToList();
                }

                return new List<Stock>();
            }
        }

        public void Update(Stock stock)
        {
            using (var ctx = new LYLQEntities())
            {
                string sql = @"UPDATE Stock SET Number = @Number,    
                                                TotalPrice = @TotalPrice,                                                                                                                                                 
                                                UpdatedBy = @UpdatedBy, 
                                                UpdatedDate = @UpdatedDate 
                                            WHERE Id = '" + stock.Id + "'";

                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Number", stock.Number));
                sqlParams.Add(new SQLiteParameter("@TotalPrice", stock.TotalPrice));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", stock.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", stock.UpdatedDate));

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Create(Stock stock)
        {
            using (var ctx = new LYLQEntities())
            {
                string sql = @"INSERT INTO Stock(Code,CreatedBy,CreatedDate,Department,Id,InstoreId,Number,TotalPrice,Type,UnitPrice,UpdatedBy,UpdatedDate)VALUES(
                                                @Code,@CreatedBy,@CreatedDate,@Department,@Id,@InstoreId,@Number,@TotalPrice,@Type,@UnitPrice,@UpdatedBy,@UpdatedDate)";

                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Code", stock.Code));
                sqlParams.Add(new SQLiteParameter("@CreatedBy", stock.CreatedBy));
                sqlParams.Add(new SQLiteParameter("@CreatedDate", stock.CreatedDate));
                sqlParams.Add(new SQLiteParameter("@Department", stock.Department));
                sqlParams.Add(new SQLiteParameter("@Id", stock.Id));
                sqlParams.Add(new SQLiteParameter("@InstoreId", stock.InstoreId));
                sqlParams.Add(new SQLiteParameter("@Number", stock.Number));
                sqlParams.Add(new SQLiteParameter("@TotalPrice", stock.TotalPrice));
                sqlParams.Add(new SQLiteParameter("@Type", stock.Type));
                sqlParams.Add(new SQLiteParameter("@UnitPrice", stock.UnitPrice));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", stock.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", stock.UpdatedDate));


                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Delete(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                string sql = @"DELETE FROM Stock WHERE Id = @Id";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Id", id));
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Delete()
        {
            using (var ctx = new LYLQEntities())
            {
                string sql = @"DELETE FROM Stock";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }
    }
}
