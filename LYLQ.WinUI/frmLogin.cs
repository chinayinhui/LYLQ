using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LYLQ.WinUI.Models;
using LYLQ.Helper;

namespace LYLQ.WinUI
{   

    public partial class frmLogin : Form
    {       

        private UserModel _userModel = new UserModel();
        private StockModel _stockModel = new StockModel();

        public frmLogin()
        {
            InitializeComponent();

            this.CenterToScreen();
            this.AcceptButton = this.btnLogin;
            new Task(() => { _userModel.AddAdminitrator(); }).Start();
            _stockModel.SyncInstockToStockForCurrentDay();
            this.lblLoginError.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var account = this.txtAccount.Text;
            var pwd = this.txtPassword.Text;
            var user = _userModel.GetByAccount(account);
            if (!user.Status)
            {
                this.lblLoginError.Visible = true;
                this.lblLoginError.Text = "该账户已被禁用！";
                return;
            }
            var dbPwd = user.Password;
            var loginPwd = CryptographyHelper.SHA256(pwd);
            var isLoginOk = string.Equals(loginPwd, dbPwd, StringComparison.InvariantCultureIgnoreCase);
            if (!isLoginOk)
            {
                this.lblLoginError.Visible = true;
                this.lblLoginError.Text = "用户名或密码不正确！";
            }
            else
            {
                var frmMain = new frmMain();
                frmMain.Show();
                this.Hide();
                UIContext.LoginUser = user;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
