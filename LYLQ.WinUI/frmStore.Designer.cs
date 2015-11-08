namespace LYLQ.WinUI
{
    partial class frmStore
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
            this.grdStore = new System.Windows.Forms.DataGridView();
            this.sptStore = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cboChildType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grdStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptStore)).BeginInit();
            this.sptStore.Panel1.SuspendLayout();
            this.sptStore.Panel2.SuspendLayout();
            this.sptStore.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdStore
            // 
            this.grdStore.ColumnHeadersHeight = 32;
            this.grdStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStore.Location = new System.Drawing.Point(0, 0);
            this.grdStore.Name = "grdStore";
            this.grdStore.RowHeadersVisible = false;
            this.grdStore.RowTemplate.Height = 30;
            this.grdStore.Size = new System.Drawing.Size(1077, 685);
            this.grdStore.TabIndex = 2;
            this.grdStore.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdStore_CellFormatting);
            this.grdStore.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdStore_CellPainting);
            // 
            // sptStore
            // 
            this.sptStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptStore.Location = new System.Drawing.Point(0, 2);
            this.sptStore.Name = "sptStore";
            // 
            // sptStore.Panel1
            // 
            this.sptStore.Panel1.Controls.Add(this.groupBox1);
            // 
            // sptStore.Panel2
            // 
            this.sptStore.Panel2.Controls.Add(this.grdStore);
            this.sptStore.Size = new System.Drawing.Size(1370, 685);
            this.sptStore.SplitterDistance = 289;
            this.sptStore.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.cboChildType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Location = new System.Drawing.Point(18, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 279);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "过 滤";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(141, 208);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 28);
            this.btnExport.TabIndex = 51;
            this.btnExport.Text = "导 出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(26, 208);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 28);
            this.btnQuery.TabIndex = 50;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboChildType
            // 
            this.cboChildType.FormattingEnabled = true;
            this.cboChildType.Location = new System.Drawing.Point(72, 139);
            this.cboChildType.Name = "cboChildType";
            this.cboChildType.Size = new System.Drawing.Size(144, 20);
            this.cboChildType.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 48;
            this.label4.Text = "类型";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(72, 102);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(144, 20);
            this.cboType.TabIndex = 47;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 53;
            this.label1.Text = "日 期";
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd";
            this.dtpBegin.Location = new System.Drawing.Point(72, 43);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(144, 21);
            this.dtpBegin.TabIndex = 52;
            // 
            // frmStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 687);
            this.Controls.Add(this.sptStore);
            this.Name = "frmStore";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "库 存";
            this.Load += new System.EventHandler(this.frmStore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStore)).EndInit();
            this.sptStore.Panel1.ResumeLayout(false);
            this.sptStore.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptStore)).EndInit();
            this.sptStore.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdStore;
        private System.Windows.Forms.SplitContainer sptStore;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ComboBox cboChildType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBegin;
    }
}