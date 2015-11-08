using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLQ.SqlServer
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

        public void Create(InStore dpt)
        {
            using (var ctx = new LYLQEntities())
            {
                ctx.InStores.Add(dpt);

                ctx.SaveChanges();
            }
        }

        public void Update(InStore dpt)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from dbInst in ctx.InStores
                             where dbInst.Id == dpt.Id
                             select dbInst;

                var dbModelInSt = dbInsts.First();
                dbModelInSt.Code = dpt.Code;                
                dbModelInSt.UnitPrice = dpt.UnitPrice;
                dbModelInSt.RemainNumber = dpt.RemainNumber;
                dbModelInSt.RemainTotalPrice = dpt.RemainTotalPrice;
                dbModelInSt.TotalPrice = dpt.TotalPrice;
                dbModelInSt.Department = dpt.Department;
                dbModelInSt.Type = dpt.Type;
                dbModelInSt.UpdatedBy = dpt.UpdatedBy;
                dbModelInSt.UpdatedDate = DateTime.Now;

                ctx.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from dbInst in ctx.InStores
                              where dbInst.Id == id
                              select dbInst;

                var dbModelInSt = dbInsts.First();
                ctx.InStores.Remove(dbModelInSt);

                ctx.SaveChanges();
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

        public void OutStore(InStore dpt)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbInsts = from dbInst in ctx.InStores
                              where dbInst.Id == dpt.Id
                              select dbInst;

                var dbModelInSt = dbInsts.First();                
                dbModelInSt.RemainNumber = dpt.RemainNumber;
                dbModelInSt.RemainTotalPrice = dpt.RemainTotalPrice;    
                dbModelInSt.UpdatedBy = dpt.UpdatedBy;
                dbModelInSt.UpdatedDate = DateTime.Now;

                ctx.SaveChanges();
            }
        }
    }
}
