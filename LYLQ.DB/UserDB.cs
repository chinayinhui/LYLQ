using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LYLQ.SqlServer
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
                ctx.Users.Add(user);

                ctx.SaveChanges();
                
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
                
                ctx.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var ctx = new LYLQEntities())
            {
                var dbUsers = from dbUser in ctx.Users
                             where dbUser.Id == id
                             select dbUser;

                ctx.Users.Remove(dbUsers.First());

                ctx.SaveChanges();
            }
        }
    }
}
