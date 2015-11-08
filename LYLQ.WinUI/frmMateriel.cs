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
    public partial class frmMateriel : Form
    {
        public frmMateriel()
        {
            InitializeComponent();
        }

        private MaterialModel _materielModel = new MaterialModel();


        private void frmMateriel_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn txtNameCol = new DataGridViewTextBoxColumn();
            txtNameCol.DataPropertyName = "Index";
            txtNameCol.HeaderText = "序　号";
            txtNameCol.Width = 80;
            txtNameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grdMat.Columns.Add(txtNameCol);


            DataGridViewTextBoxColumn txtAccountCol = new DataGridViewTextBoxColumn();
            txtAccountCol.DataPropertyName = "Code";
            txtAccountCol.HeaderText = "编　码";
            this.grdMat.Columns.Add(txtAccountCol);

            DataGridViewTextBoxColumn txtStatusCol = new DataGridViewTextBoxColumn();
            txtStatusCol.DataPropertyName = "Name";
            txtStatusCol.HeaderText = "名　称";
            //txtStatusCol.Width = 200;
            this.grdMat.Columns.Add(txtStatusCol);

            DataGridViewTextBoxColumn txtTypeCol = new DataGridViewTextBoxColumn();
            txtTypeCol.DataPropertyName = "Type";
            txtTypeCol.HeaderText = "类 型";
            this.grdMat.Columns.Add(txtTypeCol);

            DataGridViewTextBoxColumn txtCreatedDateCol = new DataGridViewTextBoxColumn();
            txtCreatedDateCol.DataPropertyName = "UpdatedDate";
            txtCreatedDateCol.HeaderText = "日 期";
            this.grdMat.Columns.Add(txtCreatedDateCol);

            DataGridViewButtonColumn btnEditCol = new DataGridViewButtonColumn();
            btnEditCol.Name = "Edit";
            btnEditCol.UseColumnTextForButtonValue = true;
            btnEditCol.Text = "编 辑";
            btnEditCol.HeaderText = "编 辑";
            btnEditCol.Width = 70;
            btnEditCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grdMat.Columns.Add(btnEditCol);

            DataGridViewButtonColumn btnDelCol = new DataGridViewButtonColumn();
            btnDelCol.Name = "Del";
            btnDelCol.UseColumnTextForButtonValue = true;
            btnDelCol.Text = "删 除";
            btnDelCol.HeaderText = "删 除";
            btnDelCol.Width = 70;
            btnDelCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            this.grdMat.Columns.Add(btnDelCol);

            this.SetGridStyle();
           
            this.grdMat.AutoGenerateColumns = false;
            this.grdMat.DataSource = _materielModel.GetAll();

            this.grdMat.Columns[1].Visible = false;

            this.rboJB_DJB.Tag = MaterialModel.MatType.DJB.ToString();
            this.rboJB_JJ.Tag = MaterialModel.MatType.JJ.ToString(); 
            this.rboJB_NZKPZ.Tag = MaterialModel.MatType.NZKPZ.ToString();
            this.rboJB_Other.Tag = MaterialModel.MatType.OTHER.ToString(); 
            this.rboJB_ZKPZ.Tag = MaterialModel.MatType.ZKPZ.ToString();
        }

        private void SetGridStyle()
        {
            this.grdMat.ColumnHeadersHeight = 32;
            this.grdMat.RowTemplate.Height = 30;
            this.grdMat.Height = 560;
            this.grdMat.AutoSize = true;
            this.grdMat.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.grdMat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.grdMat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.grdMat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.grdMat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdMat.ScrollBars = ScrollBars.Vertical;            
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtMatCode.Text = "";
            this.txtMatName.Text = "";
            this.btnSave.Text = "添 加";
            if (sender != null)
            {
                this.rboJB_DJB.Checked = false;
                this.rboJB_JJ.Checked = false;
                this.rboJB_NZKPZ.Checked = false;
                this.rboJB_Other.Checked = false;
                this.rboJB_ZKPZ.Checked = true;
            }
            this.btnSave.Tag = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.btnSave.Tag == null)
            {
                //Add
                MaterialModel matModel = new MaterialModel();
                matModel.Name = this.txtMatName.Text.Trim();
                matModel.Code = GetCode(); // this.txtMatCode.Text.Trim();
                matModel.CreatedBy = UIContext.LoginUser.Account;
                matModel.CreatedDate = DateTime.Now;
                matModel.UpdatedBy = UIContext.LoginUser.Account;
                matModel.UpdatedDate = DateTime.Now;

                if (this.rboJB_DJB.Checked)
                {
                    matModel.Type = this.rboJB_DJB.Tag.ToString();
                }
                if (this.rboJB_JJ.Checked)
                {
                    matModel.Type = this.rboJB_JJ.Tag.ToString();
                }
                if (this.rboJB_NZKPZ.Checked)
                {
                    matModel.Type = this.rboJB_NZKPZ.Tag.ToString();
                }
                if (this.rboJB_Other.Checked)
                {
                    matModel.Type = this.rboJB_Other.Tag.ToString();
                }
                if (this.rboJB_ZKPZ.Checked)
                {
                    matModel.Type = this.rboJB_ZKPZ.Tag.ToString();
                }

                _materielModel.Create(matModel);
                btnClear_Click(null, null);
            }
            else
            {
                MaterialModel matModel = new MaterialModel();
                matModel.Name = this.txtMatName.Text.Trim();
                matModel.Code = this.txtMatCode.Text.Trim();                
                matModel.UpdatedBy = UIContext.LoginUser.Account;
                matModel.UpdatedDate = DateTime.Now;

                _materielModel.Update(matModel);
            }

            refreshMaterials();
        }

        private void refreshMaterials()
        {
            if (rboAll.Checked)
            {
                this.grdMat.DataSource = _materielModel.GetAll();
            }

            if (rboZKPZ.Checked)
            {
                this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.ZKPZ.ToString());
            }

            if (rboNZKPZ.Checked)
            {
                this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.NZKPZ.ToString());
            }

            if (rboDJB.Checked)
            {
                this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.DJB.ToString());
            }

            if (rboJJ.Checked)
            {
                this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.JJ.ToString());
            }

            if (rboOther.Checked)
            {
                this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.OTHER.ToString());
            }
        }

        private string GetCode()
        {
            if (rboAll.Checked)
            {
                this.grdMat.DataSource = _materielModel.GetAll();
            }

            if (rboZKPZ.Checked)
            {
                var materialModels =  _materielModel.GetByType(MaterialModel.MatType.ZKPZ.ToString());
                return MaterialModel.MatType.ZKPZ.ToString()+ "_" + (materialModels.Count + 1).ToString().PadLeft(2, '0');
            }

            if (rboNZKPZ.Checked)
            {
                var materialModels =  _materielModel.GetByType(MaterialModel.MatType.NZKPZ.ToString());
                return MaterialModel.MatType.NZKPZ.ToString() + "_" + (materialModels.Count + 1).ToString().PadLeft(2, '0');
            }

            if (rboDJB.Checked)
            {
                var materialModels = _materielModel.GetByType(MaterialModel.MatType.DJB.ToString());
                return MaterialModel.MatType.DJB.ToString() + "_" + (materialModels.Count + 1).ToString().PadLeft(2, '0');
            }

            if (rboJJ.Checked)
            {
                var materialModels = _materielModel.GetByType(MaterialModel.MatType.JJ.ToString());
                return MaterialModel.MatType.JJ.ToString() + "_" + (materialModels.Count + 1).ToString().PadLeft(2, '0');
            }

            if (rboOther.Checked)
            {
                var materialModels = _materielModel.GetByType(MaterialModel.MatType.OTHER.ToString());
                return MaterialModel.MatType.OTHER.ToString() + "_" + (materialModels.Count + 1).ToString().PadLeft(2, '0');
            }

            return "";
        }

        private void grdMat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grdMat = sender as DataGridView;
            if (e.RowIndex > -1 && e.ColumnIndex > 0 && grdMat.Columns[e.ColumnIndex].Name == "Edit")
            {
                var account = grdMat.Rows[e.RowIndex].Cells[1].Value.ToString();
                var dpt = _materielModel.GetByCode(account);

                this.txtMatCode.Text = dpt.Code;
                this.txtMatName.Text = dpt.Name;

                this.rboJB_DJB.Checked = dpt.Type == this.rboJB_DJB.Tag.ToString();
                this.rboJB_JJ.Checked = dpt.Type == this.rboJB_JJ.Tag.ToString();
                this.rboJB_NZKPZ.Checked = dpt.Type == this.rboJB_NZKPZ.Tag.ToString();
                this.rboJB_Other.Checked = dpt.Type == this.rboJB_Other.Tag.ToString();
                this.rboJB_ZKPZ.Checked = dpt.Type == this.rboJB_ZKPZ.Tag.ToString();                

                this.btnSave.Text = "保 存";
                this.btnSave.Tag = dpt;
            }

            if (e.RowIndex > -1 && e.ColumnIndex > 0 && grdMat.Columns[e.ColumnIndex].Name == "Del")
            {
                DialogResult dailogResult = MessageBox.Show("确定要删除该项？", "删除用户", MessageBoxButtons.OKCancel);
                if (dailogResult == System.Windows.Forms.DialogResult.OK)
                {
                    _materielModel.Delete(grdMat.Rows[e.RowIndex].Cells[1].Value.ToString());
                    refreshMaterials();
                }
            }
        }

        private void grdMat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e == null || e.Value == null || !(sender is DataGridView))
            {
                return;
            }

            DataGridView grdDept = (DataGridView)sender;

            if (grdDept.Columns[e.ColumnIndex].DataPropertyName == "Type")
            {
                var type = e.Value.ToString();
                switch(type)
                {
                    case "ZKPZ":
                        e.Value = "重空凭证";
                        break;
                    case "NZKPZ":
                        e.Value = "非重空凭证";
                        break;
                    case "DJB":
                        e.Value = "登记薄";
                        break;
                    case "JJ":
                        e.Value = "机具类";
                        break;
                    case "OTHER":
                        e.Value = "其它";
                        break;
                    default:
                        e.Value = "不存在";
                        break;
                }
            }

            if (grdDept.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }
        }

        private void rboAll_CheckedChanged(object sender, EventArgs e)
        {
            this.grdMat.DataSource = _materielModel.GetAll();
        }

        private void rboZKPZ_CheckedChanged(object sender, EventArgs e)
        {
            this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.ZKPZ.ToString());
        }

        private void rboNZKPZ_CheckedChanged(object sender, EventArgs e)
        {
            this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.NZKPZ.ToString());
        }

        private void rboDJB_CheckedChanged(object sender, EventArgs e)
        {
            this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.DJB.ToString());
        }

        private void rboJJ_CheckedChanged(object sender, EventArgs e)
        {
            this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.JJ.ToString());
        }

        private void rboOther_CheckedChanged(object sender, EventArgs e)
        {
            this.grdMat.DataSource = _materielModel.GetByType(MaterialModel.MatType.OTHER.ToString());
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult dailogResult = MessageBox.Show("清空入库和出库记录？", "清空数据", MessageBoxButtons.OKCancel);
            if (dailogResult == System.Windows.Forms.DialogResult.OK)
            {
                _materielModel.ClearInstoreAndOutStoreDatas();
                MessageBox.Show("清空入库，出库记录成功！", "清空数据", MessageBoxButtons.OK);
            }
        }                                           
    }
}
