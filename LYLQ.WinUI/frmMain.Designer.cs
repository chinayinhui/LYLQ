namespace LYLQ.WinUI
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mmu_inStore = new System.Windows.Forms.ToolStripMenuItem();
            this.mmu_outStore = new System.Windows.Forms.ToolStripMenuItem();
            this.mmu_store = new System.Windows.Forms.ToolStripMenuItem();
            this.mmu_sum = new System.Windows.Forms.ToolStripMenuItem();
            this.mmu_System = new System.Windows.Forms.ToolStripMenuItem();
            this.mmu_department = new System.Windows.Forms.ToolStripMenuItem();
            this.mmu_user = new System.Windows.Forms.ToolStripMenuItem();
            this.mmu_about = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmu_inStore,
            this.mmu_outStore,
            this.mmu_store,
            this.mmu_sum,
            this.mmu_System,
            this.mmu_department,
            this.mmu_user,
            this.mmu_about});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mmu_inStore
            // 
            this.mmu_inStore.Name = "mmu_inStore";
            this.mmu_inStore.Size = new System.Drawing.Size(44, 21);
            this.mmu_inStore.Text = "入库";
            this.mmu_inStore.Click += new System.EventHandler(this.mmu_inStore_Click);
            // 
            // mmu_outStore
            // 
            this.mmu_outStore.Name = "mmu_outStore";
            this.mmu_outStore.Size = new System.Drawing.Size(44, 21);
            this.mmu_outStore.Text = "出库";
            this.mmu_outStore.Click += new System.EventHandler(this.mmu_outStore_Click);
            // 
            // mmu_store
            // 
            this.mmu_store.Name = "mmu_store";
            this.mmu_store.Size = new System.Drawing.Size(44, 21);
            this.mmu_store.Text = "库存";
            this.mmu_store.Click += new System.EventHandler(this.mmu_store_Click);
            // 
            // mmu_sum
            // 
            this.mmu_sum.Name = "mmu_sum";
            this.mmu_sum.Size = new System.Drawing.Size(44, 21);
            this.mmu_sum.Text = "统计";
            this.mmu_sum.Click += new System.EventHandler(this.mmu_sum_Click);
            // 
            // mmu_System
            // 
            this.mmu_System.Name = "mmu_System";
            this.mmu_System.Size = new System.Drawing.Size(68, 21);
            this.mmu_System.Text = "物品维护";
            this.mmu_System.Click += new System.EventHandler(this.mmu_System_Click);
            // 
            // mmu_department
            // 
            this.mmu_department.Name = "mmu_department";
            this.mmu_department.Size = new System.Drawing.Size(44, 21);
            this.mmu_department.Text = "网点";
            this.mmu_department.Click += new System.EventHandler(this.mmu_department_Click);
            // 
            // mmu_user
            // 
            this.mmu_user.Name = "mmu_user";
            this.mmu_user.Size = new System.Drawing.Size(56, 21);
            this.mmu_user.Text = "操作员";
            this.mmu_user.Click += new System.EventHandler(this.mmu_user_Click);
            // 
            // mmu_about
            // 
            this.mmu_about.Name = "mmu_about";
            this.mmu_about.Size = new System.Drawing.Size(44, 21);
            this.mmu_about.Text = "退出";
            this.mmu_about.Click += new System.EventHandler(this.mmu_about_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 546);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mmu_inStore;
        private System.Windows.Forms.ToolStripMenuItem mmu_outStore;
        private System.Windows.Forms.ToolStripMenuItem mmu_System;
        private System.Windows.Forms.ToolStripMenuItem mmu_user;
        private System.Windows.Forms.ToolStripMenuItem mmu_department;
        private System.Windows.Forms.ToolStripMenuItem mmu_about;
        private System.Windows.Forms.ToolStripMenuItem mmu_store;
        private System.Windows.Forms.ToolStripMenuItem mmu_sum;
    }
}