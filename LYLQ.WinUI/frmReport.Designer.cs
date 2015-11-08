namespace LYLQ.WinUI
{
    partial class frmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sptReport = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cboChildType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboZKPZDpts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dptEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.grdOutStores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sptReport)).BeginInit();
            this.sptReport.Panel1.SuspendLayout();
            this.sptReport.Panel2.SuspendLayout();
            this.sptReport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutStores)).BeginInit();
            this.SuspendLayout();
            // 
            // sptReport
            // 
            this.sptReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptReport.Location = new System.Drawing.Point(0, 2);
            this.sptReport.Name = "sptReport";
            // 
            // sptReport.Panel1
            // 
            this.sptReport.Panel1.Controls.Add(this.groupBox1);
            // 
            // sptReport.Panel2
            // 
            this.sptReport.Panel2.Controls.Add(this.grdOutStores);
            this.sptReport.Panel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.sptReport.Size = new System.Drawing.Size(1370, 676);
            this.sptReport.SplitterDistance = 280;
            this.sptReport.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cboChildType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboZKPZDpts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dptEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 676);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过 滤";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(141, 318);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 30);
            this.btnExport.TabIndex = 51;
            this.btnExport.Text = "导 出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(26, 318);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 30);
            this.btnQuery.TabIndex = 50;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboChildType
            // 
            this.cboChildType.FormattingEnabled = true;
            this.cboChildType.Location = new System.Drawing.Point(72, 224);
            this.cboChildType.Name = "cboChildType";
            this.cboChildType.Size = new System.Drawing.Size(144, 21);
            this.cboChildType.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 48;
            this.label4.Text = "类型";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(72, 184);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(144, 21);
            this.cboType.TabIndex = 47;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 46;
            this.label3.Text = "网 点";
            // 
            // cboZKPZDpts
            // 
            this.cboZKPZDpts.FormattingEnabled = true;
            this.cboZKPZDpts.Location = new System.Drawing.Point(72, 137);
            this.cboZKPZDpts.Name = "cboZKPZDpts";
            this.cboZKPZDpts.Size = new System.Drawing.Size(144, 21);
            this.cboZKPZDpts.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 44;
            this.label2.Text = "结 束";
            // 
            // dptEnd
            // 
            this.dptEnd.CustomFormat = "yyyy-MM-dd";
            this.dptEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dptEnd.Location = new System.Drawing.Point(72, 82);
            this.dptEnd.Name = "dptEnd";
            this.dptEnd.Size = new System.Drawing.Size(144, 21);
            this.dptEnd.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 42;
            this.label1.Text = "开 始";
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd";
            this.dtpBegin.Location = new System.Drawing.Point(72, 42);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(144, 20);
            this.dtpBegin.TabIndex = 41;
            // 
            // grdOutStores
            // 
            this.grdOutStores.ColumnHeadersHeight = 32;
            this.grdOutStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdOutStores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOutStores.Location = new System.Drawing.Point(0, 6);
            this.grdOutStores.Name = "grdOutStores";
            this.grdOutStores.RowHeadersVisible = false;
            this.grdOutStores.RowTemplate.Height = 30;
            this.grdOutStores.Size = new System.Drawing.Size(1086, 670);
            this.grdOutStores.TabIndex = 1;
            this.grdOutStores.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdOutStores_CellFormatting);
            this.grdOutStores.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdOutStores_CellPainting);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 678);
            this.Controls.Add(this.sptReport);
            this.Name = "frmReport";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "统 计";
            this.Load += new System.EventHandler(this.frmStoreOut_Load);
            this.sptReport.Panel1.ResumeLayout(false);
            this.sptReport.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptReport)).EndInit();
            this.sptReport.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutStores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cboChildType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboZKPZDpts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dptEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.DataGridView grdOutStores;

    }
}