using LYLQ.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DBLayer = LYLQ.SqLite;

namespace LYLQ.Business
{
    public class User
    {
        public string Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Demartment { get; set; }
        public long Enabled { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        private DBLayer.User _dbUser = new DBLayer.User();

        public List<User> GetAll()
        {
            var dbUsers = _dbUser.GetAll();

            return GetEntitiesFromDB(dbUsers);
        }

        public void AddAdminitrator() {
            var admin = GetByAccount("admin");
            if (admin == null)
            {
                var user = new User() { 
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now,
                    UpdatedBy = "System",
                    UpdatedDate = DateTime.Now,
                    Account = "admin",
                    Demartment = "13533",
                    Enabled = 1,
                    Name = "管理员",
                    Password = CryptographyHelper.SHA256("admin"),
                };

                this.Create(user);
            }
        }

        public User GetByAccount(string account)
        {
            var dbUser = _dbUser.GetByAccount(account);

            return GetEntityFromDB(dbUser);
        }

        public void Create(User user)
        {
            var dbUser = GetDBModel(user);
            _dbUser.Create(dbUser);
        }

        public void Update(User user)
        {
            var dbUser = GetDBModel(user);
            _dbUser.Update(dbUser);
        }

        public void Delete(string id)
        {
            _dbUser.Delete(id);
        }

        public User GetEntityFromDB(DBLayer.User dbUser)
        {
            User user = null;
            if (dbUser != null)
            {
                user = new User();
                user.Id = dbUser.Id;
                user.Name = dbUser.Name;
                user.Account = dbUser.Account;
                user.Password = dbUser.Password;
                user.Demartment = dbUser.Demartment;
                user.Enabled = dbUser.Enabled;
                user.CreatedBy = dbUser.CreatedBy;
                user.CreatedDate = dbUser.CreatedDate;
                user.UpdatedBy = dbUser.UpdatedBy;
                user.UpdatedDate = dbUser.UpdatedDate;
            }
            return user;
        }

        public List<User> GetEntitiesFromDB(List<DBLayer.User> dbUsers)
        {
            List<User> users = new List<User>();
            if (dbUsers != null && dbUsers.Count > 0)
            {
                foreach (var dbUser in dbUsers)
                {
                    users.Add(GetEntityFromDB(dbUser));
                }
            }
            return users;
        }

        public DBLayer.User GetDBModel(User user)
        {
            DBLayer.User dbUser = null;
            if (user != null)
            {
                dbUser = new DBLayer.User();
                dbUser.Id = user.Id;
                dbUser.Name = user.Name;
                dbUser.Account = user.Account;
                dbUser.Password = user.Password;
                dbUser.Demartment = user.Demartment;
                dbUser.Enabled = user.Enabled;
                dbUser.CreatedBy = user.CreatedBy;
                dbUser.CreatedDate = user.CreatedDate;
                dbUser.UpdatedBy = user.UpdatedBy;
                dbUser.UpdatedDate = user.UpdatedDate;
            }
            return dbUser;
        }

        public List<DBLayer.User> GetDBModels(List<User> users) {
            var dbUsers = new List<DBLayer.User>();
            if (users != null && users.Count > 0)
            {
                foreach (var user in users)
                {
                    dbUsers.Add(GetDBModel(user));
                }
            }
            return dbUsers;
        }
        
    }
}
