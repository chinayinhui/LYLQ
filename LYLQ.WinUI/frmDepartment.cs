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

namespace LYLQ.WinUI
{
    public partial class frmDepartment : Form
    {
        private DepartmentModel _departmentModel = new DepartmentModel();

        public frmDepartment()
        {
            InitializeComponent();            
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn txtIndexCol = new DataGridViewTextBoxColumn();
            txtIndexCol.DataPropertyName = "Index";
            txtIndexCol.HeaderText = "序　号";
            txtIndexCol.Width = 60;
            txtIndexCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grdDpt.Columns.Add(txtIndexCol);


            DataGridViewTextBoxColumn txtAccountCol = new DataGridViewTextBoxColumn();
            txtAccountCol.DataPropertyName = "Code";
            txtAccountCol.HeaderText = " 编　码 ";
            this.grdDpt.Columns.Add(txtAccountCol);

            DataGridViewTextBoxColumn txtNameCol = new DataGridViewTextBoxColumn();
            txtNameCol.DataPropertyName = "Name";
            txtNameCol.HeaderText = "名　称";
            txtNameCol.Width = 200;
            //txtNameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grdDpt.Columns.Add(txtNameCol);

            DataGridViewTextBoxColumn txtTypeCol = new DataGridViewTextBoxColumn();
            txtTypeCol.DataPropertyName = "Type";
            txtTypeCol.HeaderText = " 类 型 ";
            this.grdDpt.Columns.Add(txtTypeCol);

            DataGridViewTextBoxColumn txtCreatedDateCol = new DataGridViewTextBoxColumn();
            txtCreatedDateCol.DataPropertyName = "UpdatedDate";
            txtCreatedDateCol.HeaderText = "日 期";
            txtCreatedDateCol.Width = 130;
            this.grdDpt.Columns.Add(txtCreatedDateCol);

            DataGridViewButtonColumn btnEditCol = new DataGridViewButtonColumn();
            btnEditCol.Name = "Edit";
            btnEditCol.UseColumnTextForButtonValue = true;
            btnEditCol.Text = "编 辑";
            btnEditCol.HeaderText = "编 辑";
            btnEditCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnEditCol.Width = 60;
            this.grdDpt.Columns.Add(btnEditCol);

            DataGridViewButtonColumn btnDeleteCol = new DataGridViewButtonColumn();
            btnDeleteCol.Name = "Del";
            btnDeleteCol.UseColumnTextForButtonValue = true;
            btnDeleteCol.Text = "删 除";
            btnDeleteCol.HeaderText = "删 除";
            btnDeleteCol.Width = 60;
            btnDeleteCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grdDpt.Columns.Add(btnDeleteCol);            
            
            this.SetGridStyle();

            this.grdDpt.AutoGenerateColumns = false;            
            this.grdDpt.DataSource = _departmentModel.GetAll();
        }

        private void SetGridStyle()
        {            
            this.grdDpt.ColumnHeadersHeight = 32;
            this.grdDpt.RowTemplate.Height = 30;
            this.grdDpt.Height = 580;
            this.grdDpt.AutoSize = true;
            this.grdDpt.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.grdDpt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.grdDpt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.grdDpt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.grdDpt.ScrollBars = ScrollBars.Vertical;
            this.grdDpt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtDptCode.Text = "";
            this.txtDptCode.Enabled = true;
            this.txtDptName.Text = "";
            this.btnSave.Text = "添 加";
            this.rboIn.Checked = true;
            this.btnSave.Tag = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Tag == null)
            {
                //Add
                DepartmentModel dptModel = new DepartmentModel();
                dptModel.Name = this.txtDptName.Text.Trim();
                dptModel.Code = this.txtDptCode.Text.Trim();
                dptModel.CreatedBy = UIContext.LoginUser.Account;
                dptModel.CreatedDate = DateTime.Now;
                dptModel.UpdatedBy = UIContext.LoginUser.Account;
                dptModel.UpdatedDate = DateTime.Now;
                if (this.rboIn.Checked)
                {
                    dptModel.Type = (int)DepartmentModel.DeptType.IN;
                }
                else
                {
                    dptModel.Type = (int)DepartmentModel.DeptType.OUT;
                }

                _departmentModel.Create(dptModel);
                btnClear_Click(null, null);
            }
            else
            {
                var dptModel = new DepartmentModel();
                dptModel.Code = this.txtDptCode.Text.Trim();
                dptModel.Name = this.txtDptName.Text.Trim();
                dptModel.UpdatedBy = UIContext.LoginUser.Account;
                dptModel.UpdatedDate = DateTime.Now;
                _departmentModel.Update(dptModel);
                btnClear_Click(null, null);
            }

            this.grdDpt.DataSource = _departmentModel.GetAll();
        }

        private void grdDpt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grdDpt = sender as DataGridView;
            if (e.RowIndex > -1 && e.ColumnIndex > 0 && grdDpt.Columns[e.ColumnIndex].Name == "Edit")
            {
                var account = grdDpt.Rows[e.RowIndex].Cells[1].Value.ToString();
                var dpt = _departmentModel.GetByCode(account);

                this.txtDptCode.Text = dpt.Code;
                this.txtDptCode.Enabled = false;
                this.txtDptName.Text = dpt.Name;
                var isInDept = dpt.Type == (int)DepartmentModel.DeptType.IN;
                if (isInDept)
                {
                    this.rboIn.Checked = true;
                }
                else
                {
                    this.rboOut.Checked = true;
                }

                this.btnSave.Text = "保 存";
                this.btnSave.Tag = dpt; 
            }

            if (e.RowIndex > -1 && e.ColumnIndex > 0 && grdDpt.Columns[e.ColumnIndex].Name == "Del")
            {                
                DialogResult  dailogResult = MessageBox.Show("确定要删除该项？", "删除网点", MessageBoxButtons.OKCancel);
                if (dailogResult == System.Windows.Forms.DialogResult.OK)
                {
                    _departmentModel.Delete(grdDpt.Rows[e.RowIndex].Cells[1].Value.ToString());
                    this.grdDpt.DataSource = _departmentModel.GetAll();
                }
            }

            if (e.RowIndex > -1 && e.ColumnIndex > 0 && grdDpt.Columns[e.ColumnIndex].Name == "Name")
            {
                grdDpt.Rows[e.RowIndex].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }            
        }

        private void grdDpt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }

            DataGridView grdDept = (DataGridView)sender;

            if (grdDept.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }

            if (grdDept.Columns[e.ColumnIndex].DataPropertyName == "Type")
            {
                var inType = Convert.ToInt16(e.Value) == (int)DepartmentModel.DeptType.IN;
                if (inType)
                {
                    e.Value = "入库";
                }
                else
                {
                    e.Value = "出库";
                }
            }
        }
               
    }
}
