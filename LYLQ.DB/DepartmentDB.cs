using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLQ.SqlServer
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
                ctx.Departments.Add(dpt);

                ctx.SaveChanges();
            }
        }

        public void Update(Department dpt)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbDpts = from dbDpt in ctx.Departments
                             where dbDpt.Code == dpt.Code
                             select dbDpt;

                var dbModelDpt = dbDpts.First();
                dbModelDpt.Name = dpt.Name;
                dbModelDpt.UpdatedBy = dpt.UpdatedBy;
                dbModelDpt.UpdatedDate = DateTime.Now;

                ctx.SaveChanges();
            }
        }

        public void Delete(string code)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbDpts = from dbDpt in ctx.Departments
                             where dbDpt.Code == code
                             select dbDpt;

                ctx.Departments.Remove(dbDpts.First());
                
                ctx.SaveChanges();
            }
        }
    }
}
