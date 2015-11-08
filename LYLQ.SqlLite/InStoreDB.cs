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
    public partial class InStore
    {
        public List<InStore> GetAll()
        {
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from dpt in ctx.InStores
                             orderby dpt.UpdatedDate descending
                             select dpt;

                return dbInsts.ToList();
            }
        }

        public List<InStore> GetRemainAll()
        {
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from instore in ctx.InStores
                              where instore.RemainNumber > 0
                              orderby instore.UpdatedDate descending
                              select instore;

                return dbInsts.ToList();
            }
        }

        public InStore GetById(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from inst in ctx.InStores
                              where inst.Id == id
                             select inst;

                return dbInsts.FirstOrDefault();
            }
        }

        public List<InStore> GetByType(string type)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from inst in ctx.InStores
                              where inst.Type == type
                              select inst;

                return dbInsts.ToList();
            }
        }

        public List<InStore> GetByCodeUnitPrice(string code, decimal unitPrice)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from inst in ctx.InStores
                              where inst.Code == code && inst.UnitPrice == unitPrice && inst.RemainNumber > 0
                              select inst;

                return dbInsts.ToList();
            }
        }

        public List<InStore> GetKCByType(string type, string code)
        {
            using (var ctx = new LYLQEntities())
            {
                type = type ?? "";
                code = code ?? "";
                var dbInsts = from inst in ctx.InStores
                              where (type == "" ? true : inst.Type == type) && (code == "" ? true : inst.Code == code) && inst.RemainNumber > 0
                              select inst;

                return dbInsts.ToList();
            }
        }

        public void Create(InStore instroe)
        {
            using (var ctx = new LYLQEntities())
            {
                //ctx.InStores.Add(instroe);

                //ctx.SaveChanges();

                string sql = @"INSERT INTO InStore(Code,CreatedBy,CreatedDate,Department,Id,Number,RemainNumber,RemainTotalPrice,TotalPrice,Type,UnitPrice,UpdatedBy,UpdatedDate)VALUES(
                                                    @Code,@CreatedBy,@CreatedDate,@Department,@Id,@Number,@RemainNumber,@RemainTotalPrice,@TotalPrice,@Type,@UnitPrice,@UpdatedBy,@UpdatedDate)";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Code", instroe.Code));
                sqlParams.Add(new SQLiteParameter("@CreatedBy", instroe.CreatedBy));
                sqlParams.Add(new SQLiteParameter("@CreatedDate", instroe.CreatedDate));
                sqlParams.Add(new SQLiteParameter("@Department", instroe.Department));
                sqlParams.Add(new SQLiteParameter("@Id", instroe.Id));
                sqlParams.Add(new SQLiteParameter("@Number", instroe.Number));
                sqlParams.Add(new SQLiteParameter("@RemainNumber", instroe.RemainNumber));
                sqlParams.Add(new SQLiteParameter("@RemainTotalPrice", instroe.RemainTotalPrice));
                sqlParams.Add(new SQLiteParameter("@TotalPrice", instroe.TotalPrice));
                sqlParams.Add(new SQLiteParameter("@Type", instroe.Type));
                sqlParams.Add(new SQLiteParameter("@UnitPrice", instroe.UnitPrice));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", instroe.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", instroe.UpdatedDate));


                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Update(InStore instore)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbInsts = from dbInst in ctx.InStores
                //             where dbInst.Id == dpt.Id
                //             select dbInst;

                //var dbModelInSt = dbInsts.First();
                //dbModelInSt.Code = dpt.Code;                
                //dbModelInSt.UnitPrice = dpt.UnitPrice;
                //dbModelInSt.RemainNumber = dpt.RemainNumber;
                //dbModelInSt.RemainTotalPrice = dpt.RemainTotalPrice;
                //dbModelInSt.TotalPrice = dpt.TotalPrice;
                //dbModelInSt.Department = dpt.Department;
                //dbModelInSt.Type = dpt.Type;
                //dbModelInSt.UpdatedBy = dpt.UpdatedBy;
                //dbModelInSt.UpdatedDate = DateTime.Now;

                //ctx.SaveChanges();

                string sql = @"UPDATE InStore SET Code = @Code,         
                                                UnitPrice = @UnitPrice,      
                                                RemainNumber = @RemainNumber,      
                                                RemainTotalPrice = @RemainTotalPrice,      
                                                TotalPrice = @TotalPrice,      
                                                Department = @Department,      
                                                Type = @Type,                                                                                                                
                                                UpdatedBy = @UpdatedBy, 
                                                UpdatedDate = @UpdatedDate 
                                            WHERE Id = '" + instore.Id + "'";

                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Code", instore.Code));
                sqlParams.Add(new SQLiteParameter("@UnitPrice", instore.UnitPrice));
                sqlParams.Add(new SQLiteParameter("@RemainNumber", instore.RemainNumber));
                sqlParams.Add(new SQLiteParameter("@RemainTotalPrice", instore.RemainTotalPrice));
                sqlParams.Add(new SQLiteParameter("@TotalPrice", instore.TotalPrice));
                sqlParams.Add(new SQLiteParameter("@Department", instore.Department));
                sqlParams.Add(new SQLiteParameter("@Type", instore.Type));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", instore.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", instore.UpdatedDate));

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Delete(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbInsts = from dbInst in ctx.InStores
                //              where dbInst.Id == id
                //              select dbInst;

                //var dbModelInSt = dbInsts.First();
                //ctx.InStores.Remove(dbModelInSt);

                //ctx.SaveChanges();

                string sql = @"DELETE FROM InStore WHERE Id = @Id";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Id", id));
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Delete()
        {
            using (var ctx = new LYLQEntities())
            {
                string sql = @"DELETE FROM InStore";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public List<InStore> Query(DateTime beginDate, DateTime endDate, string type, string code, string operatorStoreIn)
        {            
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from dbInst in ctx.InStores
                              where (dbInst.UpdatedDate >= beginDate && dbInst.UpdatedDate <= endDate) && 
                                    (type != null ? dbInst.Type == type : 1== 1) && 
                                    (code != null ? dbInst.Code == code : 1== 1) &&
                                    (operatorStoreIn != null ? dbInst.UpdatedBy == operatorStoreIn : 1 == 1)
                              orderby dbInst.UpdatedDate descending, dbInst.Type
                              select dbInst;

                return dbInsts.ToList();                
            }
        }
        
    }
}
