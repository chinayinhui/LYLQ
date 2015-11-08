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
using System.Text.RegularExpressions;


namespace LYLQ.WinUI
{
    public partial class frmInStore : Form
    {
        private InStoreModel _inStoreModel = new InStoreModel();
        private UserModel _userModel = new UserModel();
        private MaterialModel _materielModel = new MaterialModel();
        private List<UserModel> userModels = new List<UserModel>();
        Dictionary<string, string> _materialDicts = new Dictionary<string, string>();
        private List<DepartmentModel> dptModels = new List<DepartmentModel>();
        
        public frmInStore()
        {
            InitializeComponent();
        }

        private void frmStoreIn_Load(object sender, EventArgs e)
        {
            _materialDicts = _inStoreModel.GetMaterialKeyValuePaire();

            LoadGrd_ZKPZ();
            LoadGrd_NZKPZ();
            LoadGrd_DJB();
            LoadGrd_JJ();
            LoadGrd_Other();

            LoadMeterialType();
            LoadMeterialChildType();
            LoadOperator();
            LoadGrd_Instores();
            
        }

        #region common grid
        private void GenerateColumn(DataGridView grd)
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
            txtStatusCol.Width = 200;
            txtStatusCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grd.Columns.Add(txtStatusCol);

            DataGridViewTextBoxColumn txtNumberCol = new DataGridViewTextBoxColumn();
            txtNumberCol.DataPropertyName = "Number";
            txtNumberCol.HeaderText = "数 量";
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
            grd.Columns.Add(txtTotalCol);

            DataGridViewTextBoxColumn txtTypeCol = new DataGridViewTextBoxColumn();
            txtTypeCol.DataPropertyName = "type";
            txtTypeCol.HeaderText = "类 型";
            //txtTypeCol.Width = 80;
            grd.Columns.Add(txtTypeCol);

            DataGridViewTextBoxColumn txtDateCol = new DataGridViewTextBoxColumn();
            txtDateCol.DataPropertyName = "UpdatedDate";
            txtDateCol.HeaderText = "日 期";            
            grd.Columns.Add(txtDateCol);

            DataGridViewTextBoxColumn txtUpdatedByCol = new DataGridViewTextBoxColumn();
            txtUpdatedByCol.DataPropertyName = "UpdatedBy";
            txtUpdatedByCol.HeaderText = "操作员";
            grd.Columns.Add(txtUpdatedByCol);

            DataGridViewButtonColumn btnDeleteCol = new DataGridViewButtonColumn();
            btnDeleteCol.Name = "Del";
            btnDeleteCol.UseColumnTextForButtonValue = true;
            btnDeleteCol.Text = "删 除";
            btnDeleteCol.HeaderText = "删 除";
            btnDeleteCol.Width = 60;
            btnDeleteCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            grd.Columns.Add(btnDeleteCol);

            DataGridViewTextBoxColumn txtId = new DataGridViewTextBoxColumn();
            txtId.DataPropertyName = "Id";
            txtId.HeaderText = "Id";
            txtId.Visible = false;
            grd.Columns.Add(txtId);

            DataGridViewTextBoxColumn txtRemainNumberCol = new DataGridViewTextBoxColumn();
            txtRemainNumberCol.DataPropertyName = "RemainNumber";
            txtRemainNumberCol.HeaderText = "剩余数量";
            txtRemainNumberCol.Visible = false;
            //txtNumberCol.Width = 78;
            grd.Columns.Add(txtRemainNumberCol);

            grd.AutoGenerateColumns = false;
            grd.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetGridStyle(DataGridView grd)
        {
            grd.RowHeadersWidth = 34;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grd.ColumnHeadersHeight = 34;
            grd.RowTemplate.Height = 32;            
            grd.ScrollBars = ScrollBars.Vertical;
            grd.RowHeadersVisible = false;
            grd.Height = 540;           
            grd.AutoSize = true;
            grd.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        #endregion

        #region ZKPZ
        private void LoadGrd_ZKPZ()
        {
            GenerateColumn(this.grdZKPZ);
            this.grdZKPZ.Tag = MaterialModel.MatType.ZKPZ.ToString();

            this.SetGridStyle(this.grdZKPZ);

            this.grdZKPZ.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.ZKPZ.ToString());
            this.grdZKPZ.Columns[1].Visible = false;
            this.grdZKPZ.Columns[6].Visible = false;
            this.grdZKPZ.Columns[7].Visible = false;
            this.grdZKPZ.Columns[8].Visible = false;
            this.grdZKPZ.Columns[9].Visible = false;
            this.grdZKPZ.ScrollBars = ScrollBars.Vertical;
            this.grdZKPZ.Width = 500;
        }

        private void grdZKPZ_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Number" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "UnitPrice" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "TotalPrice")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void grdZKPZ_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var grd = sender as DataGridView;
            var row = grd.Rows[e.RowIndex];
            if (e.ColumnIndex == 4 && row.Cells[4].Value != null && row.Cells[3].Value != null)
            {                
                var number = Int32.Parse(row.Cells[3].Value.ToString());
                var price = double.Parse(row.Cells[4].Value.ToString());
                var totalPrice = number * price;
                row.Cells[5].Value = totalPrice.ToString();

            }
        }
        #endregion

        #region NZKPZ
        private void LoadGrd_NZKPZ()
        {
            GenerateColumn(this.grdNZKPZ);
            this.grdNZKPZ.Tag = MaterialModel.MatType.NZKPZ.ToString();

            this.SetGridStyle(this.grdNZKPZ);

            this.grdNZKPZ.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.NZKPZ.ToString());
            this.grdNZKPZ.Columns[1].Visible = false;
            this.grdNZKPZ.Columns[6].Visible = false;
            this.grdNZKPZ.Columns[7].Visible = false;
            this.grdNZKPZ.Columns[8].Visible = false;
            this.grdNZKPZ.Columns[9].Visible = false;
            this.grdNZKPZ.ScrollBars = ScrollBars.Vertical;
            this.grdNZKPZ.Width = 530;
        }

        private void grdNZKPZ_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Number" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "UnitPrice" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "TotalPrice")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void grdNZKPZ_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var grd = sender as DataGridView;
            var row = grd.Rows[e.RowIndex];
            if (e.ColumnIndex == 4 && row.Cells[4].Value != null && row.Cells[3].Value != null)
            {                
                var number = Int32.Parse(row.Cells[3].Value.ToString());
                var price = double.Parse(row.Cells[4].Value.ToString());
                var totalPrice = number * price;
                row.Cells[5].Value = totalPrice.ToString();

            }
        }
        #endregion

        #region DJB
        private void LoadGrd_DJB()
        {
            GenerateColumn(this.grdDJB);
            this.grdDJB.Tag = MaterialModel.MatType.DJB.ToString();

            this.SetGridStyle(this.grdDJB);

            this.grdDJB.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.DJB.ToString());
            this.grdDJB.Columns[1].Visible = false;
            this.grdDJB.Columns[6].Visible = false;
            this.grdDJB.Columns[7].Visible = false;
            this.grdDJB.Columns[8].Visible = false;
            this.grdDJB.Columns[9].Visible = false;
            this.grdDJB.ScrollBars = ScrollBars.Vertical;
            this.grdDJB.Width = 530;
        }

        private void grdDJB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Number" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "UnitPrice" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "TotalPrice")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void grdDJB_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var grd = sender as DataGridView;
            var row = grd.Rows[e.RowIndex];
            if (e.ColumnIndex == 4 && row.Cells[4].Value != null && row.Cells[3].Value != null)
            {              
                var number = Int32.Parse(row.Cells[3].Value.ToString());
                var price = double.Parse(row.Cells[4].Value.ToString());
                var totalPrice = number * price;
                row.Cells[5].Value = totalPrice.ToString();

            }
        }
        #endregion

        #region JJ
        private void LoadGrd_JJ()
        {
            GenerateColumn(this.grdJJ);
            this.grdJJ.Tag = MaterialModel.MatType.JJ.ToString();

            this.SetGridStyle(this.grdJJ);

            this.grdJJ.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.JJ.ToString());
            this.grdJJ.Columns[1].Visible = false;
            this.grdJJ.Columns[6].Visible = false;
            this.grdJJ.Columns[7].Visible = false;
            this.grdJJ.Columns[8].Visible = false;
            this.grdJJ.Columns[9].Visible = false;
            this.grdJJ.ScrollBars = ScrollBars.Vertical;
            this.grdJJ.Width = 530;
        }

        private void grdJJ_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Number" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "UnitPrice" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "TotalPrice")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void grdJJ_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var grd = sender as DataGridView;
            var row = grd.Rows[e.RowIndex];
            if (e.ColumnIndex == 4 && row.Cells[4].Value != null && row.Cells[3].Value != null)
            {               
                var number = Int32.Parse(row.Cells[3].Value.ToString());
                var price = double.Parse(row.Cells[4].Value.ToString());
                var totalPrice = number * price;
                row.Cells[5].Value = totalPrice.ToString();

            }
        }
        #endregion

        #region Other 
        private void LoadGrd_Other()
        {
            GenerateColumn(this.grdOther);
            this.grdOther.Tag = MaterialModel.MatType.OTHER.ToString();

            this.SetGridStyle(this.grdOther);

            this.grdOther.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.OTHER.ToString());
            this.grdOther.Columns[1].Visible = false;
            this.grdOther.Columns[6].Visible = false;
            this.grdOther.Columns[7].Visible = false;
            this.grdOther.Columns[8].Visible = false;
            this.grdOther.Columns[9].Visible = false;
            this.grdOther.ScrollBars = ScrollBars.Vertical;
            this.grdOther.Width = 530;
        }

        private void grdOther_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Number" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "UnitPrice" ||
                grd.Columns[e.ColumnIndex].DataPropertyName == "TotalPrice")
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 255);
            }

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "Index")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void grdOther_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var grd = sender as DataGridView;
            var row = grd.Rows[e.RowIndex];
            if (e.ColumnIndex == 4 && row.Cells[4].Value != null && row.Cells[3].Value != null)
            {               
                var number = Int32.Parse(row.Cells[3].Value.ToString());
                var price = double.Parse(row.Cells[4].Value.ToString());
                var totalPrice = number * price;
                row.Cells[5].Value = totalPrice.ToString();

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
            if (e.RowIndex > -1 && (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5))
            {
                if (e.FormattedValue.ToString() == "") { return; }
                double outDb = 0;
                if (double.TryParse(e.FormattedValue.ToString(), out outDb))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    grd.CancelEdit();
                }

                if (outDb < 0)
                {
                    e.Cancel = true;
                    grd.CancelEdit();
                }
            }
        }
        #endregion

        #region In store details
        private void LoadGrd_Instores()
        {
            GenerateColumn(this.grdInStores);

            this.SetGridStyle(this.grdInStores);
            this.grdInStores.ColumnHeadersHeight = 32;
            this.grdInStores.RowTemplate.Height = 28;
            //this.grdInStores.Width = 736;

            //var beginDate = Convert.ToDateTime(DateTime.Now.AddDays(-30).ToShortDateString() + " 00:00:00");
            var beginDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00");
            this.dtpBegin.Value = beginDate;
            var endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59:59");
            var instoreModels = _inStoreModel.Query(beginDate, endDate, null, null, null);
            SetName(instoreModels);
            SetMaterialType(instoreModels);
            SetOperator(instoreModels);
            this.grdInStores.DataSource = instoreModels;
            this.grdInStores.Columns[1].Visible = false;
            this.grdInStores.ScrollBars = ScrollBars.Both;
        }

        private void grdInStores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            //if (grd.Columns[e.ColumnIndex].DataPropertyName == "Name" && e.Value != null)
            //{
            //    e.Value = _materialDicts[e.Value.ToString()];
            //}

            //if (grd.Columns[e.ColumnIndex].DataPropertyName == "UpdatedBy" && e.Value != null)
            //{
            //    foreach (var user in userModels)
            //    {
            //        if (e.Value.ToString().Equals(user.Account)) {
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

        private void SetMaterialType(List<InStoreModel> inStoreModels)
        {
            if (inStoreModels != null && inStoreModels.Count > 0)
            {
                foreach (var instoreModel in inStoreModels)
                {
                    if(instoreModel.Type == MaterialModel.MatType.ZKPZ.ToString())
                    {
                        instoreModel.Type = "重空凭证";
                    }
                    if (instoreModel.Type == MaterialModel.MatType.NZKPZ.ToString())
                    {
                        instoreModel.Type = "非重空凭证";
                    }
                    if (instoreModel.Type == MaterialModel.MatType.DJB.ToString())
                    {
                        instoreModel.Type = "登记薄";
                    }
                    if (instoreModel.Type == MaterialModel.MatType.JJ.ToString())
                    {
                        instoreModel.Type = "机具";
                    }
                    if (instoreModel.Type == MaterialModel.MatType.OTHER.ToString())
                    {
                        instoreModel.Type = "其它";
                    }
                }                
            }
        }

        private void SetName(List<InStoreModel> inStoreModels)
        {
            if (inStoreModels != null && inStoreModels.Count > 0)
            {
                foreach (var instoreModel in inStoreModels)
                {
                    instoreModel.Name = _materialDicts[instoreModel.Name];
                }
            }
        }

        private void SetOperator(List<InStoreModel> inStoreModels)
        {
            if (inStoreModels != null && inStoreModels.Count > 0)
            {
                foreach (var instoreModel in inStoreModels)
                {
                    foreach (var user in userModels)
                    {
                        if (instoreModel.UpdatedBy.Equals(user.Account))
                        {
                            instoreModel.UpdatedBy = user.Name;
                        }
                    }
                }
            }
        }

        private void LoadOperator() {
            if (userModels.Count == 0) {
                userModels = _userModel.GetAll();
            }
            userModels.Add(new UserModel { Name = "全部", Account = "-111" });
            this.cboOperator.DataSource = userModels;
            this.cboOperator.DisplayMember = "Name";
            this.cboOperator.ValueMember = "Account";
            this.cboOperator.SelectedIndex = userModels.Count - 1;
        }

        private void LoadMeterialType() {
            Dictionary<string, string> meterialTypes = new Dictionary<string, string>();
            meterialTypes.Add("-111", "全部");
            meterialTypes.Add(MaterialModel.MatType.ZKPZ.ToString(),"重空凭证");
            meterialTypes.Add(MaterialModel.MatType.NZKPZ.ToString(), "非重空凭证");
            meterialTypes.Add(MaterialModel.MatType.DJB.ToString(), "登记薄");
            meterialTypes.Add(MaterialModel.MatType.JJ.ToString(), "机具");
            meterialTypes.Add(MaterialModel.MatType.OTHER.ToString(), "其它");

            var meterialTypeList = from mtype in meterialTypes
                                   select new {key = mtype.Key, name = mtype.Value };

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
                meterialModels.Add(new MaterialModel() { Code="-111", Name = "全部" });
                var meterialModelAll = _materielModel.GetByType(cboType.SelectedValue.ToString());
                meterialModels.AddRange(meterialModelAll);
                this.cboChildType.DataSource = meterialModels;
                this.cboChildType.DisplayMember = "Name";
                this.cboChildType.ValueMember = "Code";
            }
        }
        
        private void LoadMeterialChildType() {
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
        private void StoreIn(DataGridView grd)
        {
            var ctrls = this.tabContainer.TabPages;
            var isSaveOk = false;
            if (grd.Rows != null && grd.Rows.Count > 0)
            {
                foreach (var row in grd.Rows)
                {
                    var grdRow = row as DataGridViewRow;
                    if (grdRow.Cells[3].Value != null)
                    {
                        var code = grdRow.Cells[1].Value.ToString();
                        var number = Int32.Parse(grdRow.Cells[3].Value.ToString());
                        if (number > 0)
                        {
                            decimal unitPrice = 0.00M;
                            decimal totalPrice = 0.00M;
                            if (grdRow.Cells[4].Value != null)
                            {
                                unitPrice = decimal.Parse(grdRow.Cells[4].Value.ToString());
                            }
                            if (grdRow.Cells[5].Value != null)
                            {
                                totalPrice = decimal.Parse(grdRow.Cells[5].Value.ToString());
                            }

                            InStoreModel inStoreModel = new InStoreModel();
                            inStoreModel.Id = Guid.NewGuid().ToString();
                            inStoreModel.Code = code;
                            inStoreModel.Department = UIContext.LoginUser.Department;
                            inStoreModel.Number = number;
                            inStoreModel.RemainNumber = number;
                            inStoreModel.RemainTotalPrice = totalPrice;
                            inStoreModel.UnitPrice = unitPrice;
                            inStoreModel.TotalPrice = totalPrice;
                            inStoreModel.Type = grd.Tag.ToString();
                            inStoreModel.CreatedBy = UIContext.LoginUser.Account;
                            inStoreModel.CreatedDate = DateTime.Now;
                            inStoreModel.UpdatedBy = UIContext.LoginUser.Account;
                            inStoreModel.UpdatedDate = DateTime.Now;
                            _inStoreModel.Create(inStoreModel);

                            isSaveOk = true;
                        }
                    }
                }

            }
            

            if (isSaveOk)
            {
                refreshGrids();
            }
        }

        private void btnQueryStoreDetails_Click(object sender, EventArgs e)
        {
            var beginDate = Convert.ToDateTime(this.dtpBegin.Value.ToShortDateString() + " 00:00:00");
            var endDate = Convert.ToDateTime(this.dptEnd.Value.ToShortDateString() + " 23:59:59");
            var type = this.cboType.SelectedValue.ToString() != "-111" ? this.cboType.SelectedValue.ToString() : null;
            var code = this.cboChildType.SelectedValue.ToString() != "-111" ? this.cboChildType.SelectedValue.ToString() : null;
            var operatorStoreIn = this.cboOperator.SelectedValue.ToString() != "-111" ? this.cboOperator.SelectedValue.ToString() : null;
            var instoreModels = _inStoreModel.Query(beginDate, endDate, type, code, operatorStoreIn);
            SetName(instoreModels);
            SetMaterialType(instoreModels);
            SetOperator(instoreModels);
            this.grdInStores.DataSource = instoreModels;
        }

        private void btnStoreInZKPZ_Click(object sender, EventArgs e)
        {
            StoreIn(this.grdZKPZ);
        }

        private void btnStoreInNZKPZ_Click(object sender, EventArgs e)
        {
            StoreIn(this.grdNZKPZ);
        }

        private void btnInstoreDJB_Click(object sender, EventArgs e)
        {
            StoreIn(this.grdDJB);
        }
        
        private void btnStoreInJJ_Click(object sender, EventArgs e)
        {
            StoreIn(this.grdJJ);
        }

        private void btnStoreInOther_Click(object sender, EventArgs e)
        {
            StoreIn(this.grdOther);
        }        

        private void refreshGrids()
        {
            this.grdZKPZ.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.ZKPZ.ToString());
            this.grdNZKPZ.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.NZKPZ.ToString());
            this.grdDJB.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.DJB.ToString());
            this.grdJJ.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.JJ.ToString());
            this.grdOther.DataSource = _inStoreModel.GetInData(MaterialModel.MatType.OTHER.ToString());

            btnQueryStoreDetails_Click(null, null);
        }
        #endregion           

        private void grdInStores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > 0 && grdInStores.Columns[e.ColumnIndex].Name == "Del")
            {
                var number = grdInStores.Rows[e.RowIndex].Cells[3].Value.ToString();
                var remainNumber = grdInStores.Rows[e.RowIndex].Cells[11].Value.ToString();
                if(number == remainNumber)
                {
                    DialogResult dailogResult = MessageBox.Show("确定要删除该项？", "删除入库记录？", MessageBoxButtons.OKCancel);
                    if (dailogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        _inStoreModel.Delete(grdInStores.Rows[e.RowIndex].Cells[10].Value.ToString());
                        btnQueryStoreDetails_Click(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("已出库，不能删除！", "删除提示？", MessageBoxButtons.OK);
                }
                
            }
        }

        #region Export to excel

        private void btnExportZKPZ_Click(object sender, EventArgs e)
        {
            ExpotToExcel(sender);
        }

        private void ExpotToExcel(object sender)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            var inStoreModels = this.grdInStores.DataSource as List<InStoreModel>;
            if (inStoreModels != null && inStoreModels.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "入库记录";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.Filter = "*xls files(*.xlsx)|*.xlsx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.RestoreDirectory = true;
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var fileName = saveFileDialog.FileName.ToString();
                    _inStoreModel.ExportToExcel(fileName, inStoreModels, this.dtpBegin.Value.ToShortDateString(), this.dptEnd.Value.ToShortDateString());
                    MessageBox.Show("导出成功！");
                }                
            }
            else
            {
                MessageBox.Show("没有记录！");
            }
            btn.Enabled = true;
        }

        #endregion

    }
}
