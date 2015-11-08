using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Data.SQLite.Linq;

namespace LYLQ.SqLite
{
    public partial class User
    {   
        public List<User> GetAll()
        {
            using (var ctx = new LYLQEntities())
            {
                var dbUsers = from user in ctx.Users                             
                              select user;

                return dbUsers.ToList();
            }
        }
         
        public User GetByAccount(string account) {
            using (var ctx = new LYLQEntities()) 
            {
                var dbUsers = from user in ctx.Users
                             where user.Account == account
                             select user;

                 return dbUsers.FirstOrDefault();
            }             
        }

        public void Create(User user)
        {
            using (var ctx = new LYLQEntities())
            {               
                user.Id = Guid.NewGuid().ToString();
                //ctx.Users.Add(user);
                
                //ctx.SaveChanges();

                //INSERT INTO User(Account,CreatedBy,CreatedDate,Demartment,Enabled,Id,Name,Password,UpdatedBy,UpdatedDate)VALUES('admin','System','2015/10/23 23:30:58','13533',1,'e56efc45-5f76-43af-90b1-faea2c876bc7','管理员','8C-69-76-E5-B5-41-04-15-BD-E9-08-BD-4D-EE-15-DF-B1-67-A9-C8-73-FC-4B-B8-A8-1F-6F-2A-B4-48-A9-18','System','2015/10/23 23:30:58')
                string sql = "INSERT INTO User(Account,CreatedBy,CreatedDate,Demartment,Enabled,Id,Name,Password,UpdatedBy,UpdatedDate)VALUES(@Account,@CreatedBy,@CreatedDate,@Demartment,@Enabled,@Id,@Name,@Password,@UpdatedBy,@UpdatedDate)";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Account", user.Account));
                sqlParams.Add(new SQLiteParameter("@CreatedBy", user.CreatedBy));
                sqlParams.Add(new SQLiteParameter("@CreatedDate", user.CreatedDate));
                sqlParams.Add(new SQLiteParameter("@Demartment", user.Demartment));
                sqlParams.Add(new SQLiteParameter("@Enabled", user.Enabled));
                sqlParams.Add(new SQLiteParameter("@Id", user.Id));
                sqlParams.Add(new SQLiteParameter("@Name", user.Name));
                sqlParams.Add(new SQLiteParameter("@Password", user.Password));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", user.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", user.UpdatedDate));
                
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
            }
        }

        public void Update(User user)
        {
            using (var ctx = new LYLQEntities()){               
                            var dbUsers = from dbUser in ctx.Users
                            where dbUser.Id == user.Id
                            select dbUser;

                var dbModelUser = dbUsers.First();
                dbModelUser.Password = user.Password;
                dbModelUser.Demartment = user.Demartment;
                dbModelUser.Enabled = user.Enabled;
                dbModelUser.UpdatedBy = user.UpdatedBy;
                dbModelUser.UpdatedDate = DateTime.Now;                    
                
                //ctx.SaveChanges();
                string sql = @"UPDATE User SET Password = @Password, 
                                                Demartment = @Demartment, 
                                                Enabled= @Enabled, 
                                                UpdatedBy = @UpdatedBy, 
                                                UpdatedDate = @UpdatedDate 
                                            WHERE Id = '" + dbModelUser .Id+ "'";

                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Password", dbModelUser.Password));
                sqlParams.Add(new SQLiteParameter("@Demartment", dbModelUser.Demartment));
                sqlParams.Add(new SQLiteParameter("@Enabled", dbModelUser.Enabled));
                sqlParams.Add(new SQLiteParameter("@UpdatedBy", dbModelUser.UpdatedBy));
                sqlParams.Add(new SQLiteParameter("@UpdatedDate", dbModelUser.UpdatedDate));

                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());
                
            }
        }

        public void Delete(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                //var dbUsers = from dbUser in ctx.Users
                //             where dbUser.Id == id
                //             select dbUser;

                //ctx.Users.Remove(dbUsers.First());

                string sql = @"DELETE FROM User WHERE Id = @Id";
                List<SQLiteParameter> sqlParams = new List<SQLiteParameter>();
                sqlParams.Add(new SQLiteParameter("@Id", id));
                ctx.Database.ExecuteSqlCommand(sql, sqlParams.ToArray());

                //ctx.SaveChanges();
            }
        }
    }
}
