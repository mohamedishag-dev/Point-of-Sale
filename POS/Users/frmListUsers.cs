using POS.Forms;
using POS_Business.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class frmListUsers : Form
    {
        private readonly UserService _userService = new UserService();
        private DataTable _dtAllUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            dgvUsers.RowTemplate.Height = 35;
            _dtAllUsers = _userService.GetAll();

            dgvUsers.DataSource = _dtAllUsers;
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();


            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "المعرف";
                dgvUsers.Columns[0].Width = 50;

                dgvUsers.Columns[1].HeaderText = "الاسم الكامل";
                dgvUsers.Columns[1].Width = 130;

                dgvUsers.Columns[2].HeaderText = "اسم المستخدم";
                dgvUsers.Columns[2].Width = 70;

                dgvUsers.Columns[3].HeaderText = "الهاتق";
                dgvUsers.Columns[3].Width = 80;

                dgvUsers.Columns[4].HeaderText = "الايميل";
                dgvUsers.Columns[4].Width = 100;

                dgvUsers.Columns[5].HeaderText = "العنوان";
                dgvUsers.Columns[5].Width = 80;

                dgvUsers.Columns[6].HeaderText = "الادوار";
                dgvUsers.Columns[6].Width = 50;

                dgvUsers.Columns[7].HeaderText = "مفعل";
                dgvUsers.Columns[7].Width = 50;

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "مفعل")
            {
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                txtFilterValue.Visible = false;
                return;
            }
            else
            {

                cbIsActive.Visible = false;
                txtFilterValue.Visible = (cbFilterBy.Text != "لا شي");
                txtFilterValue.Text = "";
                txtFilterValue.Focus();

                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

            }


        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "الكل":
                    break;

                case "المفعل":
                    FilterValue = "1";
                    break;

                case "الغير مفعل":
                    FilterValue = "0";
                    break;

                default:
                    break;
            }
            if (FilterValue == "الكل")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase user id is selected.
            if (cbFilterBy.Text == "المعرف")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "المعرف":
                    FilterColumn = "UserID";
                    break;

                case "الاسم الكامل":
                    FilterColumn = "FullName";
                    break;

                case "اسم المستخدم":
                    FilterColumn = "Username";
                    break;

                case "الهاتق":
                    FilterColumn = "Phone";
                    break;

                case "الايميل":
                    FilterColumn = "Email";
                    break;

                case "الادوار":
                    FilterColumn = "RoleName";
                    break;

                default:
                    FilterColumn = "لا شي";
                    break;

            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "لا شي")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "UserID" /*&& FilterColumn != "FullName"*/)
                //     in this case we deal with integer not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

        }
    }

}