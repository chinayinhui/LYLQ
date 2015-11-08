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
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace LYLQ.WinUI
{
    public partial class frmReport : Form
    {
        private OutStoreModel _outStoreModel = new OutStoreModel();
        private InStoreModel _inStoreModel = new InStoreModel();
        private DepartmentModel _dptModel = new DepartmentModel();
        private List<DepartmentModel> dptModels = new List<DepartmentModel>();
        Dictionary<string, string> _materialDicts = new Dictionary<string, string>();
        private UserModel _userModel = new UserModel();
        private List<UserModel> userModels = new List<UserModel>();
        private MaterialModel _materielModel = new MaterialModel();
        private List<OutStoreModel> excelOutModels = new List<OutStoreModel>();

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmStoreOut_Load(object sender, EventArgs e)
        {
            _materialDicts = _outStoreModel.GetMaterialKeyValuePaire();           
            dptModels = _dptModel.GetAll();

            LoadOutDpts();
            LoadMeterialType();
            LoadMeterialChildType();
            LoadGrd_Report();
        } 
       
        private void GenerateOutStoreDetialColumn(DataGridView grd)
        {
            DataGridViewTextBoxColumn txtDepartmentCol = new DataGridViewTextBoxColumn();
            txtDepartmentCol.DataPropertyName = "Department";
            txtDepartmentCol.HeaderText = "网 点";
            //txtDepartmentCol.Width = 160;
            txtDepartmentCol.ReadOnly = true;
            grd.Columns.Add(txtDepartmentCol);


            DataGridViewTextBoxColumn txtStatusCol = new DataGridViewTextBoxColumn();
            txtStatusCol.DataPropertyName = "Name";
            txtStatusCol.HeaderText = "名　称";
            txtStatusCol.ReadOnly = true;           
            //txtStatusCol.Width = 210;
            grd.Columns.Add(txtStatusCol);

            DataGridViewTextBoxColumn txtTypeCol = new DataGridViewTextBoxColumn();
            txtTypeCol.DataPropertyName = "type";
            txtTypeCol.HeaderText = "类 型";
            //txtTypeCol.Width = 80;
            grd.Columns.Add(txtTypeCol);

            DataGridViewTextBoxColumn txtNumberCol = new DataGridViewTextBoxColumn();
            txtNumberCol.DataPropertyName = "Number";
            txtNumberCol.HeaderText = "数 量";
            //txtNumberCol.Width = 78;
            grd.Columns.Add(txtNumberCol);

            DataGridViewTextBoxColumn txtUnitPriceCol = new DataGridViewTextBoxColumn();
            txtUnitPriceCol.DataPropertyName = "UnitPrice";
            txtUnitPriceCol.HeaderText = "单 价";
            //txtUnitPriceCol.Width = 78;
            grd.Columns.Add(txtUnitPriceCol);   

            DataGridViewTextBoxColumn txtTotalPriceCol = new DataGridViewTextBoxColumn();
            txtTotalPriceCol.DataPropertyName = "TotalPrice";
            txtTotalPriceCol.HeaderText = "总 价";            
            grd.Columns.Add(txtTotalPriceCol);            

            DataGridViewTextBoxColumn txtSumPriceCol = new DataGridViewTextBoxColumn();
            txtSumPriceCol.DataPropertyName = "SumPrice";
            txtSumPriceCol.HeaderText = "合 计";            
            grd.Columns.Add(txtSumPriceCol);

            DataGridViewTextBoxColumn txtMergeCol = new DataGridViewTextBoxColumn();
            txtMergeCol.DataPropertyName = "CanMerge";
            txtMergeCol.HeaderText = "CanMerge";
            txtMergeCol.Visible = false;
            grd.Columns.Add(txtMergeCol);

            grd.ScrollBars = ScrollBars.Both;
            grd.AutoGenerateColumns = false;
            grd.ReadOnly = true;
            grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetGridStyle(DataGridView grd)
        {
            grd.ColumnHeadersHeight = 30;
            grd.RowTemplate.Height = 26;
            grd.Height = 600;
            grd.AutoSize = true;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grd.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           
            grd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grd.ReadOnly = true;
            grd.ScrollBars = ScrollBars.Vertical;        
        }

        private void LoadGrd_Report()
        {
            GenerateOutStoreDetialColumn(this.grdOutStores);

            this.SetGridStyle(this.grdOutStores);
            //this.grdOutStores.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.grdOutStores.Width = 828;          
            var beginDate = Convert.ToDateTime(DateTime.Now.AddDays(-30).ToShortDateString() + " 00:00:00");
            this.dtpBegin.Value = beginDate;
            var endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59:59");
            var outModels = _outStoreModel.QueryCount(beginDate, endDate, null, null, null);
            outModels = SetOutStoreType(outModels);
            outModels = SetItemMerge(outModels);
            SetOutModelColuName(outModels);
            this.grdOutStores.DataSource = outModels;

            //excelOutModels = outModels;
            //SetOutModelColuName(excelOutModels);
        }

        private List<OutStoreModel> SetOutStoreType(List<OutStoreModel> outModels)
        {
            if (outModels != null && outModels.Count > 0)
            {
                outModels = (from item in outModels
                             orderby item.Department
                             select item).ToList();

                foreach (var outModel in outModels)
                {
                    foreach (var dpt in dptModels)
                    {
                        if (dpt.Code == outModel.Department)
                        {
                            outModel.Department = dpt.Name;
                        }
                    }
                }                
            }
            return outModels;
        }

        private List<OutStoreModel> SetItemMerge(List<OutStoreModel> outModels)
        {
            if (outModels != null && outModels.Count > 0)
            {
                var preOutModel = outModels.First();
                preOutModel.SumPrice = preOutModel.TotalPrice;
                var i = 0;
                foreach (var outModel in outModels)
                {
                    i++;
                    outModel.CanMerge = true;
                    if (preOutModel.Id != outModel.Id)
                    {
                        if (preOutModel.Department == outModel.Department)
                        {
                            outModel.SumPrice = preOutModel.SumPrice + outModel.TotalPrice;
                            outModel.BoundHeight = preOutModel.BoundHeight + 15;
                            outModel.CanMerge = false;
                            preOutModel.CanMerge = false;
                            if (i == outModels.Count)
                            {
                                outModel.CanMerge = true;
                            }
                        }
                        else
                        {
                            outModel.SumPrice = outModel.TotalPrice;
                            outModel.CanMerge = true;
                            preOutModel.CanMerge = true;
                        }
                    }
                    preOutModel = outModel;
                }
            }
            return outModels;
        }
             

        private void grdOutStores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
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
      
        private void grdOutStores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            List<int> indexs = new List<int>() { 0, 6 };
            MergeCellInOneColumn(this.grdOutStores, indexs, e);
        }


        private void MergeCellInOneColumn(DataGridView dgv, List<int> columnIndexList, DataGridViewCellPaintingEventArgs e)
        {
            if (columnIndexList.Contains(e.ColumnIndex) && e.RowIndex != -1)
            {
                Brush gridBrush = new SolidBrush(dgv.GridColor);
                Brush backBrush = new SolidBrush(e.CellStyle.BackColor);
                Pen gridLinePen = new Pen(gridBrush);

                //擦除
                e.Graphics.FillRectangle(backBrush, e.CellBounds);

                //画右边线
                e.Graphics.DrawLine(gridLinePen,
                   e.CellBounds.Right - 1,
                   e.CellBounds.Top,
                   e.CellBounds.Right - 1,
                   e.CellBounds.Bottom - 1);

                var outModels = dgv.DataSource as List<OutStoreModel>;

                //画底边线
                if ((e.RowIndex < dgv.Rows.Count - 1 && outModels[e.RowIndex].CanMerge) ||
                    e.RowIndex == dgv.Rows.Count - 1)
                {
                    e.Graphics.DrawLine(gridLinePen,
                        e.CellBounds.Left,
                        e.CellBounds.Bottom - 1,
                        e.CellBounds.Right - 1,
                        e.CellBounds.Bottom - 1);
                }

                //写文本                
                if (e.RowIndex > -1 && outModels[e.RowIndex].CanMerge)
                {
                       e.Graphics.DrawString(e.Value.ToString(),
                                            e.CellStyle.Font, Brushes.Black,
                                            e.CellBounds.X + 4, e.CellBounds.Y + 8,
                                            StringFormat.GenericDefault);
                    
                }

                e.Handled = true;
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
                var tmepOut = dptsOut.ToList();
                tmepOut.Insert(0, new { code = "-111", name = "全部" });                
                this.cboZKPZDpts.DataSource = tmepOut;
                this.cboZKPZDpts.DisplayMember = "name";
                this.cboZKPZDpts.ValueMember = "code";
            }

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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var beginDate = Convert.ToDateTime(this.dtpBegin.Value.ToShortDateString() + " 00:00:00");
            var endDate = Convert.ToDateTime(this.dptEnd.Value.ToShortDateString() + " 23:59:59");
            var type = this.cboType.SelectedValue.ToString() != "-111" ? this.cboType.SelectedValue.ToString() : null;
            var code = this.cboChildType.SelectedValue.ToString() != "-111" ? this.cboChildType.SelectedValue.ToString() : null;
            var depratment = this.cboZKPZDpts.SelectedValue.ToString() != "-111" ? this.cboZKPZDpts.SelectedValue.ToString() : null;

            var outModels = _outStoreModel.QueryCount(beginDate, endDate, type, code, null, depratment);
            outModels = SetOutStoreType(outModels);
            outModels = SetItemMerge(outModels);
            SetOutModelColuName(outModels);
            this.grdOutStores.DataSource = outModels;
        }

        private void SetOutModelColuName(List<OutStoreModel> excelOutModels)
        {
            if (excelOutModels.Count > 0)
            {
                foreach (var outModel in excelOutModels)
                {
                    if (outModel.Type == MaterialModel.MatType.ZKPZ.ToString())
                    {
                        outModel.Type = "重空凭证";
                    }
                    if (outModel.Type == MaterialModel.MatType.NZKPZ.ToString())
                    {
                        outModel.Type = "非重空凭证";
                    }
                    if (outModel.Type == MaterialModel.MatType.DJB.ToString())
                    {
                        outModel.Type = "登记薄";
                    }
                    if (outModel.Type == MaterialModel.MatType.JJ.ToString())
                    {
                        outModel.Type = "机具";
                    }
                    if (outModel.Type == MaterialModel.MatType.OTHER.ToString())
                    {
                        outModel.Type = "其它";
                    }

                    outModel.Name = _materialDicts[outModel.Name];
                    
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
                saveFileDialog.FileName = "统计";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.Filter = "*xls files(*.xlsx)|*.xlsx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.RestoreDirectory = true;
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var fileName = saveFileDialog.FileName.ToString();
                    _outStoreModel.ExportToReportExcel(fileName, outStoreModels, this.dtpBegin.Value.ToShortDateString(), this.dptEnd.Value.ToShortDateString());
                    MessageBox.Show("导出统计数据成功！");
                }                
            }
            else
            {
                MessageBox.Show("没有统计数据！");
            }
            this.btnExport.Enabled = true;
        }                       
        
    }
}
