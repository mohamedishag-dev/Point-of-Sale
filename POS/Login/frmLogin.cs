using POS.Global_classes;
using POS_Business.DTOs.Users;
using POS_Business.Interfaces;
using POS_Business.LogBAL;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace POS.Login
{
    public partial class frmLogin : Form
    {


        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private const int EM_SETCUEBANNER = 0x1501;

        private readonly IAuthService _authService;

        public frmLogin(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            SendMessage(txtUsername.Handle, EM_SETCUEBANNER, 1, "أدخل اسم المستخدم");
            SendMessage(txtPassword.Handle, EM_SETCUEBANNER, 1, "أدخل كلمة المرور");

            string username = "", password = "";

            if (Global.GetStoredCredential(ref username, ref password))
            {
                chkRemember.Checked = true;
                txtUsername.Text = username;
                txtPassword.Text = password;
            }
            else
                chkRemember.Checked = false;

        }

        private void DragWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username.Length == 0 || password.Length == 0)
            {
                ShowError("الرجاء إدخال اسم المستخدم وكلمة المرور");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "جاري التحقق...";
            Cursor = Cursors.WaitCursor;

            SetBusy(true);

            try
            {
                AuthResult result = _authService.Login(username, password).Result;
                if (result.Status == LoginStatus.Inactive)
                {
                    ShowError("هذا الحساب موقوف");
                    SetBusy(false);
                    return;
                }

                if (!result.Success)
                {
                    ShowError("اسم المستخدم أو كلمة المرور غير صحيحة");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    SetBusy(false);
                    return;
                }


                if (chkRemember.Checked)
                    //store username and password
                    Global.SaveRememberedUser(username, password);
                else
                    //store empty username and password
                    Global.SaveRememberedUser("", "");

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                Logger.Error("Login failed", ex);
                ShowError("تعذر الاتصال بقاعدة البيانات");
                SetBusy(false);
                return;
            }

        }

        private void SetBusy(bool busy)
        {
            this.btnLogin.Enabled = !busy;
            this.btnLogin.Text = busy ? "جاري التحقق..." : "تسجيل دخول";
            this.Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void picEye_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            picEye.Image = txtPassword.UseSystemPasswordChar ? Properties.Resources.Eye_show : Properties.Resources.eye_hide;
            txtPassword.Focus();
        }


    }
}
