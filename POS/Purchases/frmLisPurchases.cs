using POS_Business.Interfaces;
using POS_Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace POS.Purchases
{
    public partial class frmLisPurchases : Form
    {
        private readonly IPurchaseService _purchaseService;
        private DataTable _dtAllPurchases;

        public frmLisPurchases(IPurchaseService purchaseService)
        {
            InitializeComponent();
            _purchaseService = purchaseService;
        }

        private void frmLisPurchases_Load(object sender, EventArgs e)
        {
         
            _dtAllPurchases = _purchaseService.GetAllPurchases();
            dgvPurchases.DataSource = _dtAllPurchases;
            dgvPurchases.RowTemplate.Height = 35;
      
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
            lblRecordsCount.Text = dgvPurchases.Rows.Count.ToString();


            if (dgvPurchases.Rows.Count > 0)
            {
                dgvPurchases.Columns[0].HeaderText = "رقم الفاتورة";
                dgvPurchases.Columns[0].Width = 60;

                dgvPurchases.Columns[1].HeaderText = "الاسم المورد";
                dgvPurchases.Columns[1].Width = 150;
   
                dgvPurchases.Columns[2].HeaderText = "اسم المستخدم";
                dgvPurchases.Columns[2].Width = 70;

                dgvPurchases.Columns[3].HeaderText = "تاريخ العملية";
                dgvPurchases.Columns[3].Width = 80;
      
                dgvPurchases.Columns[4].HeaderText = "المبلغ المدفوع";
                dgvPurchases.Columns[4].Width = 100;

                dgvPurchases.Columns[5].HeaderText = "إجمالي الفاتورة";
                dgvPurchases.Columns[5].Width = 100;
         
                dgvPurchases.Columns[6].HeaderText = "المبلغ المتبقي";
                dgvPurchases.Columns[6].Width = 100;

            }

            dtpFrom.Value = DateTime.Now.AddDays(-7);
            dtpTo.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiltterFordate_ValueChanged(object sender, EventArgs e)
        {

            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1);

            string from = fromDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            string to = toDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            _dtAllPurchases.DefaultView.RowFilter =
                "[PurchaseDate] >= #" + from + "# AND [PurchaseDate] < #" + to + "#";


        }


    }
}
