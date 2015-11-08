namespace LYLQ.WinUI
{
    partial class frmMateriel
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
            this.sptMaterial = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtMatName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatCode = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rboJB_Other = new System.Windows.Forms.RadioButton();
            this.rboJB_DJB = new System.Windows.Forms.RadioButton();
            this.rboJB_JJ = new System.Windows.Forms.RadioButton();
            this.rboJB_ZKPZ = new System.Windows.Forms.RadioButton();
            this.rboJB_NZKPZ = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sptMaterialList = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rboAll = new System.Windows.Forms.RadioButton();
            this.rboOther = new System.Windows.Forms.RadioButton();
            this.rboJJ = new System.Windows.Forms.RadioButton();
            this.rboDJB = new System.Windows.Forms.RadioButton();
            this.rboNZKPZ = new System.Windows.Forms.RadioButton();
            this.rboZKPZ = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.grdMat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sptMaterial)).BeginInit();
            this.sptMaterial.Panel1.SuspendLayout();
            this.sptMaterial.Panel2.SuspendLayout();
            this.sptMaterial.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptMaterialList)).BeginInit();
            this.sptMaterialList.Panel1.SuspendLayout();
            this.sptMaterialList.Panel2.SuspendLayout();
            this.sptMaterialList.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMat)).BeginInit();
            this.SuspendLayout();
            // 
            // sptMaterial
            // 
            this.sptMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMaterial.Location = new System.Drawing.Point(0, 2);
            this.sptMaterial.Name = "sptMaterial";
            // 
            // sptMaterial.Panel1
            // 
            this.sptMaterial.Panel1.Controls.Add(this.groupBox1);
            // 
            // sptMaterial.Panel2
            // 
            this.sptMaterial.Panel2.Controls.Add(this.groupBox2);
            this.sptMaterial.Size = new System.Drawing.Size(1370, 690);
            this.sptMaterial.SplitterDistance = 320;
            this.sptMaterial.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtMatName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMatCode);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 690);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(87, 418);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(181, 28);
            this.btnClearAll.TabIndex = 17;
            this.btnClearAll.Text = "清空（入库，出库）";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = " 类 型：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(195, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "添 加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(90, 311);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清 空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtMatName
            // 
            this.txtMatName.Location = new System.Drawing.Point(87, 46);
            this.txtMatName.Name = "txtMatName";
            this.txtMatName.Size = new System.Drawing.Size(145, 20);
            this.txtMatName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "名 称：";
            // 
            // txtMatCode
            // 
            this.txtMatCode.Location = new System.Drawing.Point(87, 83);
            this.txtMatCode.Name = "txtMatCode";
            this.txtMatCode.Size = new System.Drawing.Size(145, 20);
            this.txtMatCode.TabIndex = 1;
            this.txtMatCode.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rboJB_Other);
            this.groupBox3.Controls.Add(this.rboJB_DJB);
            this.groupBox3.Controls.Add(this.rboJB_JJ);
            this.groupBox3.Controls.Add(this.rboJB_ZKPZ);
            this.groupBox3.Controls.Add(this.rboJB_NZKPZ);
            this.groupBox3.Location = new System.Drawing.Point(87, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 138);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // rboJB_Other
            // 
            this.rboJB_Other.AutoSize = true;
            this.rboJB_Other.Location = new System.Drawing.Point(6, 96);
            this.rboJB_Other.Name = "rboJB_Other";
            this.rboJB_Other.Size = new System.Drawing.Size(49, 17);
            this.rboJB_Other.TabIndex = 14;
            this.rboJB_Other.Text = "其它";
            this.rboJB_Other.UseVisualStyleBackColor = true;
            // 
            // rboJB_DJB
            // 
            this.rboJB_DJB.AutoSize = true;
            this.rboJB_DJB.Location = new System.Drawing.Point(6, 57);
            this.rboJB_DJB.Name = "rboJB_DJB";
            this.rboJB_DJB.Size = new System.Drawing.Size(61, 17);
            this.rboJB_DJB.TabIndex = 15;
            this.rboJB_DJB.Text = "登记薄";
            this.rboJB_DJB.UseVisualStyleBackColor = true;
            // 
            // rboJB_JJ
            // 
            this.rboJB_JJ.AutoSize = true;
            this.rboJB_JJ.Location = new System.Drawing.Point(96, 57);
            this.rboJB_JJ.Name = "rboJB_JJ";
            this.rboJB_JJ.Size = new System.Drawing.Size(49, 17);
            this.rboJB_JJ.TabIndex = 13;
            this.rboJB_JJ.Text = "机具";
            this.rboJB_JJ.UseVisualStyleBackColor = true;
            // 
            // rboJB_ZKPZ
            // 
            this.rboJB_ZKPZ.AutoSize = true;
            this.rboJB_ZKPZ.Checked = true;
            this.rboJB_ZKPZ.Location = new System.Drawing.Point(6, 18);
            this.rboJB_ZKPZ.Name = "rboJB_ZKPZ";
            this.rboJB_ZKPZ.Size = new System.Drawing.Size(73, 17);
            this.rboJB_ZKPZ.TabIndex = 11;
            this.rboJB_ZKPZ.TabStop = true;
            this.rboJB_ZKPZ.Text = "重空凭证";
            this.rboJB_ZKPZ.UseVisualStyleBackColor = true;
            // 
            // rboJB_NZKPZ
            // 
            this.rboJB_NZKPZ.AutoSize = true;
            this.rboJB_NZKPZ.Location = new System.Drawing.Point(96, 18);
            this.rboJB_NZKPZ.Name = "rboJB_NZKPZ";
            this.rboJB_NZKPZ.Size = new System.Drawing.Size(85, 17);
            this.rboJB_NZKPZ.TabIndex = 12;
            this.rboJB_NZKPZ.Text = "非重空凭证";
            this.rboJB_NZKPZ.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sptMaterialList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1046, 690);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "物品列表";
            // 
            // sptMaterialList
            // 
            this.sptMaterialList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptMaterialList.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptMaterialList.Location = new System.Drawing.Point(3, 17);
            this.sptMaterialList.Name = "sptMaterialList";
            this.sptMaterialList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sptMaterialList.Panel1
            // 
            this.sptMaterialList.Panel1.Controls.Add(this.panel1);
            // 
            // sptMaterialList.Panel2
            // 
            this.sptMaterialList.Panel2.Controls.Add(this.grdMat);
            this.sptMaterialList.Size = new System.Drawing.Size(1040, 670);
            this.sptMaterialList.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rboAll);
            this.panel1.Controls.Add(this.rboOther);
            this.panel1.Controls.Add(this.rboJJ);
            this.panel1.Controls.Add(this.rboDJB);
            this.panel1.Controls.Add(this.rboNZKPZ);
            this.panel1.Controls.Add(this.rboZKPZ);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(-31, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 50);
            this.panel1.TabIndex = 26;
            // 
            // rboAll
            // 
            this.rboAll.AutoSize = true;
            this.rboAll.Checked = true;
            this.rboAll.Location = new System.Drawing.Point(616, 14);
            this.rboAll.Name = "rboAll";
            this.rboAll.Size = new System.Drawing.Size(47, 16);
            this.rboAll.TabIndex = 32;
            this.rboAll.TabStop = true;
            this.rboAll.Text = "全部";
            this.rboAll.UseVisualStyleBackColor = true;
            this.rboAll.CheckedChanged += new System.EventHandler(this.rboAll_CheckedChanged);
            // 
            // rboOther
            // 
            this.rboOther.AutoSize = true;
            this.rboOther.Location = new System.Drawing.Point(1020, 14);
            this.rboOther.Name = "rboOther";
            this.rboOther.Size = new System.Drawing.Size(47, 16);
            this.rboOther.TabIndex = 29;
            this.rboOther.Text = "其它";
            this.rboOther.UseVisualStyleBackColor = true;
            this.rboOther.CheckedChanged += new System.EventHandler(this.rboOther_CheckedChanged);
            // 
            // rboJJ
            // 
            this.rboJJ.AutoSize = true;
            this.rboJJ.Location = new System.Drawing.Point(956, 14);
            this.rboJJ.Name = "rboJJ";
            this.rboJJ.Size = new System.Drawing.Size(47, 16);
            this.rboJJ.TabIndex = 30;
            this.rboJJ.Text = "机具";
            this.rboJJ.UseVisualStyleBackColor = true;
            this.rboJJ.CheckedChanged += new System.EventHandler(this.rboJJ_CheckedChanged);
            // 
            // rboDJB
            // 
            this.rboDJB.AutoSize = true;
            this.rboDJB.Location = new System.Drawing.Point(881, 14);
            this.rboDJB.Name = "rboDJB";
            this.rboDJB.Size = new System.Drawing.Size(59, 16);
            this.rboDJB.TabIndex = 31;
            this.rboDJB.Text = "登记薄";
            this.rboDJB.UseVisualStyleBackColor = true;
            this.rboDJB.CheckedChanged += new System.EventHandler(this.rboDJB_CheckedChanged);
            // 
            // rboNZKPZ
            // 
            this.rboNZKPZ.AutoSize = true;
            this.rboNZKPZ.Location = new System.Drawing.Point(787, 14);
            this.rboNZKPZ.Name = "rboNZKPZ";
            this.rboNZKPZ.Size = new System.Drawing.Size(83, 16);
            this.rboNZKPZ.TabIndex = 28;
            this.rboNZKPZ.Text = "非重空凭证";
            this.rboNZKPZ.UseVisualStyleBackColor = true;
            this.rboNZKPZ.CheckedChanged += new System.EventHandler(this.rboNZKPZ_CheckedChanged);
            // 
            // rboZKPZ
            // 
            this.rboZKPZ.AutoSize = true;
            this.rboZKPZ.Location = new System.Drawing.Point(690, 14);
            this.rboZKPZ.Name = "rboZKPZ";
            this.rboZKPZ.Size = new System.Drawing.Size(71, 16);
            this.rboZKPZ.TabIndex = 27;
            this.rboZKPZ.Text = "重空凭证";
            this.rboZKPZ.UseVisualStyleBackColor = true;
            this.rboZKPZ.CheckedChanged += new System.EventHandler(this.rboZKPZ_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "过滤：";
            // 
            // grdMat
            // 
            this.grdMat.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdMat.ColumnHeadersHeight = 34;
            this.grdMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMat.Location = new System.Drawing.Point(0, 0);
            this.grdMat.Name = "grdMat";
            this.grdMat.RowHeadersVisible = false;
            this.grdMat.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMat.Size = new System.Drawing.Size(1040, 616);
            this.grdMat.TabIndex = 1;
            this.grdMat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMat_CellClick);
            this.grdMat.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdMat_CellFormatting);
            // 
            // frmMateriel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 692);
            this.Controls.Add(this.sptMaterial);
            this.Name = "frmMateriel";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "物品维护";
            this.Load += new System.EventHandler(this.frmMateriel_Load);
            this.sptMaterial.Panel1.ResumeLayout(false);
            this.sptMaterial.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMaterial)).EndInit();
            this.sptMaterial.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.sptMaterialList.Panel1.ResumeLayout(false);
            this.sptMaterialList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptMaterialList)).EndInit();
            this.sptMaterialList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptMaterial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtMatName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rboJB_Other;
        private System.Windows.Forms.RadioButton rboJB_DJB;
        private System.Windows.Forms.RadioButton rboJB_JJ;
        private System.Windows.Forms.RadioButton rboJB_ZKPZ;
        private System.Windows.Forms.RadioButton rboJB_NZKPZ;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer sptMaterialList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rboAll;
        private System.Windows.Forms.RadioButton rboOther;
        private System.Windows.Forms.RadioButton rboJJ;
        private System.Windows.Forms.RadioButton rboDJB;
        private System.Windows.Forms.RadioButton rboNZKPZ;
        private System.Windows.Forms.RadioButton rboZKPZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdMat;
        private System.Windows.Forms.Button btnClearAll;

    }
}