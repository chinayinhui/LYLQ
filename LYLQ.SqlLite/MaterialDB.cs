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
                string sql = @"INSERT INTO Materiel(Code,CreatedBy,CreatedDate,Name,Type,UpdatedBy,UpdatedDate)VALUES(
                                                    @Code,@CreatedBy,@CreatedDate,@Name,@Type,@UpdatedBy,@UpdatedDate)";

                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Code", mat.Code));
                sqlParams.Add(new SQLiteParameter("@CreatedBy", mat.CreatedBy));
                sqlParams.Add(new SQLiteParameter("@CreatedDate", mat.CreatedDate));
                sqlParams.Add(new SQLiteParameter("@Name", mat.Name));
                sqlParams.Add(new SQLiteParameter("@Type", mat.Type));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", mat.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", mat.UpdatedDate));
                

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Update(Materiel mat)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbMats = from dbMat in ctx.Materiels
                //             where dbMat.Code == mat.Code
                //             select dbMat;

                //var dbModelDpt = dbMats.First();
                //dbModelDpt.Name = mat.Name;
                //dbModelDpt.UpdatedBy = mat.UpdatedBy;
                //dbModelDpt.UpdatedDate = DateTime.Now;

               //ctx.SaveChanges();

                string sql = @"UPDATE Materiel SET Name = @Name,                                                                         
                                                UpdatedBy = @UpdatedBy, 
                                                UpdatedDate = @UpdatedDate 
                                            WHERE Code = '" + mat.Code + "'";

                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Name", mat.Name));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", mat.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", mat.UpdatedDate));

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());

              
            }
        }

        public void Delete(string code)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbUsers = from dbMaterial in ctx.Materiels
                //              where dbMaterial.Code == code
                //              select dbMaterial;

                //ctx.Materiels.Remove(dbUsers.First());

                //ctx.SaveChanges();

                string sql = @"DELETE FROM Materiel WHERE Code = @Code";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Code", code));
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }
    }
}
