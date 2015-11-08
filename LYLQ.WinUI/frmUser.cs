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
    public partial class frmUser : Form
    {
        UserModel _userModel = new UserModel();
        List<UserModel> users = new List<UserModel>();

        DepartmentModel _departmentModel = new DepartmentModel();
        List<DepartmentModel> depts = new List<DepartmentModel>();

        public frmUser()
        {
            InitializeComponent();           
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn txtIndexCol = new DataGridViewTextBoxColumn();
            txtIndexCol.DataPropertyName = "Index";
            txtIndexCol.HeaderText = "序 号";
            txtIndexCol.Width = 60;
            txtIndexCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grdUser.Columns.Add(txtIndexCol);

            DataGridViewTextBoxColumn txtNameCol = new DataGridViewTextBoxColumn();
            txtNameCol.DataPropertyName = "Name";
            txtNameCol.HeaderText = "姓 名";
            txtNameCol.Width = 186;
            this.grdUser.Columns.Add(txtNameCol);
            

            DataGridViewTextBoxColumn txtAccountCol = new DataGridViewTextBoxColumn();
            txtAccountCol.DataPropertyName = "Account";
            txtAccountCol.HeaderText = "账 号";
            txtAccountCol.Width = 120;
            this.grdUser.Columns.Add(txtAccountCol);

            DataGridViewTextBoxColumn txtStatusCol = new DataGridViewTextBoxColumn();
            txtStatusCol.DataPropertyName = "Status";
            txtStatusCol.HeaderText = "状 态";
            this.grdUser.Columns.Add(txtStatusCol);

            DataGridViewTextBoxColumn txtDepartmentCol = new DataGridViewTextBoxColumn();
            txtDepartmentCol.DataPropertyName = "Department";
            txtDepartmentCol.HeaderText = "网 点";
            this.grdUser.Columns.Add(txtDepartmentCol);

            DataGridViewTextBoxColumn txtCreatedDateCol = new DataGridViewTextBoxColumn();
            txtCreatedDateCol.DataPropertyName = "UpdatedDate";
            txtCreatedDateCol.HeaderText = "日 期";
            txtCreatedDateCol.Width = 106;
            this.grdUser.Columns.Add(txtCreatedDateCol);

            DataGridViewTextBoxColumn txtIdCol = new DataGridViewTextBoxColumn();
            txtIdCol.DataPropertyName = "Id";
            txtIdCol.HeaderText = "Id";
            this.grdUser.Columns.Add(txtIdCol);

            DataGridViewButtonColumn btnEditCol = new DataGridViewButtonColumn();
            btnEditCol.Name = "Edit";
            btnEditCol.UseColumnTextForButtonValue = true;
            btnEditCol.Text = "编 辑";
            btnEditCol.HeaderText = "编 辑";
            btnEditCol.Width = 60;
            btnEditCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grdUser.Columns.Add(btnEditCol);

            DataGridViewButtonColumn btnDelCol = new DataGridViewButtonColumn();
            btnDelCol.Name = "Del";
            btnDelCol.UseColumnTextForButtonValue = true;
            btnDelCol.Text = "删 除";
            btnDelCol.HeaderText = "删 除";
            btnDelCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnDelCol.Width = 60;
            this.grdUser.Columns.Add(btnDelCol);

            this.SetGridStyle();

            this.grdUser.AutoGenerateColumns = false;
            this.grdUser.DataSource = _userModel.GetAll();
            this.grdUser.Columns[6].Visible = false;

            //Department combox
            BindDeptCombox();
            
        }

        private void BindDeptCombox()
        {
            if (depts == null || depts.Count == 0)
            {
                depts = _departmentModel.GetAll();
                depts = depts.Where(dpt => dpt.Type == (int)DepartmentModel.DeptType.IN).ToList();
            }
            var tmpDepts = new List<DepartmentModel>(); ;
            tmpDepts.AddRange(depts);
            //tmpDepts.Add(new DepartmentModel() { Index = "999", Code = "-1", Name = " " });
            tmpDepts = tmpDepts.OrderByDescending(dpt => dpt.Index).ToList();

            this.cboDept.DataSource = tmpDepts;
            this.cboDept.ValueMember = "Code";
            this.cboDept.DisplayMember = "Name";           
        }

        private void SetGridStyle()
        {
            this.grdUser.ColumnHeadersHeight = 32;
            this.grdUser.RowTemplate.Height = 30;
            this.grdUser.Height = 580;
            this.grdUser.AutoSize = true;
            this.grdUser.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.grdUser.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.grdUser.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.grdUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.grdUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdUser.ScrollBars = ScrollBars.Vertical;            
        }

        private void grdUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grdUser = sender as DataGridView;
            if (e.RowIndex > -1 & e.ColumnIndex > 0 && grdUser.Columns[e.ColumnIndex].Name == "Edit")
            {
                var account = grdUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                var user = _userModel.GetByAccount(account);

                this.txtName.Text = user.Name;
                this.txtAccount.Text = user.Account;
                this.chkStatus.Checked = user.Status;

                foreach (var item in this.cboDept.Items)
                {
                    var dpt = item as DepartmentModel;
                    if (dpt.Code == user.Department)
                    {
                        this.cboDept.SelectedItem = item;
                    }
                }

                this.btnSave.Text = "保 存";
                this.btnSave.Tag = user;
            }

            if (e.RowIndex > -1 && e.ColumnIndex > 0 && grdUser.Columns[e.ColumnIndex].Name == "Del")
            {
                DialogResult dailogResult = MessageBox.Show("确定要删除该项？", "删除用户", MessageBoxButtons.OKCancel);
                if (dailogResult == System.Windows.Forms.DialogResult.OK)
                {
                    _userModel.Delete(grdUser.Rows[e.RowIndex].Cells[6].Value.ToString());
                    this.grdUser.DataSource = _userModel.GetAll();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtAccount.Text = "";
            this.txtName.Text = "";
            this.txtPwd.Text = "";
            this.chkStatus.Checked = true;
            this.btnSave.Tag = null;
            this.btnSave.Text = "增 加";
            this.cboDept.SelectedIndex = 1;
        }

        private void grdUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }

            DataGridView grdUser = (DataGridView)sender;

            if (grdUser.Columns[e.ColumnIndex].DataPropertyName == "Status")
            {
                var isEnable = Convert.ToBoolean(e.Value);
                if (isEnable)
                {
                    e.Value = "激活";
                }
                else {
                    e.Value = "禁用";
                }
            }

            if (grdUser.Columns[e.ColumnIndex].DataPropertyName == "Department")
            {
                var dptCode = e.Value.ToString().Trim();
                foreach (var dpt in depts)
                {
                    if (dpt.Code == dptCode)
                    {
                        e.Value = dpt.Name;
                    }
                }
            }

            if (grdUser.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var btnSave = sender as Button;
            var userModel = btnSave.Tag as UserModel;
            if (userModel != null)
            {
                //Update                
                if (this.txtPwd.Text.Trim() != string.Empty)
                {
                    userModel.Password = CryptographyHelper.SHA256(this.txtPwd.Text);
                }
                userModel.Status = this.chkStatus.Checked;
                userModel.Name = this.txtName.Text.Trim();
                userModel.Department = this.cboDept.SelectedValue.ToString();
                userModel.UpdatedBy = UIContext.LoginUser.Account;
                userModel.UpdatedDate = DateTime.Now;
                _userModel.Update(userModel);
               
            }
            else
            { 
                //Add
                userModel = new UserModel();
                userModel.Account = this.txtAccount.Text.Trim();
                userModel.Password = CryptographyHelper.SHA256(this.txtPwd.Text.Trim());
                userModel.Name = this.txtName.Text.Trim();
                userModel.Department = this.cboDept.SelectedValue.ToString();
                userModel.Status = this.chkStatus.Checked;
                userModel.CreatedBy = UIContext.LoginUser.Account;
                userModel.CreatedDate = DateTime.Now;
                userModel.UpdatedBy = UIContext.LoginUser.Account;
                userModel.UpdatedDate = DateTime.Now;
                _userModel.Create(userModel);

            }

            btnClear_Click(null, null);
            this.grdUser.DataSource = _userModel.GetAll();

        }
        
    }
}
