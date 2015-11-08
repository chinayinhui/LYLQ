using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizLayer = LYLQ.Business;

namespace LYLQ.WinUI.Models
{
    public class UserModel
    {
        public string Index { get; set; }
        public string Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        private BizLayer.User _bizUser = new BizLayer.User();

        public List<UserModel> GetAll()
        {
            var bizUsers = _bizUser.GetAll();
            var userModels = new List<UserModel>();
            if (bizUsers != null && bizUsers.Count > 0)
            {
                userModels = GetEntitiesFromBiz(bizUsers);
                var i = 1;
                foreach (var userModel in userModels)
                {
                    userModel.Index = i.ToString().PadLeft(2, '0');
                    i++;
                }
            }

            return userModels;
        }

        //public DataSet GetAllUserDs()
        //{
        //    var ds = new DataSet();

        //    DataTable dt = new DataTable("users");            
        //    dt.Columns.Add(new DataColumn("姓 名"));
        //    dt.Columns.Add(new DataColumn("账 号"));
        //    dt.Columns.Add(new DataColumn("状 态"));
        //    dt.Columns.Add(new DataColumn("网 点"));
        //    dt.Columns.Add(new DataColumn("日 期"));
        //    dt.Columns.Add(new DataColumn("Id"));

        //    var userModels = GetAll();
        //    if (userModels != null && userModels.Count > 0)
        //    {
        //        foreach (var userModel in userModels)
        //        {
        //            DataRow dr = dt.NewRow();
        //            dr[0] = userModel.Name;
        //            dr[1] = userModel.Account;
        //            dr[2] = userModel.Status ? "激活" : "禁用";
        //            dr[3] = userModel.Department;
        //            dr[4] = userModel.CreatedDate.HasValue ? userModel.CreatedDate.Value.ToShortDateString() : DateTime.Now.ToShortDateString();                 
        //            dr[5] = userModel.Id;
        //            dt.Rows.Add(dr);
        //        }

        //    }

        //    ds.Tables.Add(dt);
        //    return ds;
        //}

        public void AddAdminitrator()
        {
            _bizUser.AddAdminitrator();
        }

        public UserModel GetByAccount(string account)
        {
            var bizUser = _bizUser.GetByAccount(account);

            return GetEntityFromBiz(bizUser);
        }

        public void Create(UserModel userModel)
        {
            var bizUser = GetBizModel(userModel);
            _bizUser.Create(bizUser);
        }

        public void Update(UserModel userModel)
        {
            var bizUser = GetBizModel(userModel);
            _bizUser.Update(bizUser);
        }

        public void Delete(string id)
        {
            _bizUser.Delete(id);
        }

        public UserModel GetEntityFromBiz(BizLayer.User bizUser)
        {
            UserModel user = null;
            if (bizUser != null)
            {
                user = new UserModel();
                user.Id = bizUser.Id;
                user.Name = bizUser.Name;
                user.Account = bizUser.Account;
                user.Password = bizUser.Password;
                user.Department = bizUser.Demartment;
                user.Status = bizUser.Enabled == 1;
                user.CreatedBy = bizUser.CreatedBy;
                user.CreatedDate = bizUser.CreatedDate;
                user.UpdatedBy = bizUser.UpdatedBy;
                user.UpdatedDate = bizUser.UpdatedDate;
            }
            return user;
        }

        public List<UserModel> GetEntitiesFromBiz(List<BizLayer.User> bizUsers)
        {
            List<UserModel> users = new List<UserModel>();
            if (bizUsers != null && bizUsers.Count > 0)
            {
                foreach (var dbUser in bizUsers)
                {
                    users.Add(GetEntityFromBiz(dbUser));
                }
            }
            return users;
        }

        public BizLayer.User GetBizModel(UserModel userModel)
        {
            BizLayer.User bizUser = null;
            if (userModel != null)
            {
                bizUser = new BizLayer.User();
                bizUser.Id = userModel.Id;
                bizUser.Name = userModel.Name;
                bizUser.Account = userModel.Account;
                bizUser.Password = userModel.Password;
                bizUser.Demartment = userModel.Department;
                bizUser.Enabled = userModel.Status ? 1 : 0;
                bizUser.CreatedBy = userModel.CreatedBy;
                bizUser.CreatedDate = userModel.CreatedDate;
                bizUser.UpdatedBy = userModel.UpdatedBy;
                bizUser.UpdatedDate = userModel.UpdatedDate;
            }
            return bizUser;
        }

        public List<BizLayer.User> GetBizModels(List<UserModel> userModels)
        {
            var bizUsers = new List<BizLayer.User>();
            if (userModels != null && userModels.Count > 0)
            {
                foreach (var user in userModels)
                {
                    bizUsers.Add(GetBizModel(user));
                }
            }
            return bizUsers;
        }
    }
}
