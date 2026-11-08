using System.Drawing;
using System.Windows.Forms;

namespace POS.Controls
{
    partial class ctrlProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.ColProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColMinus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Coldel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.btnSale = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.AllowDrop = true;
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AllowUserToResizeColumns = false;
            this.dgvCart.AllowUserToResizeRows = false;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.ColumnHeadersHeight = 40;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProductName,
            this.ColQuantity,
            this.ColPrice,
            this.ColCost,
            this.ColPlus,
            this.ColMinus,
            this.Coldel});
            this.dgvCart.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvCart.Location = new System.Drawing.Point(3, 23);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Transparent;
            this.dgvCart.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCart.Size = new System.Drawing.Size(426, 350);
            this.dgvCart.TabIndex = 0;
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellContentClick);
            // 
            // ColProductName
            // 
            this.ColProductName.FillWeight = 64.38892F;
            this.ColProductName.HeaderText = "المنتج";
            this.ColProductName.Name = "ColProductName";
            this.ColProductName.ReadOnly = true;
            this.ColProductName.Width = 150;
            // 
            // ColQuantity
            // 
            this.ColQuantity.FillWeight = 51.51112F;
            this.ColQuantity.HeaderText = "الكمية";
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.ReadOnly = true;
            this.ColQuantity.Width = 50;
            // 
            // ColPrice
            // 
            this.ColPrice.FillWeight = 60F;
            this.ColPrice.HeaderText = "السعر ($)";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 80;
            // 
            // ColCost
            // 
            this.ColCost.FillWeight = 60F;
            this.ColCost.HeaderText = "تكلفة الوحدة";
            this.ColCost.Name = "ColCost";
            this.ColCost.ReadOnly = true;
            this.ColCost.Width = 50;
            // 
            // ColPlus
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ColPlus.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColPlus.FillWeight = 30F;
            this.ColPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColPlus.HeaderText = "";
            this.ColPlus.Name = "ColPlus";
            this.ColPlus.ReadOnly = true;
            this.ColPlus.Text = "+";
            this.ColPlus.UseColumnTextForButtonValue = true;
            this.ColPlus.Width = 30;
            // 
            // ColMinus
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ColMinus.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColMinus.FillWeight = 30F;
            this.ColMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColMinus.HeaderText = "";
            this.ColMinus.Name = "ColMinus";
            this.ColMinus.ReadOnly = true;
            this.ColMinus.Text = "-";
            this.ColMinus.UseColumnTextForButtonValue = true;
            this.ColMinus.Width = 30;
            // 
            // Coldel
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            this.Coldel.DefaultCellStyle = dataGridViewCellStyle4;
            this.Coldel.FillWeight = 30F;
            this.Coldel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Coldel.HeaderText = "";
            this.Coldel.Name = "Coldel";
            this.Coldel.ReadOnly = true;
            this.Coldel.Text = "حذف";
            this.Coldel.UseColumnTextForButtonValue = true;
            this.Coldel.Width = 30;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 30);
            // 
            // deletToolStripMenuItem
            // 
            this.deletToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.deletToolStripMenuItem.Name = "deletToolStripMenuItem";
            this.deletToolStripMenuItem.Size = new System.Drawing.Size(113, 26);
            this.deletToolStripMenuItem.Text = "حذف";
            this.deletToolStripMenuItem.Click += new System.EventHandler(this.deletToolStripMenuItem_Click);
            // 
            // panelProducts
            // 
            this.panelProducts.BackColor = System.Drawing.Color.White;
            this.panelProducts.Controls.Add(this.dataGridView1);
            this.panelProducts.Location = new System.Drawing.Point(460, 12);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(559, 577);
            this.panelProducts.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewButtonColumn1,
            this.dataGridViewButtonColumn2,
            this.dataGridViewButtonColumn3});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dataGridView1.Location = new System.Drawing.Point(20, 307);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(495, 193);
            this.dataGridView1.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 150F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "المنتج";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "الكمية";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "كتلفة الوحدة";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "السعر ($)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn1.Text = "+";
            this.dataGridViewButtonColumn1.Width = 20;
            // 
            // dataGridViewButtonColumn2
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridViewButtonColumn2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn2.Text = "-";
            this.dataGridViewButtonColumn2.Width = 20;
            // 
            // dataGridViewButtonColumn3
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Red;
            this.dataGridViewButtonColumn3.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewButtonColumn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn3.HeaderText = "";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.ReadOnly = true;
            this.dataGridViewButtonColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn3.Text = "حذف";
            this.dataGridViewButtonColumn3.Width = 30;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubtotal.Location = new System.Drawing.Point(14, 419);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSubtotal.Size = new System.Drawing.Size(133, 17);
            this.lblSubtotal.TabIndex = 2;
            this.lblSubtotal.Text = "المجموع الفرعي: $0.00";
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSale.ForeColor = System.Drawing.Color.White;
            this.btnSale.Location = new System.Drawing.Point(14, 519);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(370, 45);
            this.btnSale.TabIndex = 3;
            this.btnSale.Text = "إتمام الدفع (Charge)";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTax);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.dgvCart);
            this.panel2.Controls.Add(this.btnSale);
            this.panel2.Controls.Add(this.lblSubtotal);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 577);
            this.panel2.TabIndex = 4;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(14, 449);
            this.lblTax.Name = "lblTax";
            this.lblTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTax.Size = new System.Drawing.Size(116, 17);
            this.lblTax.TabIndex = 5;
            this.lblTax.Text = "الضريبة (8%): $0.00";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(14, 479);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(150, 21);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "الإجمالي الكلي: $0.00";
            // 
            // ctrlProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelProducts);
            this.Name = "ctrlProduct";
            this.Size = new System.Drawing.Size(1033, 603);
            this.Load += new System.EventHandler(this.ctrlProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Button btnSale;
        private Panel panel2;
        private Label lblTax;
        private Label lblTotal;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deletToolStripMenuItem;
        private DataGridViewTextBoxColumn ColProductName;
        private DataGridViewTextBoxColumn ColQuantity;
        private DataGridViewTextBoxColumn ColPrice;
        private DataGridViewTextBoxColumn ColCost;
        private DataGridViewButtonColumn ColPlus;
        private DataGridViewButtonColumn ColMinus;
        private DataGridViewButtonColumn Coldel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewButtonColumn dataGridViewButtonColumn2;
        private DataGridViewButtonColumn dataGridViewButtonColumn3;
    }
}
