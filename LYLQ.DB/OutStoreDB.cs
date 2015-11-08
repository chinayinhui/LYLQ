using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLQ.SqlServer
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
                ctx.OutStores.Add(ots);

                ctx.SaveChanges();
            }
        }

        public void Update(OutStore outStore)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbOuts = from dbOut in ctx.OutStores
                              where dbOut.Id == outStore.Id
                              select dbOut;

                var dbModelOut = dbOuts.First();
                dbModelOut.InstoreId = outStore.InstoreId;
                dbModelOut.Code = outStore.Code;
                dbModelOut.UnitPrice = outStore.UnitPrice;
                dbModelOut.Number = outStore.Number;
                dbModelOut.TotalPrice = outStore.TotalPrice;
                dbModelOut.Department = outStore.Department;
                dbModelOut.Type = outStore.Type;
                dbModelOut.UpdatedBy = outStore.UpdatedBy;
                dbModelOut.UpdatedDate = DateTime.Now;

                ctx.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbOuts = from dbOut in ctx.OutStores
                             where dbOut.Id == id
                             select dbOut;

                var dbModelOut = dbOuts.First();
                ctx.OutStores.Remove(dbModelOut);

                ctx.SaveChanges();
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
