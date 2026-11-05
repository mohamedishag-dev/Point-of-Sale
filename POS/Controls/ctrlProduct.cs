using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS.Controls
{
    public partial class ctrlProduct : UserControl
    {
        private decimal subtotal = 0.00m;
        private const decimal taxRate = 0.08m; // نسبة الضريبة 8%

        string ImagesPath = @"D:\Images";
        public ctrlProduct()
        {
            InitializeComponent();

        }
        private void SetupCustomUI()
        {
            // إعداد نافذة التطبيق
            this.Text = "نظام نقاط البيع - POS System";
            this.Size = new Size(1100, 700);
            this.BackColor = Color.FromArgb(240, 243, 246);



            Label lblProdTitle = new Label()
            {
                Text = "شبكة المنتجات (Product Grid)",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            panelProducts.Controls.Add(lblProdTitle);

            // إضافة منتجات تجريبية كأزرار

            AddProductButton(panelProducts, "لاتيه (Latte)", 4.50m, 15, 60, Image.FromFile(Path.Combine(ImagesPath, "vit-ch-Oxb84ENcFfU-unsplash.jpg")));
            AddProductButton(panelProducts, "كرواسون (Croissant)", 4.50m, 140, 60, Image.FromFile(Path.Combine(ImagesPath, "vit-ch-Oxb84ENcFfU-unsplash.jpg")));
            AddProductButton(panelProducts, "كرواسون (Croissant)", 4.50m, 265, 60, Image.FromFile(Path.Combine(ImagesPath, "vit-ch-Oxb84ENcFfU-unsplash.jpg")));
            AddProductButton(panelProducts, "كرواسون (Croissant)", 4.50m, 390, 60, Image.FromFile(Path.Combine(ImagesPath, "vit-ch-Oxb84ENcFfU-unsplash.jpg")));

            AddProductButton(panelProducts, "سلطة سيزر", 9.50m, 15, 190, Image.FromFile(Path.Combine(ImagesPath, "vit-ch-Oxb84ENcFfU-unsplash.jpg")));
            AddProductButton(panelProducts, "سلطة سيزر", 9.50m, 140, 190, Image.FromFile(Path.Combine(ImagesPath, "vit-ch-Oxb84ENcFfU-unsplash.jpg")));
            AddProductButton(panelProducts, "سلطة سيزر", 9.50m, 265, 190, Image.FromFile(Path.Combine(ImagesPath, "vit-ch-Oxb84ENcFfU-unsplash.jpg")));
            AddProductButton(panelProducts, "عصير برتقال", 4.00m, 390, 190, LoadImage(ImagesPath + ""));



        }

        private void AddProductButton(Control parent, string name, decimal price, int left, int top, Image image)
        {
            Panel card = new Panel()
            {
                Location = new Point(left, top),
                Size = new Size(115, 130)
            };

            if (image != null) { }

            PictureBox pic = new PictureBox()
            {

                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Top,
                Height = 80,
                Cursor = Cursors.Hand
            };

            Button btn = new Button()
            {
                Text = $"{name}\n${price:F2}",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btn.FlatAppearance.BorderSize = 0;

            pic.Click += (s, e) => AddToCart(name, price);
            btn.Click += (s, e) => AddToCart(name, price);

            card.Controls.Add(btn);   // Fill الأول
            card.Controls.Add(pic);   // بعدين Top
            parent.Controls.Add(card);
        }

        private void AddToCart(string productName, decimal price)
        {
            // التحقق مما إذا كان المنتج موجوداً مسبقاً في السلة لزيادة الكمية
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (row.Cells["ColProductName"].Value.ToString() == productName)
                {
                    int qty = Convert.ToInt32(row.Cells["ColQuantity"].Value) + 1;
                    row.Cells["ColQuantity"].Value = qty;
                    CalculateTotals();
                    return;
                }
            }

            // إذا لم يكن موجوداً، أضفه كصف جديد
            dgvCart.Rows.Add(productName, 1, price.ToString("F2"));
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            subtotal = 0.00m;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                int qty = Convert.ToInt32(row.Cells["colQuantity"].Value);
                decimal price = Convert.ToDecimal(row.Cells["ColCost"].Value);
                subtotal += (qty * price);
            }

            decimal tax = subtotal * taxRate;
            decimal total = subtotal + tax;

            lblSubtotal.Text = $"المجموع الفرعي: ${subtotal:F2}";
            lblTax.Text = $"الضريبة (8%): ${tax:F2}";
            lblTotal.Text = $"الإجمالي الكلي: ${total:F2}";
        }

        private void ctrlProduct_Load(object sender, EventArgs e)
        {
            SetupCustomUI();

        }

        private Image LoadImage(string fileName)
        {
            string path = Path.Combine(ImagesPath, fileName);

            if (!File.Exists(path))
                return null; // أو صورة افتراضية

            using (var original = Image.FromFile(path))
            {
                return new Bitmap(original, new Size(150, 100));
            }
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("السلة فارغة!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("تم إتمام عملية الدفع بنجاح! شكراً لك.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvCart.Rows.Clear();
            CalculateTotals();

        }

        private void deletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;

            dgvCart.Rows.Remove(dgvCart.CurrentRow);
            CalculateTotals();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCart.Rows[e.RowIndex];
            decimal qty = Convert.ToDecimal(row.Cells["ColQuantity"].Value);
            decimal unitPrice = Convert.ToDecimal(row.Cells["ColCost"].Value);

            switch (dgvCart.Columns[e.ColumnIndex].Name)
            {
                case "ColPlus": qty++; break;
                case "ColMinus": qty--; break;
                case "Coldel":
                   if( MessageBox.Show("Are you delete is product", "", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question)== DialogResult.Yes)
                    qty = 0; break;
                default: return;
            }

            if (qty <= 0)
                dgvCart.Rows.RemoveAt(e.RowIndex);
            else
            {
                row.Cells["ColQuantity"].Value = qty;
                row.Cells["ColPrice"].Value = qty * unitPrice;
            }

            CalculateTotals();
        }

    }
}
