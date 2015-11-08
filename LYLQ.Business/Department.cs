using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer = LYLQ.SqLite;

namespace LYLQ.Business
{
    public class Department
    {
        public string Code { get; set; }
        public string Name { get; set; }        
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int Type { get; set; }

        DBLayer.Department _dbDepartment = new DBLayer.Department();

        public List<Department> GetAll()
        {
            var dbDpts = _dbDepartment.GetAll();

            return GetEntitiesFromDB(dbDpts);
        }

        public List<Department> GetAllIn()
        {
            var dbDpts = _dbDepartment.GetAllIn();

            return GetEntitiesFromDB(dbDpts);
        }

        public List<Department> GetAllOut()
        {
            var dbDpts = _dbDepartment.GetAllOut();

            return GetEntitiesFromDB(dbDpts);
        }

        public Department GetByCode(string code)
        {
            var dbDpt = _dbDepartment.GetByCode(code);

            return GetEntityFromDB(dbDpt);
        }

        public void Create(Department dpt)
        {
            var dbDpt = GetDBModel(dpt);
            _dbDepartment.Create(dbDpt);
        }

        public void Update(Department dpt)
        {
            var dbDpt = GetDBModel(dpt);
            _dbDepartment.Update(dbDpt);
        }

        public void Delete(string code)
        {
            _dbDepartment.Delete(code);
        }

        public Department GetEntityFromDB(DBLayer.Department dbDpt)
        {
            Department dpt = null;
            if (dbDpt != null)
            {
                dpt = new Department();
                dpt.Code = dbDpt.Code;
                dpt.Name = dbDpt.Name;                
                dpt.CreatedBy = dbDpt.CreatedBy;
                dpt.CreatedDate = dbDpt.CreatedDate;
                dpt.UpdatedBy = dbDpt.UpdatedBy;
                dpt.UpdatedDate = dbDpt.UpdatedDate;
                dpt.Type = Convert.ToInt32(dbDpt.Type);
            }
            return dpt;
        }

        public List<Department> GetEntitiesFromDB(List<DBLayer.Department> dbDpts)
        {
            List<Department> dpts = new List<Department>();
            if (dbDpts != null && dbDpts.Count > 0)
            {
                foreach (var dbUser in dbDpts)
                {
                    dpts.Add(GetEntityFromDB(dbUser));
                }
            }
            return dpts;
        }

        public DBLayer.Department GetDBModel(Department dpt)
        {
            DBLayer.Department dbDpt = null;
            if (dpt != null)
            {
                dbDpt = new DBLayer.Department();
                dbDpt.Code = dpt.Code;
                dbDpt.Name = dpt.Name;                
                dbDpt.CreatedBy = dpt.CreatedBy;
                dbDpt.CreatedDate = dpt.CreatedDate;
                dbDpt.UpdatedBy = dpt.UpdatedBy;
                dbDpt.UpdatedDate = dpt.UpdatedDate;
                dbDpt.Type = dpt.Type;
            }
            return dbDpt;
        }

        public List<DBLayer.Department> GetDBModels(List<Department> dpts)
        {
            var dbDpts = new List<DBLayer.Department>();
            if (dpts != null && dpts.Count > 0)
            {
                foreach (var dpt in dpts)
                {
                    dbDpts.Add(GetDBModel(dpt));
                }
            }
            return dbDpts;
        }

    }
}
