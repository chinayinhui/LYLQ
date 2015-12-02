using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using BizLayer = LYLQ.Business;

namespace LYLQ.WebUI.Models
{
    public class UserModel
    {
        public string Index { get; set; }
        [MaxLength(50)]
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Account { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Department { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        [MaxLength(50)]
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