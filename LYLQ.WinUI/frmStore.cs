using LYLQ.WinUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LYLQ.WinUI
{
    public partial class frmStore : Form
    {
        private StockModel _stockModel = new StockModel();
        private UserModel _userModel = new UserModel();
        private MaterialModel _materielModel = new MaterialModel();
        private List<UserModel> userModels = new List<UserModel>();
        Dictionary<string, string> _materialDicts = new Dictionary<string, string>();

        public frmStore()
        {
            InitializeComponent();
        }

        private void frmStore_Load(object sender, EventArgs e)
        {
            _materialDicts = _stockModel.GetMaterialKeyValuePaire();            

            LoadMeterialType();
            LoadMeterialChildType();
            LoadGrd_Stores();
        }

        private void GenerateColumn(DataGridView grd)
        {
            DataGridViewTextBoxColumn txtTypeCol = new DataGridViewTextBoxColumn();
            txtTypeCol.DataPropertyName = "type";
            txtTypeCol.HeaderText = "类 型";
            //txtTypeCol.Width = 180;
            grd.Columns.Add(txtTypeCol);   


            DataGridViewTextBoxColumn txtStatusCol = new DataGridViewTextBoxColumn();
            txtStatusCol.DataPropertyName = "Name";
            txtStatusCol.HeaderText = "名　称";         
            //txtStatusCol.Width = 200;
            grd.Columns.Add(txtStatusCol);

            DataGridViewTextBoxColumn txtNumberCol = new DataGridViewTextBoxColumn();
            txtNumberCol.DataPropertyName = "Number";
            txtNumberCol.HeaderText = "数 量";
            txtNumberCol.Width = 100;
            grd.Columns.Add(txtNumberCol);

            DataGridViewTextBoxColumn txtUnitCol = new DataGridViewTextBoxColumn();
            txtUnitCol.DataPropertyName = "UnitPrice";
            txtUnitCol.HeaderText = "单 价";
            //txtUnitCol.Width = 100;
            grd.Columns.Add(txtUnitCol);

            DataGridViewTextBoxColumn txtTotalCol = new DataGridViewTextBoxColumn();
            txtTotalCol.DataPropertyName = "TotalPrice";
            txtTotalCol.HeaderText = "总 价";
            //txtTotalCol.Width = 100;
            grd.Columns.Add(txtTotalCol);

            grd.AutoGenerateColumns = false;
            grd.ReadOnly = true;           
            grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetGridStyle(DataGridView grd)
        {
            grd.ColumnHeadersHeight = 30;
            grd.RowTemplate.Height = 26;            
            grd.Height = 540;

            grd.AutoSize = true;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grd.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grd.ReadOnly = true;
            grd.RowHeadersVisible = false;
            grd.ScrollBars = ScrollBars.Vertical;        
        }

        private void LoadGrd_Stores()
        {
            GenerateColumn(this.grdStore);

            this.dtpBegin.Value = DateTime.Now;
            this.SetGridStyle(this.grdStore);
            this.grdStore.Width = 736;

            var beginDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 00:00:00");         
            var endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59:59");
            //var inStoreModels = _inStoreModel.Query(beginDate, endDate, null, null, null);
            var inStoreModels = _stockModel.Query(beginDate, endDate, null, null);            
            if (inStoreModels == null || inStoreModels.Count == 0)
            {
                inStoreModels = _stockModel.QueryPre(beginDate, endDate, null, null);
            }
            if (inStoreModels == null || inStoreModels.Count == 0)
            {
                inStoreModels = _stockModel.QueryNext(beginDate, endDate, null, null);
            }
            //var preday = -1;
            //while (inStoreModels == null || inStoreModels.Count == 0)
            //{
            //    beginDate = Convert.ToDateTime(DateTime.Now.AddDays(preday).ToShortDateString() + " 00:00:00");
            //    endDate = Convert.ToDateTime(DateTime.Now.AddDays(preday).AddDays(preday).ToShortDateString() + " 23:59:59");
            //    inStoreModels = _stockModel.Query(beginDate, endDate, null, null);
            //    preday--;
            //}
            inStoreModels = SetInStoreType(inStoreModels);
            inStoreModels = SetItemMerge(inStoreModels);
            this.grdStore.DataSource = inStoreModels;
            
            this.grdStore.ScrollBars = ScrollBars.Both;
        }       

        private void grdStore_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {                        
            List<int> indexs = new List<int>() { 0 };
            MergeCellInOneColumn(this.grdStore, indexs, e);
            
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

                var inModels = dgv.DataSource as List<StockModel>;

                //画底边线
                if ((e.RowIndex < dgv.Rows.Count - 1 && inModels[e.RowIndex].CanMerge) ||
                    e.RowIndex == dgv.Rows.Count - 1)
                {
                    e.Graphics.DrawLine(gridLinePen,
                        e.CellBounds.Left,
                        e.CellBounds.Bottom - 1,
                        e.CellBounds.Right - 1,
                        e.CellBounds.Bottom - 1);
                }

                //写文本

                if (e.RowIndex > -1 && inModels[e.RowIndex].CanMerge)
                {
                    //var y = e.CellBounds.Y + 9 - inModels[e.RowIndex].BoundHeight;
                    //var x = e.CellBounds.X + 20;
                    //if (e.ColumnIndex == 0)
                    //{
                    //    x = e.CellBounds.X + 6;
                    //}
                    //e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                    //    Brushes.Black, x,
                    //    y, StringFormat.GenericDefault);

                    e.Graphics.DrawString(e.Value.ToString(),
                                            e.CellStyle.Font, Brushes.Black,
                                            e.CellBounds.X + 4, e.CellBounds.Y + 8,
                                            StringFormat.GenericDefault);      
                }

                e.Handled = true;
            }
        }

        private void grdStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grd = sender as DataGridView;
            //if (grd.Columns[e.ColumnIndex].DataPropertyName == "Name" && e.Value != null)
            //{
            //    e.Value = _materialDicts[e.Value.ToString()];
            //}

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

            if (grd.Columns[e.ColumnIndex].DataPropertyName == "type" && e.Value != null)
            {
                if (e.Value.ToString() == MaterialModel.MatType.ZKPZ.ToString())
                {
                    e.Value = "重空凭证";
                }
                if (e.Value.ToString() == MaterialModel.MatType.NZKPZ.ToString())
                {
                    e.Value = "非重空凭证";
                }
                if (e.Value.ToString() == MaterialModel.MatType.DJB.ToString())
                {
                    e.Value = "登记薄";
                }
                if (e.Value.ToString() == MaterialModel.MatType.JJ.ToString())
                {
                    e.Value = "机具";
                }
                if (e.Value.ToString() == MaterialModel.MatType.OTHER.ToString())
                {
                    e.Value = "其它";
                }
            }

            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
            var endDate = Convert.ToDateTime(this.dtpBegin.Value.ToShortDateString() + " 23:59:59");
            var type = this.cboType.SelectedValue.ToString() != "-111" ? this.cboType.SelectedValue.ToString() : null;
            var code = this.cboChildType.SelectedValue.ToString() != "-111" ? this.cboChildType.SelectedValue.ToString() : null;
            var inStoreModels = _stockModel.Query(beginDate, endDate, type, code);
            //var preday = -1;
            //while (inStoreModels == null || inStoreModels.Count == 0)
            //{
            //    beginDate = Convert.ToDateTime(DateTime.Now.AddDays(preday).ToShortDateString() + " 00:00:00");
            //    endDate = Convert.ToDateTime(DateTime.Now.AddDays(preday).AddDays(preday).ToShortDateString() + " 23:59:59");
            //    inStoreModels = _stockModel.Query(beginDate, endDate, type, code);
            //    preday--;
            //}
            if (inStoreModels == null || inStoreModels.Count == 0)
            {
                inStoreModels = _stockModel.QueryPre(beginDate, endDate, null, null);
            }
            if (inStoreModels == null || inStoreModels.Count == 0)
            {
                inStoreModels = _stockModel.QueryNext(beginDate, endDate, null, null);
            }
            inStoreModels = SetInStoreType(inStoreModels);
            inStoreModels = SetItemMerge(inStoreModels);

            this.grdStore.DataSource = inStoreModels;
        }

        private List<StockModel> SetInStoreType(List<StockModel> inStoreModels)
        { 
            if (inStoreModels != null && inStoreModels.Count > 0)
            {
                inStoreModels = (from item in inStoreModels
                             orderby item.Type
                             select item).ToList();

                foreach (var inStoreModel in inStoreModels)
                {
                    if (inStoreModel.Type == MaterialModel.MatType.ZKPZ.ToString())
                    {
                        inStoreModel.Type = "重空凭证";
                    }
                    if (inStoreModel.Type == MaterialModel.MatType.NZKPZ.ToString())
                    {
                        inStoreModel.Type = "非重空凭证";
                    }
                    if (inStoreModel.Type == MaterialModel.MatType.DJB.ToString())
                    {
                        inStoreModel.Type = "登记薄";
                    }
                    if (inStoreModel.Type == MaterialModel.MatType.JJ.ToString())
                    {
                        inStoreModel.Type = "机具";
                    }
                    if (inStoreModel.Type == MaterialModel.MatType.OTHER.ToString())
                    {
                        inStoreModel.Type = "其它";
                    }

                    inStoreModel.Name = _materialDicts[inStoreModel.Name];
                }
             }
            return inStoreModels;
        }

        private List<StockModel> SetItemMerge(List<StockModel> outStoreModels)
        {
            if (outStoreModels != null && outStoreModels.Count > 0)
            {
                var preInModel = outStoreModels.First();
                var i = 0;
                foreach (var outStoreModel in outStoreModels)
                {
                    i++;
                    outStoreModel.CanMerge = true;
                    if (preInModel.Id != outStoreModel.Id)
                    {
                        if (preInModel.Type == outStoreModel.Type)
                        {
                            outStoreModel.CanMerge = false;
                            preInModel.CanMerge = false;
                            if (i == outStoreModels.Count)
                            {
                                outStoreModel.CanMerge = true;
                            }
                        }
                        else
                        {
                            outStoreModel.CanMerge = true;
                            preInModel.CanMerge = true;
                        }
                    }
                    preInModel = outStoreModel;
                }
            }
            return outStoreModels;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.btnExport.Enabled = false;
            var inStoreModels = this.grdStore.DataSource as List<StockModel>;
            if (inStoreModels != null && inStoreModels.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "库存";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.Filter = "*xls files(*.xlsx)|*.xlsx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.RestoreDirectory = true;
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var fileName = saveFileDialog.FileName.ToString();
                    _stockModel.ExportToExcel(fileName, inStoreModels, this.dtpBegin.Value.ToShortDateString());
                }
                MessageBox.Show("导出库存数据成功！");
            }
            else
            {
                MessageBox.Show("没有库存数据！");
            }
            this.btnExport.Enabled = true;
        }                 
    }
}
