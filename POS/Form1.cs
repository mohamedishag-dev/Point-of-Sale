using POS.Controls;
using POS_Business.DTOs.Users;
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

namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pictureBox1.Load(selectedFilePath);
                // ...
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = _userRepository.GetAll();

         
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



        private void button2_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.ShowDialog();
        }
    }
}
