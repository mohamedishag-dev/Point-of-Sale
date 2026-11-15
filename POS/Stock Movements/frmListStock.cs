using POS_Business.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.Stock_Movements
{
    public partial class frmListStock : Form
    {
        private readonly IStockMovementService _movementService;
        private DataTable _dtAllMovements;

        public frmListStock(IStockMovementService movementService)
        {
            InitializeComponent();
            _movementService = movementService;
        }

        private void frmListStock_Load(object sender, EventArgs e)
        {
            dgvMovements.RowTemplate.Height = 35;
            _dtAllMovements = _movementService.GetAllMovements();
            dgvMovements.DataSource = _dtAllMovements;

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
            lblRecordsCount.Text = "اجمالي الحركات\n" + "" + dgvMovements.Rows.Count.ToString();


            if (dgvMovements.Rows.Count > 0)
            {
                dgvMovements.Columns[0].HeaderText = "رقم الحركة";
                dgvMovements.Columns[0].Width = 60;

                dgvMovements.Columns[1].HeaderText = "رقم الدفعة";
                dgvMovements.Columns[1].Width = 80;

                dgvMovements.Columns[2].HeaderText = "المستخدم";
                dgvMovements.Columns[2].Width = 70;

                dgvMovements.Columns[3].HeaderText = "الكمية";
                dgvMovements.Columns[3].Width = 50;

                dgvMovements.Columns[4].HeaderText = "نوع الحركة";
                dgvMovements.Columns[4].Width = 50;

                dgvMovements.Columns[5].HeaderText = "رقم الشراء";
                dgvMovements.Columns[5].Width = 60;

                dgvMovements.Columns[6].HeaderText = "رقم البيع";
                dgvMovements.Columns[6].Width = 60;

                dgvMovements.Columns[7].HeaderText = "رقم المرتجع";
                dgvMovements.Columns[7].Width = 60;

                dgvMovements.Columns[8].HeaderText = "رقم التالف";
                dgvMovements.Columns[8].Width = 60;

                dgvMovements.Columns[9].HeaderText = "المبلغ الاجمالي";
                dgvMovements.Columns[9].Width = 100;


                dgvMovements.Columns[10].HeaderText = "الملاحظات";
                dgvMovements.Columns[10].Width = 100;

                dgvMovements.Columns[11].HeaderText = "تاريخ الانشاء";
                dgvMovements.Columns[11].Width = 130;

            }

        }
    }
}
