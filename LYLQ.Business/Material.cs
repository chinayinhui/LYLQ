using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer = LYLQ.SqLite;

namespace LYLQ.Business
{
    public class Material
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        DBLayer.Materiel _dbMateriel = new DBLayer.Materiel();

        public List<Material> GetAll()
        {
            var dbMats = _dbMateriel.GetAll();

            return GetEntitiesFromDB(dbMats);
        }

        public Dictionary<string, string> GetKeyValuePairs()
        {
            var mats = GetAll();
            Dictionary<string, string> matKeyValuePairs = new Dictionary<string, string>();
            if (mats != null && mats.Count > 0)
            {
                foreach (var mat in mats)
                {
                    matKeyValuePairs.Add(mat.Code, mat.Name);
                }
            }
            return matKeyValuePairs;
        }

        public List<Material> GetByType(string type)
        {
            var dbMats = _dbMateriel.GetByType(type);

            return GetEntitiesFromDB(dbMats);
        }

        public Material GetByCode(string code)
        {
            var dbDpt = _dbMateriel.GetByCode(code);

            return GetEntityFromDB(dbDpt);
        }

        public void Create(Material dpt)
        {
            var dbDpt = GetDBModel(dpt);
            _dbMateriel.Create(dbDpt);
        }

        public void Update(Material dpt)
        {
            var dbDpt = GetDBModel(dpt);
            _dbMateriel.Update(dbDpt);
        }

        public void Delete(string code)
        {
            _dbMateriel.Delete(code);
        }

        public Material GetEntityFromDB(DBLayer.Materiel dbMat)
        {
            Material mat = null;
            if (dbMat != null)
            {
                mat = new Material();
                mat.Code = dbMat.Code;
                mat.Name = dbMat.Name;
                mat.CreatedBy = dbMat.CreatedBy;
                mat.CreatedDate = dbMat.CreatedDate;
                mat.UpdatedBy = dbMat.UpdatedBy;
                mat.UpdatedDate = dbMat.UpdatedDate;
                mat.Type = dbMat.Type;
            }
            return mat;
        }

        public List<Material> GetEntitiesFromDB(List<DBLayer.Materiel> dbMats)
        {
            List<Material> mats = new List<Material>();
            if (dbMats != null && dbMats.Count > 0)
            {
                foreach (var dbMat in dbMats)
                {
                    mats.Add(GetEntityFromDB(dbMat));
                }
            }
            return mats;
        }

        public DBLayer.Materiel GetDBModel(Material dpt)
        {
            DBLayer.Materiel dbMat = null;
            if (dpt != null)
            {
                dbMat = new DBLayer.Materiel();
                dbMat.Code = dpt.Code;
                dbMat.Name = dpt.Name;
                dbMat.CreatedBy = dpt.CreatedBy;
                dbMat.CreatedDate = dpt.CreatedDate;
                dbMat.UpdatedBy = dpt.UpdatedBy;
                dbMat.UpdatedDate = dpt.UpdatedDate;
                dbMat.Type = dpt.Type;
            }
            return dbMat;
        }

        public List<DBLayer.Materiel> GetDBModels(List<Material> mats)
        {
            var dbMats = new List<DBLayer.Materiel>();
            if (mats != null && mats.Count > 0)
            {
                foreach (var dpt in mats)
                {
                    dbMats.Add(GetDBModel(dpt));
                }
            }
            return dbMats;
        }        
    }
}
