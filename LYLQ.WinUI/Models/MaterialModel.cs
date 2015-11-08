using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLayer = LYLQ.Business;

namespace LYLQ.WinUI.Models
{
    public class MaterialModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Index { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Type { get; set; }

        public enum MatType { ZKPZ, NZKPZ,DJB,JJ,OTHER }

        BizLayer.Material _bizMateriel = new BizLayer.Material();

        BizLayer.StockService _outStoreService = new BizLayer.StockService();

        public List<MaterialModel> GetAll()
        {
            var bizMats = _bizMateriel.GetAll();
            var materialModels = new List<MaterialModel>();
            if (bizMats != null && bizMats.Count > 0)
            {
                materialModels = GetEntitiesFromBiz(bizMats);
                var i = 1;
                foreach (var materialMoel in materialModels)
                {
                    materialMoel.Index = i.ToString().PadLeft(2, '0');
                    i++;
                }
            }

            return materialModels;
        }

        public MaterialModel GetByCode(string code)
        {
            var dbMat = _bizMateriel.GetByCode(code);

            return GetEntityFromBiz(dbMat);
        }

        public List<MaterialModel> GetByType(string type)
        {
            var bizMats = _bizMateriel.GetByType(type);
            var materialModels = new List<MaterialModel>();
            if (bizMats != null && bizMats.Count > 0)
            {
                materialModels = GetEntitiesFromBiz(bizMats);
                var i = 1;
                foreach (var materialMoel in materialModels)
                {
                    materialMoel.Index = i.ToString().PadLeft(2, '0');
                    i++;
                }
            }

            return materialModels;
        }

        public void Create(MaterialModel mat)
        {
            var dbMat = GetBizModel(mat);
            _bizMateriel.Create(dbMat);
        }

        public void Update(MaterialModel mat)
        {
            var dbMat = GetBizModel(mat);
            _bizMateriel.Update(dbMat);
        }

        public void Delete(string code)
        {
            _bizMateriel.Delete(code);
        }

        public void ClearInstoreAndOutStoreDatas()
        {
            _outStoreService.ClearData();
        }

        public MaterialModel GetEntityFromBiz(BizLayer.Material bizMat)
        {
            MaterialModel mat = null;
            if (bizMat != null)
            {
                mat = new MaterialModel();
                mat.Code = bizMat.Code;
                mat.Name = bizMat.Name;
                mat.CreatedBy = bizMat.CreatedBy;
                mat.CreatedDate = bizMat.CreatedDate;
                mat.UpdatedBy = bizMat.UpdatedBy;
                mat.UpdatedDate = bizMat.UpdatedDate;
                mat.Type = bizMat.Type;
            }
            return mat;
        }

        public List<MaterialModel> GetEntitiesFromBiz(List<BizLayer.Material> bizMats)
        {
            List<MaterialModel> mats = new List<MaterialModel>();
            if (bizMats != null && bizMats.Count > 0)
            {
                foreach (var dbUser in bizMats)
                {
                    mats.Add(GetEntityFromBiz(dbUser));
                }
            }
            return mats;
        }

        public BizLayer.Material GetBizModel(MaterialModel mat)
        {
            BizLayer.Material bizMat = null;
            if (mat != null)
            {
                bizMat = new BizLayer.Material();
                bizMat.Code = mat.Code;
                bizMat.Name = mat.Name;
                bizMat.CreatedBy = mat.CreatedBy;
                bizMat.CreatedDate = mat.CreatedDate;
                bizMat.UpdatedBy = mat.UpdatedBy;
                bizMat.UpdatedDate = mat.UpdatedDate;
                bizMat.Type = mat.Type;
            }
            return bizMat;
        }

        public List<BizLayer.Material> GetBizModels(List<MaterialModel> mats)
        {
            var bizMats = new List<BizLayer.Material>();
            if (mats != null && mats.Count > 0)
            {
                foreach (var dpt in mats)
                {
                    bizMats.Add(GetBizModel(dpt));
                }
            }
            return bizMats;
        }
    }
}
