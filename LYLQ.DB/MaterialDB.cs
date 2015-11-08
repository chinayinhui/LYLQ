using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLQ.SqlServer
{
    public partial class Materiel
    {
        public List<Materiel> GetAll()
        {
            using (var ctx = new LYLQEntities())
            {
                var dbMats = from mat in ctx.Materiels
                             orderby mat.Type, mat.Code
                             select mat;

                return dbMats.ToList();
            }
        }

        public Materiel GetByCode(string code)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbMats = from mat in ctx.Materiels
                             where mat.Code == code
                             select mat;

                return dbMats.FirstOrDefault();
            }
        }

        public List<Materiel> GetByType(string type)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbMats = from mat in ctx.Materiels
                             where mat.Type == type
                             select mat;

                return dbMats.ToList();
            }
        }

        public void Create(Materiel mat)
        {
            using (var ctx = new LYLQEntities())
            {
                ctx.Materiels.Add(mat);

                ctx.SaveChanges();
            }
        }

        public void Update(Materiel mat)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbMats = from dbMat in ctx.Materiels
                             where dbMat.Code == mat.Code
                             select dbMat;

                var dbModelDpt = dbMats.First();
                dbModelDpt.Name = mat.Name;
                dbModelDpt.UpdatedBy = mat.UpdatedBy;
                dbModelDpt.UpdatedDate = DateTime.Now;

                ctx.SaveChanges();
            }
        }

        public void Delete(string code)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbUsers = from dbMaterial in ctx.Materiels
                              where dbMaterial.Code == code
                              select dbMaterial;

                ctx.Materiels.Remove(dbUsers.First());

                ctx.SaveChanges();
            }
        }
    }
}
