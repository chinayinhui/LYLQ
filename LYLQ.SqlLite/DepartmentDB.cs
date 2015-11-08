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
    public partial class Department
    {
        public List<Department> GetAll()
        {
            using (var ctx = new LYLQEntities())
            {
                var dbDpts = from dpt in ctx.Departments 
                             orderby dpt.Type descending, dpt.Code
                             select dpt;

                return dbDpts.ToList();
            }
        }

        public List<Department> GetAllIn()
        {
            using (var ctx = new LYLQEntities())
            {
                var dbDpts = from dpt in ctx.Departments
                             where dpt.Type == 0
                             orderby dpt.Code
                             select dpt;

                return dbDpts.ToList();
            }
        }

        public List<Department> GetAllOut()
        {
            using (var ctx = new LYLQEntities())
            {
                var dbDpts = from dpt in ctx.Departments
                             where dpt.Type == 1
                             orderby dpt.Code
                             select dpt;

                return dbDpts.ToList();
            }
        }

        public Department GetByCode(string code)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbDpts = from dpt in ctx.Departments
                              where dpt.Code == code
                              select dpt;

                return dbDpts.FirstOrDefault();
            }

        }

        public void Create(Department dpt)
        {
            using (var ctx = new LYLQEntities())
            {
                //ctx.Departments.Add(dpt);

                //ctx.SaveChanges();

                string sql = @"INSERT INTO Department(Code,CreatedBy,CreatedDate,Name,Type,UpdatedBy,UpdatedDate)VALUES(
                                                    @Code,@CreatedBy,@CreatedDate,@Name,@Type,@UpdatedBy,@UpdatedDate)";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Code", dpt.Code));
                sqlParams.Add(new SQLiteParameter("@CreatedBy", dpt.CreatedBy));
                sqlParams.Add(new SQLiteParameter("@CreatedDate", dpt.CreatedDate));
                sqlParams.Add(new SQLiteParameter("@Name", dpt.Name));
                sqlParams.Add(new SQLiteParameter("@Type", dpt.Type));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", dpt.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", dpt.UpdatedDate));

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Update(Department dpt)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbDpts = from dbDpt in ctx.Departments
                //             where dbDpt.Code == dpt.Code
                //             select dbDpt;

                //var dbModelDpt = dbDpts.First();
                //dbModelDpt.Name = dpt.Name;
                //dbModelDpt.UpdatedBy = dpt.UpdatedBy;
                //dbModelDpt.UpdatedDate = DateTime.Now;

                //ctx.SaveChanges();

                string sql = @"UPDATE Department SET Name = @Name,      
                                                UpdatedBy = @UpdatedBy,    
                                                UpdatedDate = @UpdatedDate                                               
                                                WHERE Code = '" + dpt.Code + "'";

                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Name", dpt.Name));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", dpt.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", dpt.UpdatedDate));

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Delete(string code)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbDpts = from dbDpt in ctx.Departments
                //             where dbDpt.Code == code
                //             select dbDpt;

                //ctx.Departments.Remove(dbDpts.First());
                
                //ctx.SaveChanges();

                string sql = @"DELETE FROM Department WHERE Code = @Code";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Code", code));
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }
    }
}
