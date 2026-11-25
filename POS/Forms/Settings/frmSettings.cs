using POS_Business.Security.Settings;
using POS_Business.Interfaces;
using System;
using System.Windows.Forms;

namespace POS.Settings
{
    public partial class frmSettings : Form
    {
        private readonly ISettingsService _settingsService;
        public frmSettings(ISettingsService settingsService)
        {
            InitializeComponent();
            _settingsService = settingsService;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Msg("اسم المتجر مطلوب.", MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCurrency.Text))
            {
                Msg("رمز العملة مطلوب.", MessageBoxIcon.Warning);
                txtCurrency.Focus();
                return;
            }

            var settings = new SettingsDto
            {
                StoreName = txtName.Text.Trim(),
                StorePhone = txtPhone.Text.Trim(),
                StoreAddress = txtAddress.Text.Trim(),
                CurrencySymbol = txtCurrency.Text.Trim(),
                TaxRate = nudTax.Value,
                LowStockThreshold = nudLowStock.Value,
                ReceiptFooter = txtFooter.Text.Trim()
            };


            if (_settingsService.Update(settings))
            {
                Msg("تم حفظ الإعدادات.", MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                Msg("لم يتم الحفظ. تأكد إن صف الإعدادات موجود في الجدول.", MessageBoxIcon.Warning);
            }

        }

        private void Msg(string text, MessageBoxIcon icon)
        {
            MessageBox.Show(this, text, "الإعدادات", MessageBoxButtons.OK, icon,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
        }

        private static void SetNum(NumericUpDown nud, decimal value)
        {
            nud.Value = Math.Max(nud.Minimum, Math.Min(nud.Maximum, value));
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            var settings = _settingsService.Get();
            if (settings == null)
            {
                Msg("لم يتم العثور على الإعدادات. شغّل سكريبت إنشاء جدول Settings أولاً.", MessageBoxIcon.Warning);
                Close();
                return;
            }

            txtName.Text = settings.StoreName;
            txtPhone.Text = settings.StorePhone ?? "";
            txtAddress.Text = settings.StoreAddress ?? "";
            txtCurrency.Text = settings.CurrencySymbol;
            txtFooter.Text = settings.ReceiptFooter ?? "";
            SetNum(nudTax, settings.TaxRate);
            SetNum(nudLowStock, settings.LowStockThreshold);
        }
    }

}
