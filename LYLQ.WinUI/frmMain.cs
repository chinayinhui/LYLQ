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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mmu_user_Click(object sender, EventArgs e)
        {            
            foreach(var childForm in this.MdiChildren)
            {
                
                childForm.Close();
            }

            var frmUser = new frmUser();
            frmUser.MdiParent = this;
            frmUser.WindowState = FormWindowState.Maximized;
            frmUser.Dock = DockStyle.Fill;
            frmUser.Show();          
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mmu_department_Click(object sender, EventArgs e)
        {            
            foreach (var childForm in this.MdiChildren)
            {                
                childForm.Close();
            }

            var frmDepartment = new frmDepartment();
            frmDepartment.MdiParent = this;
            frmDepartment.WindowState = FormWindowState.Maximized;
            frmDepartment.Dock = DockStyle.Fill;
            frmDepartment.Show();            
        }

        private void mmu_System_Click(object sender, EventArgs e)
        {            
            foreach (var childForm in this.MdiChildren)
            {                
                childForm.Close();
            }

            var frmMateriel = new frmMateriel();
            frmMateriel.MdiParent = this;
            frmMateriel.WindowState = FormWindowState.Maximized;
            frmMateriel.Dock = DockStyle.Fill;
            frmMateriel.Show();            
        }

        private void mmu_inStore_Click(object sender, EventArgs e)
        {
            foreach (var childForm in this.MdiChildren)
            {
                childForm.Close();
            }

            var frmInstore= new frmInStore();
            frmInstore.MdiParent = this;
            frmInstore.WindowState = FormWindowState.Maximized;
            frmInstore.Dock = DockStyle.Fill;
            frmInstore.AutoScroll = true;
            frmInstore.Show(); 
        }

        private void mmu_outStore_Click(object sender, EventArgs e)
        {
            foreach (var childForm in this.MdiChildren)
            {
                childForm.Close();
            }

            var frmOutstore = new frmOutStore();
            frmOutstore.MdiParent = this;
            frmOutstore.WindowState = FormWindowState.Maximized;
            frmOutstore.Dock = DockStyle.Fill;
            frmOutstore.AutoScroll = true;
            frmOutstore.Show(); 
        }

        private void mmu_about_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void mmu_sum_Click(object sender, EventArgs e)
        {
            foreach (var childForm in this.MdiChildren)
            {
                childForm.Close();
            }

            var frmReport = new frmReport();
            frmReport.MdiParent = this;
            frmReport.WindowState = FormWindowState.Maximized;
            frmReport.Dock = DockStyle.Fill;
            frmReport.AutoScroll = true;
            frmReport.Show(); 
        }

        private void mmu_store_Click(object sender, EventArgs e)
        {
            foreach (var childForm in this.MdiChildren)
            {
                childForm.Close();
            }

            var frmStore = new frmStore();
            frmStore.MdiParent = this;
            frmStore.WindowState = FormWindowState.Maximized;
            frmStore.Dock = DockStyle.Fill;
            frmStore.AutoScroll = true;
            frmStore.Show(); 
        }

    }
}
