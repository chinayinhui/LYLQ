using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.SQLite.Linq;

namespace LYLQ.SqLite
{
    public partial class OutStore
    {
        public List<OutStore> GetAll()
        {
            using (var ctx = new LYLQEntities())
            {
                var dbOsts = from ost in ctx.OutStores
                              orderby ost.UpdatedDate descending
                              select ost;

                return dbOsts.ToList();
            }
        }

        public OutStore GetById(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbOsts = from ost in ctx.OutStores
                              where ost.Id == id
                              select ost;

                return dbOsts.FirstOrDefault();
            }
        }

        public List<OutStore> GetByType(string type)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbOsts = from outs in ctx.OutStores
                              where outs.Type == type
                              select outs;

                return dbOsts.ToList();
            }
        }

        public void Create(OutStore ots)
        {
            using (var ctx = new LYLQEntities())
            {
                //ctx.OutStores.Add(ots);

                //ctx.SaveChanges();

                string sql = @"INSERT INTO OutStore(Code,CreatedBy,CreatedDate,Department,Id,InstoreId,Number,TotalPrice,Type,UnitPrice,UpdatedBy,UpdatedDate)VALUES(
                                                    @Code,@CreatedBy,@CreatedDate,@Department,@Id,@InstoreId,@Number,@TotalPrice,@Type,@UnitPrice,@UpdatedBy,@UpdatedDate)";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Code", ots.Code));
                sqlParams.Add(new SQLiteParameter("@CreatedBy", ots.CreatedBy));
                sqlParams.Add(new SQLiteParameter("@CreatedDate", ots.CreatedDate));
                sqlParams.Add(new SQLiteParameter("@Department", ots.Department));
                sqlParams.Add(new SQLiteParameter("@Id", ots.Id));
                sqlParams.Add(new SQLiteParameter("@InstoreId", ots.InstoreId));
                sqlParams.Add(new SQLiteParameter("@Number", ots.Number));
                sqlParams.Add(new SQLiteParameter("@TotalPrice", ots.TotalPrice));
                sqlParams.Add(new SQLiteParameter("@Type", ots.Type));
                sqlParams.Add(new SQLiteParameter("@UnitPrice", ots.UnitPrice));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", ots.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", ots.UpdatedDate));

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Update(OutStore outStore)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbOuts = from dbOut in ctx.OutStores
                //              where dbOut.Id == outStore.Id
                //              select dbOut;

                //var dbModelOut = dbOuts.First();
                //dbModelOut.InstoreId = outStore.InstoreId;
                //dbModelOut.Code = outStore.Code;
                //dbModelOut.UnitPrice = outStore.UnitPrice;
                //dbModelOut.Number = outStore.Number;
                //dbModelOut.TotalPrice = outStore.TotalPrice;
                //dbModelOut.Department = outStore.Department;
                //dbModelOut.Type = outStore.Type;
                //dbModelOut.UpdatedBy = outStore.UpdatedBy;
                //dbModelOut.UpdatedDate = DateTime.Now;

                //ctx.SaveChanges();

                string sql = @"UPDATE OutStore SET InstoreId = @InstoreId, 
                                                Code = @Code, 
                                                UnitPrice= @UnitPrice, 
                                                Number= @Number, 
                                                TotalPrice= @TotalPrice,                                                
                                                Department= @Department, 
                                                Type= @Type, 
                                                UpdatedBy = @UpdatedBy, 
                                                UpdatedDate = @UpdatedDate 
                                            WHERE Id = '" + outStore.Id + "'";

                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@InstoreId", outStore.InstoreId));
                sqlParams.Add(new SQLiteParameter("@Code", outStore.Code));
                sqlParams.Add(new SQLiteParameter("@UnitPrice", outStore.UnitPrice));
                sqlParams.Add(new SQLiteParameter("@Number", outStore.Number));
                sqlParams.Add(new SQLiteParameter("@TotalPrice", outStore.TotalPrice));
                sqlParams.Add(new SQLiteParameter("@Department", outStore.Department));
                sqlParams.Add(new SQLiteParameter("@Type", outStore.Type));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", outStore.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", outStore.UpdatedDate));

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());               
            }
        }

        public void Delete(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbOuts = from dbOut in ctx.OutStores
                //             where dbOut.Id == id
                //             select dbOut;

                //var dbModelOut = dbOuts.First();
                //ctx.OutStores.Remove(dbModelOut);

                //ctx.SaveChanges();

                string sql = @"DELETE FROM OutStore WHERE Id = @Id";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Id", id));
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());

                
            }
        }

        public void Delete()
        {
            using (var ctx = new LYLQEntities())
            {
                string sql = @"DELETE FROM OutStore";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public List<OutStore> Query(DateTime beginDate, DateTime endDate, string type, string code, string operatorStoreOut, string deptCode = null)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbOutStores = from dboutStore in ctx.OutStores
                              where (dboutStore.UpdatedDate >= beginDate && dboutStore.UpdatedDate <= endDate) &&
                                    (type != null ? dboutStore.Type == type : 1 == 1) &&
                                    (code != null ? dboutStore.Code == code : 1 == 1) &&
                                    (operatorStoreOut != null ? dboutStore.UpdatedBy == operatorStoreOut : 1 == 1) && 
                                    (deptCode != null ? dboutStore.Department == deptCode : 1 == 1 )
                              orderby dboutStore.UpdatedDate descending, dboutStore.Department
                              select dboutStore;

                return dbOutStores.ToList();
            }
        }
    }
}
