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
    public partial class frmOutStore : Form
    {
        private OutStoreModel _outStoreModel = new OutStoreModel();
        private InStoreModel _inStoreModel = new InStoreModel();
        private DepartmentModel _dptModel = new DepartmentModel();
        private List<DepartmentModel> dptModels = new List<DepartmentModel>();
        Dictionary<string, string> _materialDicts = new Dictionary<string, string>();
        private UserModel _userModel = new UserModel();
        private List<UserModel> userModels = new List<UserModel>();
        private MaterialModel _materielModel = new MaterialModel();

        public frmOutStore()
        {
            InitializeComponent();
        }

        private void frmStoreOut_Load(object sender, EventArgs e)
        {
            _materialDicts = _outStoreModel.GetMaterialKeyValuePaire();

            LoadOperator();
            LoadMeterialType();
            LoadMeterialChildType();
            LoadOutDpts();
            LoadGrd_ZKPZ();
            LoadGrd_NZKPZ();
            LoadGrd_DJB();
            LoadGrd_JJ();
            LoadGrd_OTHER();
            
            LoadGrd_Outstores();
        } 
        #region common grd control
        private void GenerateOutStoreColumn(DataGridView grd)
        {
            DataGridViewTextBoxColumn txtIndexCol = new DataGridViewTextBoxColumn();
            txtIndexCol.DataPropertyName = "Index";
            txtIndexCol.HeaderText = "序号";
            txtIndexCol.ReadOnly = true;
            txtIndexCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtIndexCol.Width = 40;
            txtIndexCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grd.Columns.Add(txtIndexCol);


            DataGridViewTextBoxColumn txtAccountCol = new DataGridViewTextBoxColumn();
            txtAccountCol.DataPropertyName = "Code";
            txtAccountCol.HeaderText = "编　码";
            txtAccountCol.ReadOnly = true;
            grd.Columns.Add(txtAccountCol);


            DataGridViewTextBoxColumn txtNameCol = new DataGridViewTextBoxColumn();
            txtNameCol.DataPropertyName = "Name";
            txtNameCol.HeaderText = "名　称";
            txtNameCol.ReadOnly = true;
            txtNameCol.Width = 200;
            grd.Columns.Add(txtNameCol);

            DataGridViewTextBoxColumn txtRemainNumberCol = new DataGridViewTextBoxColumn();
            txtRemainNumberCol.DataPropertyName = "RemainNumber";
            txtRemainNumberCol.HeaderText = "剩余数量";
            txtRemainNumberCol.Width = 80;
            txtRemainNumberCol.ReadOnly = true;
            grd.Columns.Add(txtRemainNumberCol);

            DataGridViewTextBoxColumn txtCKSLCol = new DataGridViewTextBoxColumn();
            txtCKSLCol.DataPropertyName = "OutNumber";
            txtCKSLCol.HeaderText = "出库数量";
            txtCKSLCol.Width = 80;
            grd.Columns.Add(txtCKSLCol);

            DataGridViewTextBoxColumn txtUnitCol = new DataGridViewTextBoxColumn();
            txtUnitCol.DataPropertyName = "UnitPrice";
            txtUnitCol.HeaderText = "单 价";
            txtUnitCol.Width = 78;
            txtUnitCol.ReadOnly = true;
            grd.Columns.Add(txtUnitCol);

            DataGridViewTextBoxColumn txtTotalCol = new DataGridViewTextBoxColumn();
            txtTotalCol.DataPropertyName = "RemainTotalPrice";
            txtTotalCol.HeaderText = "剩余总价";
            txtTotalCol.Width = 80;
            txtTotalCol.ReadOnly = true;
            grd.Columns.Add(txtTotalCol);

            DataGridViewTextBoxColumn txtDateCol = new DataGridViewTextBoxColumn();
            txtDateCol.DataPropertyName = "UpdatedDate";
            txtDateCol.HeaderText = "日 期";
            txtDateCol.Width = 100;
            txtDateCol.ReadOnly = true;
            grd.Columns.Add(txtDateCol);

            DataGridViewTextBoxColumn txtUpdatedByCol = new DataGridViewTextBoxColumn();
            txtUpdatedByCol.DataPropertyName = "UpdatedBy";
            txtUpdatedByCol.HeaderText = "操作员";
            txtUpdatedByCol.Width = 80;
            txtUpdatedByCol.ReadOnly = true;
            grd.Columns.Add(txtUpdatedByCol);

            DataGridViewTextBoxColumn txtInstoreIdCol = new DataGridViewTextBoxColumn();
            txtInstoreIdCol.DataPropertyName = "Id";
            txtInstoreIdCol.HeaderText = "入库Id";
            txtInstoreIdCol.Width = 80;
            txtInstoreIdCol.Visible = false;
            grd.Columns.Add(txtInstoreIdCol);

            DataGridViewTextBoxColumn txtUnitIdsCol = new DataGridViewTextBoxColumn();
            txtUnitIdsCol.DataPropertyName = "UnitIds";
            txtUnitIdsCol.HeaderText = "入库MergeIds";
            txtUnitIdsCol.Width = 80;
            txtUnitIdsCol.Visible = false;
            grd.Columns.Add(txtUnitIdsCol);

            grd.EditMode = DataGridViewEditMode.EditOnEnter;
            grd.ScrollBars = ScrollBars.Both;
            grd.AutoGenerateColumns = false;
            grd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetGridStyle(DataGridView grd)
        {
            grd.RowHeadersWidth = 34;
            grd.ColumnHeadersHeight = 34;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grd.RowTemplate.Height = 32;
            grd.RowHeadersVisible = false;
            grd.Height = 520;
            //grd.Width = 560;
        }
        #endregion

        #region ZKPZ
        private void LoadGrd_ZKPZ()
        {
            GenerateOutStoreColumn(this.grdZKPZ);
            this.grdZKPZ.Tag = MaterialModel.MatType.ZKPZ.ToString();

            this.SetGridStyle(this.grdZKPZ);

            this.grdZKPZ.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.ZKPZ.ToString());
            this.grdZKPZ.Columns[1].Visible = false;
            this.grdZKPZ.ScrollBars = ScrollBars.Both;
        }

        private void grdZKPZ_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "OutNumber")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Name")
            {
                e.Value = _materialDicts[e.Value.ToString()];
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedBy" && e.Value != null)
            {
                foreach (var user in userModels)
                {
                    if (e.Value.ToString().Equals(user.Account))
                    {
                        e.Value = user.Name;
                    }
                }
            }


            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }
        }
        #endregion

        #region NZKPZ
        private void LoadGrd_NZKPZ()
        {
            GenerateOutStoreColumn(this.grdNZKPZ);
            this.grdNZKPZ.Tag = MaterialModel.MatType.NZKPZ.ToString();

            this.SetGridStyle(this.grdNZKPZ);

            this.grdNZKPZ.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.NZKPZ.ToString());
            this.grdNZKPZ.Columns[1].Visible = false;
            this.grdNZKPZ.ScrollBars = ScrollBars.Both;
        }

        private void grdNZKPZ_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "OutNumber")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Name")
            {
                e.Value = _materialDicts[e.Value.ToString()];
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedBy" && e.Value != null)
            {
                foreach (var user in userModels)
                {
                    if (e.Value.ToString().Equals(user.Account))
                    {
                        e.Value = user.Name;
                    }
                }
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }
        }
        #endregion

        #region DJB
        private void LoadGrd_DJB()
        {
            GenerateOutStoreColumn(this.grdDJB);
            this.grdDJB.Tag = MaterialModel.MatType.DJB.ToString();

            this.SetGridStyle(this.grdDJB);

            this.grdDJB.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.DJB.ToString());
            this.grdDJB.Columns[1].Visible = false;
            this.grdDJB.ScrollBars = ScrollBars.Both;
        }

        private void grdDJB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "OutNumber")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Name")
            {
                e.Value = _materialDicts[e.Value.ToString()];
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedBy" && e.Value != null)
            {
                foreach (var user in userModels)
                {
                    if (e.Value.ToString().Equals(user.Account))
                    {
                        e.Value = user.Name;
                    }
                }
            }


            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }
        }
        #endregion

        #region JJ
        private void LoadGrd_JJ()
        {
            GenerateOutStoreColumn(this.grdJJ);
            this.grdJJ.Tag = MaterialModel.MatType.JJ.ToString();

            this.SetGridStyle(this.grdJJ);

            this.grdJJ.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.JJ.ToString());
            this.grdJJ.Columns[1].Visible = false;
            this.grdJJ.ScrollBars = ScrollBars.Both;
        }

        private void grdJJ_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "OutNumber")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Name")
            {
                e.Value = _materialDicts[e.Value.ToString()];
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedBy" && e.Value != null)
            {
                foreach (var user in userModels)
                {
                    if (e.Value.ToString().Equals(user.Account))
                    {
                        e.Value = user.Name;
                    }
                }
            }


            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }
        }
        #endregion

        #region OTHER
        private void LoadGrd_OTHER()
        {
            GenerateOutStoreColumn(this.grdOther);
            this.grdOther.Tag = MaterialModel.MatType.OTHER.ToString();

            this.SetGridStyle(this.grdOther);

            this.grdOther.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.OTHER.ToString());
            this.grdOther.Columns[1].Visible = false;
            this.grdOther.ScrollBars = ScrollBars.Both;
        }

        private void grdOther_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "OutNumber")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Name")
            {
                e.Value = _materialDicts[e.Value.ToString()];
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedBy" && e.Value != null)
            {
                foreach (var user in userModels)
                {
                    if (e.Value.ToString().Equals(user.Account))
                    {
                        e.Value = user.Name;
                    }
                }
            }


            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }
        }
        #endregion

        #region Validate
        private void grdZKPZ_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidate(this.grdZKPZ, e);
        }

        private void grdNZKPZ_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidate(this.grdNZKPZ, e);
        }

        private void grdDJB_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidate(this.grdDJB, e);
        }

        private void grdJJ_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidate(this.grdJJ, e);
        }

        private void grdOther_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            CellValidate(this.grdOther, e);
        }

        private void CellValidate(DataGridView grd, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 4)
            {
                if (e.FormattedValue.ToString() == "") { return; }
                int outDb = 0;
                if (Int32.TryParse(e.FormattedValue.ToString(), out outDb))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    grd.CancelEdit();
                }

                if (outDb <= 0 || outDb > Int32.Parse(grd.Rows[e.RowIndex].Cells[3].Value.ToString()))
                {
                    e.Cancel = true;
                    grd.CancelEdit();
                }
            }
        }
        #endregion

        #region grd out store
        private void GenerateOutStoreDetialColumn(DataGridView grd)
        {
            DataGridViewTextBoxColumn txtIndexCol = new DataGridViewTextBoxColumn();
            txtIndexCol.DataPropertyName = "Index";
            txtIndexCol.HeaderText = "序号";
            txtIndexCol.ReadOnly = true;
            txtIndexCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtIndexCol.Width = 40;
            txtIndexCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grd.Columns.Add(txtIndexCol);


            DataGridViewTextBoxColumn txtAccountCol = new DataGridViewTextBoxColumn();
            txtAccountCol.DataPropertyName = "Code";
            txtAccountCol.HeaderText = "编　码";
            txtAccountCol.ReadOnly = true;
            grd.Columns.Add(txtAccountCol);


            DataGridViewTextBoxColumn txtStatusCol = new DataGridViewTextBoxColumn();
            txtStatusCol.DataPropertyName = "Name";
            txtStatusCol.HeaderText = "名　称";
            txtStatusCol.ReadOnly = true;
            //txtStatusCol.Width = 200;
            grd.Columns.Add(txtStatusCol);

            DataGridViewTextBoxColumn txtNumberCol = new DataGridViewTextBoxColumn();
            txtNumberCol.DataPropertyName = "Number";
            txtNumberCol.HeaderText = "数量";
            //txtNumberCol.Width = 78;
            grd.Columns.Add(txtNumberCol);

            DataGridViewTextBoxColumn txtUnitCol = new DataGridViewTextBoxColumn();
            txtUnitCol.DataPropertyName = "UnitPrice";
            txtUnitCol.HeaderText = "单 价";
            //txtUnitCol.Width = 78;

            grd.Columns.Add(txtUnitCol);

            DataGridViewTextBoxColumn txtTotalCol = new DataGridViewTextBoxColumn();
            txtTotalCol.DataPropertyName = "TotalPrice";
            txtTotalCol.HeaderText = "总 价";
            //txtTotalCol.Width = 80;
            grd.Columns.Add(txtTotalCol);

            DataGridViewTextBoxColumn txtTypeCol = new DataGridViewTextBoxColumn();
            txtTypeCol.DataPropertyName = "type";
            txtTypeCol.HeaderText = "类 型";
            //txtTypeCol.Width = 80;
            grd.Columns.Add(txtTypeCol);

            DataGridViewTextBoxColumn txtDptCol = new DataGridViewTextBoxColumn();
            txtDptCol.DataPropertyName = "Department";
            txtDptCol.HeaderText = "网 点";
            //txtDptCol.Width = 80;
            grd.Columns.Add(txtDptCol);

            DataGridViewTextBoxColumn txtDateCol = new DataGridViewTextBoxColumn();
            txtDateCol.DataPropertyName = "UpdatedDate";
            txtDateCol.HeaderText = "日 期";
            //txtDateCol.Width = 100;
            grd.Columns.Add(txtDateCol);

            DataGridViewTextBoxColumn txtUpdatedByCol = new DataGridViewTextBoxColumn();
            txtUpdatedByCol.DataPropertyName = "UpdatedBy";
            txtUpdatedByCol.HeaderText = "操作员";
            //txtUpdatedByCol.Width = 80;
            grd.Columns.Add(txtUpdatedByCol);

            DataGridViewTextBoxColumn txtIdCol = new DataGridViewTextBoxColumn();
            txtIdCol.DataPropertyName = "Id";
            txtIdCol.HeaderText = "Id";
            txtIdCol.Visible = false;
            grd.Columns.Add(txtIdCol);

            DataGridViewButtonColumn btnDeleteCol = new DataGridViewButtonColumn();
            btnDeleteCol.Name = "Del";
            btnDeleteCol.UseColumnTextForButtonValue = true;
            btnDeleteCol.Text = "删 除";
            btnDeleteCol.HeaderText = "删 除";
            btnDeleteCol.Width = 60;
            btnDeleteCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grd.Columns.Add(btnDeleteCol);

            grd.AutoSize = true;
            grd.ScrollBars = ScrollBars.Both;
            grd.AutoGenerateColumns = false;            
            grd.ScrollBars = ScrollBars.Both;
            grd.AutoGenerateColumns = false;
            grd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadGrd_Outstores()
        {
            GenerateOutStoreDetialColumn(this.grdOutStores);

            this.SetGridStyle(this.grdOutStores);
            this.grdOutStores.ColumnHeadersHeight = 32;
            this.grdOutStores.RowTemplate.Height = 28;
            this.grdOutStores.Width = 740;          
            //var beginDate = Convert.ToDateTime(DateTime.Now.AddDays(-30).ToShortDateString() + " 00:00:00");
            var beginDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00");
            this.dtpBegin.Value = beginDate;
            var endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59:59");
            var outStoreModels = _outStoreModel.Query(beginDate, endDate, null, null, null, null);
            SetDepartment(outStoreModels);
            SetName(outStoreModels);
            SetMaterialType(outStoreModels);
            SetOperator(outStoreModels);
            this.grdOutStores.DataSource = outStoreModels;
            //this.grdOutStores.DataSource = _outStoreModel.Query(beginDate, endDate, null, null, null); 
            this.grdOutStores.Columns[1].Visible = false;
        }

        private void LoadOperator()
        {
            if (userModels.Count == 0)
            {
                userModels = _userModel.GetAll();
            }
            userModels.Add(new UserModel { Name = "全部", Account = "-111" });
            this.cboOperator.DataSource = userModels;
            this.cboOperator.DisplayMember = "Name";
            this.cboOperator.ValueMember = "Account";
            this.cboOperator.SelectedIndex = userModels.Count - 1;
        }

        private void LoadMeterialType()
        {
            Dictionary<string, string> meterialTypes = new Dictionary<string, string>();
            meterialTypes.Add("-111", "全部");
            meterialTypes.Add(MaterialModel.MatType.ZKPZ.ToString(), "重空凭证");
            meterialTypes.Add(MaterialModel.MatType.NZKPZ.ToString(), "非重空凭证");
            meterialTypes.Add(MaterialModel.MatType.DJB.ToString(), "登记薄");
            meterialTypes.Add(MaterialModel.MatType.JJ.ToString(), "机具");
            meterialTypes.Add(MaterialModel.MatType.OTHER.ToString(), "其它");

            var meterialTypeList = from mtype in meterialTypes
                                   select new { key = mtype.Key, name = mtype.Value };

            this.cboType.DataSource = meterialTypeList.ToList();
            this.cboType.DisplayMember = "name";
            this.cboType.ValueMember = "key";
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedValue.ToString().Equals("-111"))
            {
                LoadMeterialChildType();
            }
            else
            {
                var meterialModels = new List<MaterialModel>();
                meterialModels.Add(new MaterialModel() { Code = "-111", Name = "全部" });
                var meterialModelAll = _materielModel.GetByType(cboType.SelectedValue.ToString());
                meterialModels.AddRange(meterialModelAll);
                this.cboChildType.DataSource = meterialModels;
                this.cboChildType.DisplayMember = "Name";
                this.cboChildType.ValueMember = "Code";
            }
        }

        private void LoadMeterialChildType()
        {
            Dictionary<string, string> meterialChildTypes = new Dictionary<string, string>();
            meterialChildTypes.Add("-111", "全部");
            var meterialChildTypeList = from mtype in meterialChildTypes
                                        select new { key = mtype.Key, name = mtype.Value };

            this.cboChildType.DataSource = meterialChildTypeList.ToList();
            this.cboChildType.DisplayMember = "name";
            this.cboChildType.ValueMember = "key";
        }
        #endregion        

        #region Save, Query
        private void btnStoreOut(DataGridView grd)
        {
            var isSaveOk = false;
            if (grd.Rows != null && grd.Rows.Count > 0)
            {
                foreach (var row in grd.Rows)
                {
                    var grdRow = row as DataGridViewRow;
                    if (grdRow.Cells[4].Value != null)
                    {
                        var code = grdRow.Cells[1].Value.ToString();
                        var remainNumber = Int32.Parse(grdRow.Cells[3].Value.ToString());
                        var outNumber = Int32.Parse(grdRow.Cells[4].Value.ToString());
                        var inStoreId = grdRow.Cells[9].Value.ToString();
                        var unitStoreIds = grdRow.Cells[10].Value != null ? grdRow.Cells[10].Value.ToString() : "";
                        if (outNumber > 0)
                        {
                            decimal unitPrice = 0.00M;
                            decimal totalPrice = 0.00M;
                            if (grdRow.Cells[5].Value != null)
                            {
                                unitPrice = decimal.Parse(grdRow.Cells[5].Value.ToString());
                                totalPrice = outNumber * unitPrice;
                            }

                            OutStoreModel outStoreModel = new OutStoreModel();
                            outStoreModel.Id = Guid.NewGuid().ToString();
                            outStoreModel.Code = code;
                            outStoreModel.Department = this.cboZKPZDpts.SelectedValue.ToString();
                            outStoreModel.Number = outNumber;
                            outStoreModel.UnitPrice = unitPrice;
                            outStoreModel.TotalPrice = totalPrice;
                            outStoreModel.Type = grd.Tag.ToString();
                            outStoreModel.InstoreId = inStoreId;
                            outStoreModel.CreatedBy = UIContext.LoginUser.Account;
                            outStoreModel.CreatedDate = DateTime.Now;
                            outStoreModel.UpdatedBy = UIContext.LoginUser.Account;
                            outStoreModel.UpdatedDate = DateTime.Now;                            
                            _outStoreModel.OutStore(outStoreModel);

                            isSaveOk = true;
                        }
                    }
                }

            }
            if (isSaveOk)
            {
                btnQueryStoreDetails_Click(null, null);
            }

        }

        private void btnZKPZStoreOut_Click(object sender, EventArgs e)
        {
            DialogResult dailogResult = MessageBox.Show("确定要出库？", "出库提示", MessageBoxButtons.OKCancel);
            if (dailogResult == System.Windows.Forms.DialogResult.OK)
            {
                btnStoreOut(this.grdZKPZ);
                this.grdZKPZ.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.ZKPZ.ToString());
            }
        }

        private void btnNZKPZStoreOut_Click(object sender, EventArgs e)
        {
            DialogResult dailogResult = MessageBox.Show("确定要出库？", "出库提示", MessageBoxButtons.OKCancel);
            if (dailogResult == System.Windows.Forms.DialogResult.OK)
            {
                btnStoreOut(this.grdNZKPZ);
                this.grdNZKPZ.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.NZKPZ.ToString());
            }
        }

        private void btnDJBStoreOut_Click(object sender, EventArgs e)
        {
            DialogResult dailogResult = MessageBox.Show("确定要出库？", "出库提示", MessageBoxButtons.OKCancel);
            if (dailogResult == System.Windows.Forms.DialogResult.OK)
            {
                btnStoreOut(this.grdDJB);
                this.grdDJB.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.DJB.ToString());
            }
        }

        private void btnJJStoreOut_Click(object sender, EventArgs e)
        {
            DialogResult dailogResult = MessageBox.Show("确定要出库？", "出库提示", MessageBoxButtons.OKCancel);
            if (dailogResult == System.Windows.Forms.DialogResult.OK)
            {
                btnStoreOut(this.grdJJ);
                this.grdJJ.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.JJ.ToString());
            }
        }

        private void btnOTHERStoreOut_Click(object sender, EventArgs e)
        {
            DialogResult dailogResult = MessageBox.Show("确定要出库？", "出库提示", MessageBoxButtons.OKCancel);
            if (dailogResult == System.Windows.Forms.DialogResult.OK)
            {
                btnStoreOut(this.grdOther);
                this.grdOther.DataSource = _inStoreModel.GetKCByType(MaterialModel.MatType.OTHER.ToString());
            }
        }

        private void LoadOutDpts()
        {
            if (dptModels.Count == 0)
            {
                dptModels = _dptModel.GetAll();
            }

            if (dptModels != null && dptModels.Count > 0)
            {
                var dptsOut = from dpt in dptModels
                              where dpt.Type == (int)DepartmentModel.DeptType.OUT
                              select new { code = dpt.Code, name = dpt.Name };

                this.cboOTHERDpts.DataSource = dptsOut.ToList();
                this.cboOTHERDpts.DisplayMember = "name";
                this.cboOTHERDpts.ValueMember = "code";

                this.cboJJDpts.DataSource = dptsOut.ToList();
                this.cboJJDpts.DisplayMember = "name";
                this.cboJJDpts.ValueMember = "code";

                this.cboDJBDpts.DataSource = dptsOut.ToList();
                this.cboDJBDpts.DisplayMember = "name";
                this.cboDJBDpts.ValueMember = "code";

                this.cboNZKPZDpts.DataSource = dptsOut.ToList();
                this.cboNZKPZDpts.DisplayMember = "name";
                this.cboNZKPZDpts.ValueMember = "code";

                this.cboZKPZDpts.DataSource = dptsOut.ToList();
                this.cboZKPZDpts.DisplayMember = "name";
                this.cboZKPZDpts.ValueMember = "code";

                var dpts = dptsOut.ToList();
                dpts.Insert(0,new {code = "-111",name = "全部"});
                this.cboDepartment.DataSource = dpts;
                this.cboDepartment.DisplayMember = "name";
                this.cboDepartment.ValueMember = "code";
            }

        }

        private void cboZKPZDpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboZKPZDpts.Items != null && this.cboZKPZDpts.Items.Count > 0)
            {
                this.cboNZKPZDpts.SelectedIndex = this.cboZKPZDpts.SelectedIndex;
                this.cboDJBDpts.SelectedIndex = this.cboZKPZDpts.SelectedIndex;
                this.cboJJDpts.SelectedIndex = this.cboZKPZDpts.SelectedIndex;
                this.cboOTHERDpts.SelectedIndex = this.cboZKPZDpts.SelectedIndex;
            }
        }

        private void cboNZKPZDpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboZKPZDpts.Items != null && this.cboZKPZDpts.Items.Count > 0)
            {
                this.cboZKPZDpts.SelectedIndex = this.cboNZKPZDpts.SelectedIndex;
                this.cboDJBDpts.SelectedIndex = this.cboNZKPZDpts.SelectedIndex;
                this.cboJJDpts.SelectedIndex = this.cboNZKPZDpts.SelectedIndex;
                this.cboOTHERDpts.SelectedIndex = this.cboNZKPZDpts.SelectedIndex;
            }
        }

        private void cboDJBDpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboZKPZDpts.Items != null && this.cboZKPZDpts.Items.Count > 0)
            {
                this.cboZKPZDpts.SelectedIndex = this.cboDJBDpts.SelectedIndex;
                this.cboNZKPZDpts.SelectedIndex = this.cboDJBDpts.SelectedIndex;
                this.cboJJDpts.SelectedIndex = this.cboDJBDpts.SelectedIndex;
                this.cboOTHERDpts.SelectedIndex = this.cboDJBDpts.SelectedIndex;
            }
        }

        private void cboJJDpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboZKPZDpts.Items != null && this.cboZKPZDpts.Items.Count > 0)
            {
                this.cboZKPZDpts.SelectedIndex = this.cboJJDpts.SelectedIndex;
                this.cboNZKPZDpts.SelectedIndex = this.cboJJDpts.SelectedIndex;
                this.cboDJBDpts.SelectedIndex = this.cboJJDpts.SelectedIndex;
                this.cboOTHERDpts.SelectedIndex = this.cboJJDpts.SelectedIndex;
            }
        }

        private void cboOTHERDpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboZKPZDpts.Items != null && this.cboZKPZDpts.Items.Count > 0)
            {
                this.cboZKPZDpts.SelectedIndex = this.cboOTHERDpts.SelectedIndex;
                this.cboNZKPZDpts.SelectedIndex = this.cboOTHERDpts.SelectedIndex;
                this.cboDJBDpts.SelectedIndex = this.cboOTHERDpts.SelectedIndex;
                this.cboJJDpts.SelectedIndex = this.cboOTHERDpts.SelectedIndex;
            }
        }

        private void grdOutStores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            //if (grd.Columns[e.ColumnIndex].DataPropertyName == "Name" && e.Value != null)
            //{
            //    e.Value = _materialDicts[e.Value.ToString()];
            //}

            //if (grd.Columns[e.ColumnIndex].DataPropertyName == "Department" && e.Value != null)
            //{
            //    foreach (var dpt in dptModels)
            //    {
            //        if (dpt.Code == e.Value.ToString())
            //        {
            //            e.Value = dpt.Name;
            //        }
            //    }
            //}

            //if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedBy" && e.Value != null)
            //{
            //    foreach (var user in userModels)
            //    {
            //        if (e.Value.ToString().Equals(user.Account))
            //        {
            //            e.Value = user.Name;
            //        }
            //    }
            //}

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedDate")
            {
                e.Value = e.Value.ToString().Split(' ')[0];
            }

            //if (grd.Columns[e.ColumnIndex].DataPropertyName == "type" && e.Value != null)
            //{
            //    if (e.Value.ToString() == MaterialModel.MatType.ZKPZ.ToString())
            //    {
            //        e.Value = "重空凭证";
            //    }
            //    if (e.Value.ToString() == MaterialModel.MatType.NZKPZ.ToString())
            //    {
            //        e.Value = "非重空凭证";
            //    }
            //    if (e.Value.ToString() == MaterialModel.MatType.DJB.ToString())
            //    {
            //        e.Value = "登记薄";
            //    }
            //    if (e.Value.ToString() == MaterialModel.MatType.JJ.ToString())
            //    {
            //        e.Value = "机具";
            //    }
            //    if (e.Value.ToString() == MaterialModel.MatType.OTHER.ToString())
            //    {
            //        e.Value = "其它";
            //    }
            //}
        }

        private void btnQueryStoreDetails_Click(object sender, EventArgs e)
        {
            var beginDate = Convert.ToDateTime(this.dtpBegin.Value.ToShortDateString() + " 00:00:00");
            var endDate = Convert.ToDateTime(this.dptEnd.Value.ToShortDateString() + " 23:59:59");
            var type = this.cboType.SelectedValue.ToString() != "-111" ? this.cboType.SelectedValue.ToString() : null;
            var code = this.cboChildType.SelectedValue.ToString() != "-111" ? this.cboChildType.SelectedValue.ToString() : null;
            var operatorStoreIn = this.cboOperator.SelectedValue.ToString() != "-111" ? this.cboOperator.SelectedValue.ToString() : null;
            var dpt = this.cboDepartment.SelectedValue.ToString() != "-111" ? this.cboDepartment.SelectedValue.ToString() : null;
            var outStoreModels = _outStoreModel.Query(beginDate, endDate, type, code, operatorStoreIn, dpt);
            SetDepartment(outStoreModels);
            SetName(outStoreModels);            
            SetMaterialType(outStoreModels);
            SetOperator(outStoreModels);
            this.grdOutStores.DataSource = outStoreModels;
        }       
        #endregion             

        private void SetMaterialType(List<OutStoreModel> outStoreModels)
        {
            if (outStoreModels != null && outStoreModels.Count > 0)
            {
                foreach (var outStoreModel in outStoreModels)
                {
                    if (outStoreModel.Type == MaterialModel.MatType.ZKPZ.ToString())
                    {
                        outStoreModel.Type = "重空凭证";
                    }
                    if (outStoreModel.Type == MaterialModel.MatType.NZKPZ.ToString())
                    {
                        outStoreModel.Type = "非重空凭证";
                    }
                    if (outStoreModel.Type == MaterialModel.MatType.DJB.ToString())
                    {
                        outStoreModel.Type = "登记薄";
                    }
                    if (outStoreModel.Type == MaterialModel.MatType.JJ.ToString())
                    {
                        outStoreModel.Type = "机具";
                    }
                    if (outStoreModel.Type == MaterialModel.MatType.OTHER.ToString())
                    {
                        outStoreModel.Type = "其它";
                    }
                }
            }
        }

        private void SetDepartment(List<OutStoreModel> outStoreModels)
        {
            if (outStoreModels != null && outStoreModels.Count > 0)
            {
                foreach (var outStoreModel in outStoreModels)
                {
                    foreach (var dpt in dptModels)
                    {
                        if (dpt.Code == outStoreModel.Department)
                        {
                            outStoreModel.Department = dpt.Name;
                        }
                    }
                }
            }
        }

        private void SetName(List<OutStoreModel> outStoreModels)
        {
            if (outStoreModels != null && outStoreModels.Count > 0)
            {
                foreach (var outStoreModel in outStoreModels)
                {
                    outStoreModel.Name = _materialDicts[outStoreModel.Name];
                }
            }
        }

        private void SetOperator(List<OutStoreModel> outStoreModels)
        {
            if (outStoreModels != null && outStoreModels.Count > 0)
            {
                foreach (var outStoreModel in outStoreModels)
                {
                    foreach (var user in userModels)
                    {
                        if (outStoreModel.UpdatedBy.Equals(user.Account))
                        {
                            outStoreModel.UpdatedBy = user.Name;
                        }
                    }
                }
            }
        }

        private void grdOutStores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > 0 && grdOutStores.Columns[e.ColumnIndex].Name == "Del")
            {

                DialogResult dailogResult = MessageBox.Show("确定要删除该项？", "删除出库记录？", MessageBoxButtons.OKCancel);
                if (dailogResult == System.Windows.Forms.DialogResult.OK)
                {
                    _outStoreModel.Delete(grdOutStores.Rows[e.RowIndex].Cells[10].Value.ToString());
                    btnQueryStoreDetails_Click(null, null);

                    LoadGrd_ZKPZ();
                    LoadGrd_NZKPZ();
                    LoadGrd_DJB();
                    LoadGrd_JJ();
                    LoadGrd_OTHER();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.btnExport.Enabled = false;
            var outStoreModels = this.grdOutStores.DataSource as List<OutStoreModel>;
            if (outStoreModels != null && outStoreModels.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "出库记录";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.Filter = "*xls files(*.xlsx)|*.xlsx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.RestoreDirectory = true;
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var fileName = saveFileDialog.FileName.ToString();
                    _outStoreModel.ExportToOutStoreExcel(fileName, outStoreModels, this.dtpBegin.Value.ToShortDateString(), this.dptEnd.Value.ToShortDateString());
                    MessageBox.Show("导出出库记录成功！");
                }                
            }
            else
            {
                MessageBox.Show("没有出库记录！");
            }
            this.btnExport.Enabled = true;
        }        
    }
}
