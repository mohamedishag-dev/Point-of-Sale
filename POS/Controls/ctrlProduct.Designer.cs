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
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.btnSale = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.ColumnHeadersHeight = 30;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProductName,
            this.ColQuantity,
            this.ColPrice,
            this.ColCost,
            this.ColPlus,
            this.ColMinus,
            this.Coldel});
            this.dgvCart.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCart.Location = new System.Drawing.Point(3, 23);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            this.ColPrice.FillWeight = 51.51112F;
            this.ColPrice.HeaderText = "السعر ($)";
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 80;
            // 
            // ColCost
            // 
            this.ColCost.FillWeight = 50F;
            this.ColCost.HeaderText = "تكلفة الوحدة";
            this.ColCost.Name = "ColCost";
            this.ColCost.ReadOnly = true;
            this.ColCost.Width = 50;
            // 
            // ColPlus
            // 
            this.ColPlus.FillWeight = 20F;
            this.ColPlus.HeaderText = "";
            this.ColPlus.Name = "ColPlus";
            this.ColPlus.ReadOnly = true;
            this.ColPlus.Text = "+";
            this.ColPlus.UseColumnTextForButtonValue = true;
            this.ColPlus.Width = 20;
            // 
            // ColMinus
            // 
            this.ColMinus.FillWeight = 20F;
            this.ColMinus.HeaderText = "";
            this.ColMinus.Name = "ColMinus";
            this.ColMinus.ReadOnly = true;
            this.ColMinus.Text = "-";
            this.ColMinus.UseColumnTextForButtonValue = true;
            this.ColMinus.Width = 20;
            // 
            // Coldel
            // 
            this.Coldel.FillWeight = 20F;
            this.Coldel.HeaderText = "";
            this.Coldel.Name = "Coldel";
            this.Coldel.ReadOnly = true;
            this.Coldel.Text = "x";
            this.Coldel.UseColumnTextForButtonValue = true;
            this.Coldel.Width = 20;
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
            this.panelProducts.Location = new System.Drawing.Point(460, 12);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(559, 577);
            this.panelProducts.TabIndex = 1;
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
    }
}
