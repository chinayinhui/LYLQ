using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLayer = LYLQ.Business;

namespace LYLQ.WinUI.Models
{
    public class DepartmentModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Index { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int Type { get; set; }

        public enum DeptType { IN, OUT}

        BizLayer.Department _bizDepartment = new BizLayer.Department();

        public List<DepartmentModel> GetAll()
        {
            var bizDpts = _bizDepartment.GetAll();
            var deptModels = new List<DepartmentModel>();
            if (bizDpts != null && bizDpts.Count > 0)
            {
                deptModels = GetEntitiesFromBiz(bizDpts);
                var i = 1;
                foreach (var deptModel in deptModels)
                {
                    deptModel.Index = i.ToString().PadLeft(2,'0');
                    i++;
                }
            }

            return deptModels;
        }

        public DepartmentModel GetByCode(string code)
        {
            var dbDpt = _bizDepartment.GetByCode(code);

            return GetEntityFromBiz(dbDpt);
        }

        public void Create(DepartmentModel dpt)
        {
            var dbDpt = GetBizModel(dpt);
            _bizDepartment.Create(dbDpt);
        }

        public void Update(DepartmentModel dpt)
        {
            var dbDpt = GetBizModel(dpt);
            _bizDepartment.Update(dbDpt);
        }

        public void Delete(string code)
        {
            _bizDepartment.Delete(code);
        }

        public DepartmentModel GetEntityFromBiz(BizLayer.Department bizDpt)
        {
            DepartmentModel dpt = null;
            if (bizDpt != null)
            {
                dpt = new DepartmentModel();
                dpt.Code = bizDpt.Code;
                dpt.Name = bizDpt.Name;           
                dpt.CreatedBy = bizDpt.CreatedBy;
                dpt.CreatedDate = bizDpt.CreatedDate;
                dpt.UpdatedBy = bizDpt.UpdatedBy;
                dpt.UpdatedDate = bizDpt.UpdatedDate;
                dpt.Type = bizDpt.Type;
            }
            return dpt;
        }

        public List<DepartmentModel> GetEntitiesFromBiz(List<BizLayer.Department> bizDpts)
        {
            List<DepartmentModel> dpts = new List<DepartmentModel>();
            if (bizDpts != null && bizDpts.Count > 0)
            {
                foreach (var dbUser in bizDpts)
                {
                    dpts.Add(GetEntityFromBiz(dbUser));
                }
            }
            return dpts;
        }

        public BizLayer.Department GetBizModel(DepartmentModel dpt)
        {
            BizLayer.Department bizDpt = null;
            if (dpt != null)
            {
                bizDpt = new BizLayer.Department();
                bizDpt.Code = dpt.Code;
                bizDpt.Name = dpt.Name;                
                bizDpt.CreatedBy = dpt.CreatedBy;
                bizDpt.CreatedDate = dpt.CreatedDate;
                bizDpt.UpdatedBy = dpt.UpdatedBy;
                bizDpt.UpdatedDate = dpt.UpdatedDate;
                bizDpt.Type = dpt.Type;
            }
            return bizDpt;
        }

        public List<BizLayer.Department> GetBizModels(List<DepartmentModel> dpts)
        {
            var bizDpts = new List<BizLayer.Department>();
            if (dpts != null && dpts.Count > 0)
            {
                foreach (var dpt in dpts)
                {
                    bizDpts.Add(GetBizModel(dpt));
                }
            }
            return bizDpts;
        }
    }
}
