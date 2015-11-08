namespace LYLQ.WinUI
{
    partial class frmDepartment
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
            this.sptDepartment = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtDptName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDptCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rboIn = new System.Windows.Forms.RadioButton();
            this.rboOut = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdDpt = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.sptDepartment)).BeginInit();
            this.sptDepartment.Panel1.SuspendLayout();
            this.sptDepartment.Panel2.SuspendLayout();
            this.sptDepartment.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDpt)).BeginInit();
            this.SuspendLayout();
            // 
            // sptDepartment
            // 
            this.sptDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptDepartment.Location = new System.Drawing.Point(0, 0);
            this.sptDepartment.Name = "sptDepartment";
            // 
            // sptDepartment.Panel1
            // 
            this.sptDepartment.Panel1.Controls.Add(this.groupBox1);
            // 
            // sptDepartment.Panel2
            // 
            this.sptDepartment.Panel2.Controls.Add(this.groupBox2);
            this.sptDepartment.Size = new System.Drawing.Size(1520, 786);
            this.sptDepartment.SplitterDistance = 340;
            this.sptDepartment.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtDptName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDptCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.groupBox1.Size = new System.Drawing.Size(340, 786);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = " 类 型：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(181, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "添 加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(67, 276);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清 空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDptName
            // 
            this.txtDptName.Location = new System.Drawing.Point(67, 116);
            this.txtDptName.Name = "txtDptName";
            this.txtDptName.Size = new System.Drawing.Size(232, 20);
            this.txtDptName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "名 称：";
            // 
            // txtDptCode
            // 
            this.txtDptCode.Location = new System.Drawing.Point(67, 48);
            this.txtDptCode.Name = "txtDptCode";
            this.txtDptCode.Size = new System.Drawing.Size(135, 20);
            this.txtDptCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "编 码：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rboIn);
            this.groupBox3.Controls.Add(this.rboOut);
            this.groupBox3.Location = new System.Drawing.Point(67, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 42);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // rboIn
            // 
            this.rboIn.AutoSize = true;
            this.rboIn.Location = new System.Drawing.Point(131, 14);
            this.rboIn.Name = "rboIn";
            this.rboIn.Size = new System.Drawing.Size(49, 17);
            this.rboIn.TabIndex = 11;
            this.rboIn.Text = "入库";
            this.rboIn.UseVisualStyleBackColor = true;
            // 
            // rboOut
            // 
            this.rboOut.AutoSize = true;
            this.rboOut.Checked = true;
            this.rboOut.Location = new System.Drawing.Point(6, 14);
            this.rboOut.Name = "rboOut";
            this.rboOut.Size = new System.Drawing.Size(49, 17);
            this.rboOut.TabIndex = 12;
            this.rboOut.TabStop = true;
            this.rboOut.Text = "出库";
            this.rboOut.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdDpt);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1176, 786);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // grdDpt
            // 
            this.grdDpt.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdDpt.ColumnHeadersHeight = 34;
            this.grdDpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDpt.Location = new System.Drawing.Point(3, 16);
            this.grdDpt.Margin = new System.Windows.Forms.Padding(0);
            this.grdDpt.Name = "grdDpt";
            this.grdDpt.RowHeadersVisible = false;
            this.grdDpt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDpt.Size = new System.Drawing.Size(1170, 767);
            this.grdDpt.TabIndex = 1;
            this.grdDpt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDpt_CellClick);
            this.grdDpt.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdDpt_CellFormatting);
            // 
            // frmDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 786);
            this.Controls.Add(this.sptDepartment);
            this.Name = "frmDepartment";
            this.Text = "网 点";
            this.Load += new System.EventHandler(this.frmDepartment_Load);
            this.sptDepartment.Panel1.ResumeLayout(false);
            this.sptDepartment.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptDepartment)).EndInit();
            this.sptDepartment.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDpt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptDepartment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtDptName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDptCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rboIn;
        private System.Windows.Forms.RadioButton rboOut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdDpt;

    }
}