using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer = LYLQ.SqLite;

namespace LYLQ.Business
{
    public class OutStore
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

        DBLayer.OutStore _dbOutStore = new DBLayer.OutStore();

        public List<OutStore> GetAll()
        {
            var dbOutStores = _dbOutStore.GetAll();

            return GetEntitiesFromDB(dbOutStores);
        }

        public OutStore GetById(string id)
        {
            var dbOutStore = _dbOutStore.GetById(id);

            return GetEntityFromDB(dbOutStore);
        }

        public List<OutStore> GetByType(string type)
        {
            var dbOutStores = _dbOutStore.GetByType(type);

            return GetEntitiesFromDB(dbOutStores);
        }

        public void Create(OutStore ost)
        {
            var dbOutStore = GetDBModel(ost);
            _dbOutStore.Create(dbOutStore);
        }

        public void Update(OutStore ost)
        {
            var dbDpt = GetDBModel(ost);
            _dbOutStore.Update(dbDpt);
        }

        public void Delete(string id)
        {
            _dbOutStore.Delete(id);
        }

        public void Delete()
        {
            _dbOutStore.Delete();
        }

        public List<OutStore> MergeSameUnitPriceForSameCode(List<OutStore> outStores)
        {
            var sortOutStores = (from outStore in outStores
                                orderby outStore.Code, outStore.UnitPrice
                                select outStore).ToList();

            var prevOutStore = sortOutStores.First();
            for (var i = 0; i < sortOutStores.Count; i++)
            {
                var outStoreMode = sortOutStores[i];
                if (prevOutStore.Id != outStoreMode.Id &&
                    prevOutStore.Code == outStoreMode.Code &&
                    prevOutStore.Department == outStoreMode.Department && 
                    prevOutStore.UnitPrice == outStoreMode.UnitPrice)
                {                    
                    prevOutStore.Number += outStoreMode.Number;
                    prevOutStore.TotalPrice += outStoreMode.TotalPrice;
                    sortOutStores.Remove(outStoreMode);
                    i--;
                }
                else
                {
                    prevOutStore = outStoreMode;
                }
            }

            return sortOutStores;
        }
        
        public List<OutStore> Query(DateTime beginDate, DateTime endDate, string type, string code, string operatorStoreOut, string deptCode = null)
        {
            var dbOutStores = _dbOutStore.Query(beginDate, endDate, type, code, operatorStoreOut, deptCode);

            return GetEntitiesFromDB(dbOutStores);
        }

        public OutStore GetEntityFromDB(DBLayer.OutStore dbOst)
        {
            OutStore ost = null;
            if (dbOst != null)
            {
                ost = new OutStore();
                ost.Code = dbOst.Code;
                ost.Id = dbOst.Id;
                ost.InstoreId = dbOst.InstoreId;
                ost.Number = dbOst.Number;
                ost.UnitPrice = dbOst.UnitPrice;
                ost.TotalPrice = dbOst.TotalPrice;
                ost.Department = dbOst.Department;
                ost.Type = dbOst.Type;
                ost.CreatedBy = dbOst.CreatedBy;
                ost.CreatedDate = dbOst.CreatedDate;
                ost.UpdatedBy = dbOst.UpdatedBy;
                ost.UpdatedDate = dbOst.UpdatedDate;
            }
            return ost;
        }

        public List<OutStore> GetEntitiesFromDB(List<DBLayer.OutStore> dbOsts)
        {
            List<OutStore> osts = new List<OutStore>();
            if (dbOsts != null && dbOsts.Count > 0)
            {
                foreach (var dbInst in dbOsts)
                {
                    osts.Add(GetEntityFromDB(dbInst));
                }
            }
            return osts;
        }

        public DBLayer.OutStore GetDBModel(OutStore ost)
        {
            DBLayer.OutStore dbOst = null;
            if (ost != null)
            {
                dbOst = new DBLayer.OutStore();
                dbOst.Code = ost.Code;
                dbOst.Id = ost.Id;
                dbOst.InstoreId = ost.InstoreId;
                dbOst.Number = ost.Number;
                dbOst.UnitPrice = ost.UnitPrice;
                dbOst.TotalPrice = ost.TotalPrice;
                dbOst.Department = ost.Department;
                dbOst.Type = ost.Type;
                dbOst.CreatedBy = ost.CreatedBy;
                dbOst.CreatedDate = ost.CreatedDate;
                dbOst.UpdatedBy = ost.UpdatedBy;
                dbOst.UpdatedDate = ost.UpdatedDate;
            }
            return dbOst;
        }

        public List<DBLayer.OutStore> GetDBModels(List<OutStore> osts)
        {
            var dbOsts= new List<DBLayer.OutStore>();
            if (osts != null && osts.Count > 0)
            {
                foreach (var ost in osts)
                {
                    dbOsts.Add(GetDBModel(ost));
                }
            }
            return dbOsts;
        }
    }
}
