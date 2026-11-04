using POS.Controls;
using POS_Business.DTOs.Users;
using POS_Business.Services;
using POS_DataAccess.interfaceis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_DataAccess.Models;
namespace POS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Color DefaultColor = Color.FromArgb(45, 212, 191);
        private Panel pnlActivate;
        private void ResetBackColor(Panel Pnl)
        {
  
       
            Pnl.BackColor = Color.FromArgb(37, 99, 235);
            Pnl.BackColor = Color.Transparent;
            pnlActivate = Pnl;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

     
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();
        
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnReturns_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}
