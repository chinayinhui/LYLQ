using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer = LYLQ.SqLite;

namespace LYLQ.Business
{
    public class InStore
    {
        public string Id { get; set; }
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
        public int RemainNumber { get; set; }
        public decimal RemainTotalPrice { get; set; }        

        DBLayer.InStore _dbInStore = new DBLayer.InStore();

        public List<InStore> GetAll()
        {
            var dbInstores = _dbInStore.GetAll();

            return GetEntitiesFromDB(dbInstores);
        }

        public List<InStore> GetRemainAll()
        {
            var dbInstores = _dbInStore.GetRemainAll();

            return GetEntitiesFromDB(dbInstores);
        }

        public InStore GetById(string id)
        {
            var dbDpt = _dbInStore.GetById(id);

            return GetEntityFromDB(dbDpt);
        }

        public List<InStore> GetByType(string type)
        {
            var dbInstores = _dbInStore.GetByType(type);

            return GetEntitiesFromDB(dbInstores);
        }

        public List<InStore> GetKCByType(string type, string code)
        {
            var dbInstores = _dbInStore.GetKCByType(type, code);

            return GetEntitiesFromDB(dbInstores);
        }

        public void Create(InStore inStore)
        {
            var dbDpt = GetDBModel(inStore);
            _dbInStore.Create(dbDpt);
        }

        public void Update(InStore instore)
        {
            var dbInStore = GetDBModel(instore);
            _dbInStore.Update(dbInStore);
        }

        public void Delete(string id)
        {
            _dbInStore.Delete(id);
        }

        public void Delete()
        {
            _dbInStore.Delete();
        }

        public List<InStore> GetByCodeUnitPrice(string code, decimal unitPrice)
        {
            var dbInstores = _dbInStore.GetByCodeUnitPrice(code, unitPrice);
            return GetEntitiesFromDB(dbInstores);
        }

        public List<InStore> Query(DateTime beginDate, DateTime endDate, string type, string code, string operatorStoreIn) {
            var dbInstores = _dbInStore.Query(beginDate, endDate, type, code, operatorStoreIn);
            return GetEntitiesFromDB(dbInstores);
        }

        public List<InStore> MergeSameUnitPriceForSameCode(List<InStore> inStores)
        {
            var sortInStores = (from instore in inStores
                                     orderby instore.Code, instore.UnitPrice
                                     select instore).ToList();

            var prevInstore = sortInStores.First();
            for (var i = 0; i < sortInStores.Count; i++)
            {
                var instoreMode = sortInStores[i];
                if (prevInstore.Id != instoreMode.Id &&
                    prevInstore.Code == instoreMode.Code &&
                    prevInstore.UnitPrice == instoreMode.UnitPrice)
                {
                    //if (string.IsNullOrEmpty(prevInstoreModel.UnitIds))
                    //{
                    //    prevInstoreModel.UnitIds = prevInstoreModel.Id;
                    //}
                    //prevInstoreModel.UnitIds = prevInstoreModel.UnitIds + "," + instoreMode.Id;
                    prevInstore.RemainNumber += instoreMode.RemainNumber;
                    prevInstore.RemainTotalPrice += instoreMode.RemainTotalPrice;
                    sortInStores.Remove(instoreMode);
                    i--;
                }
                else
                {
                    prevInstore = instoreMode;
                }
            }

            return sortInStores;
        }

        //public void OutStore(int outNumber, List<string> inStoreIds, string updatedBy, DateTime UpdatedDate)
        //{
        //    foreach (var id in inStoreIds)
        //    {
        //        if (outNumber > 0)
        //        {
        //            var store = _dbInStore.GetById(id);
        //            if (store.RemainNumber > outNumber)
        //            {
        //                store.RemainNumber = store.RemainNumber - outNumber;
        //                store.RemainTotalPrice = store.RemainTotalPrice - store.UnitPrice * outNumber;
        //                store.UpdatedBy = updatedBy;
        //                store.UpdatedDate = UpdatedDate;
        //                _dbInStore.OutStore(store);

        //                outNumber = 0;
        //            }
        //            else
        //            {
        //                outNumber = outNumber - store.RemainNumber.Value;

        //                store.RemainNumber = 0;
        //                store.RemainTotalPrice = 0;
        //                store.UpdatedBy = updatedBy;
        //                store.UpdatedDate = UpdatedDate;
        //                _dbInStore.OutStore(store);
        //            }
        //        }
        //    }          
            
        //}

        public InStore GetEntityFromDB(DBLayer.InStore dbInst)
        {
            InStore inst = null;
            if (dbInst != null)
            {
                inst = new InStore();
                inst.Code = dbInst.Code;
                inst.Id = dbInst.Id;
                inst.Number = dbInst.Number;
                inst.RemainNumber = dbInst.RemainNumber.Value;
                inst.UnitPrice = dbInst.UnitPrice;
                inst.RemainTotalPrice = dbInst.RemainTotalPrice.HasValue ? dbInst.RemainTotalPrice.Value : 0;                
                inst.TotalPrice = dbInst.TotalPrice;
                inst.Department = dbInst.Department;
                inst.Type = dbInst.Type;
                inst.CreatedBy = dbInst.CreatedBy;
                inst.CreatedDate = dbInst.CreatedDate;
                inst.UpdatedBy = dbInst.UpdatedBy;
                inst.UpdatedDate = dbInst.UpdatedDate;
            }
            return inst;
        }

        public List<InStore> GetEntitiesFromDB(List<DBLayer.InStore> dbInsts)
        {
            List<InStore> insts = new List<InStore>();
            if (dbInsts != null && dbInsts.Count > 0)
            {
                foreach (var dbInst in dbInsts)
                {
                    insts.Add(GetEntityFromDB(dbInst));
                }
            }
            return insts;
        }

        public DBLayer.InStore GetDBModel(InStore dpt)
        {
            DBLayer.InStore dbInst = null;
            if (dpt != null)
            {
                dbInst = new DBLayer.InStore();
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

        public List<DBLayer.InStore> GetDBModels(List<InStore> insts)
        {
            var dbInsts = new List<DBLayer.InStore>();
            if (insts != null && insts.Count > 0)
            {
                foreach (var dpt in insts)
                {
                    dbInsts.Add(GetDBModel(dpt));
                }
            }
            return dbInsts;
        }

    }
}
