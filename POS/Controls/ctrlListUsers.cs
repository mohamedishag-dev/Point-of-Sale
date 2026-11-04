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

namespace POS.Controls
{
    public partial class ctrlListUsers : UserControl
    {
        //public ctrlListUsers()
        //{
        //    InitializeComponent();
        //}

        private readonly IUserRepository _userRepository;
        public ctrlListUsers(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
        }

        private void ctrlListUsers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _userRepository.GetAll();


            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = clsTheme.Card;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = clsTheme.Background;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = clsTheme.TextMuted;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DefaultCellStyle.SelectionBackColor = clsTheme.SuccessBg;
            dataGridView1.DefaultCellStyle.SelectionForeColor = clsTheme.Text;
            dataGridView1.GridColor = clsTheme.Border;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RightToLeft = RightToLeft.Yes;
        }
    }
}
