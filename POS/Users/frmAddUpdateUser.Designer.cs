namespace POS.Forms
{
    partial class frmAddUpdateUser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.checkbIsActive = new System.Windows.Forms.CheckBox();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.llOpenFileDialog = new System.Windows.Forms.LinkLabel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.circlepbUserImage = new CirclePictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlepbUserImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(336, 47);
            this.lblTitle.TabIndex = 175;
            this.lblTitle.Text = "اضافة مستخدم جديد";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnClose.Location = new System.Drawing.Point(96, 472);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 43);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "الغاء";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(111)))), ((int)(((byte)(237)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(219, 472);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 43);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtFullName.Location = new System.Drawing.Point(27, 86);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFullName.Size = new System.Drawing.Size(309, 29);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTestBox);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(253, 61);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(83, 22);
            this.label6.TabIndex = 215;
            this.label6.Text = "الاسم الكامل";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPassword.Location = new System.Drawing.Point(181, 426);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(155, 29);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelConfirmPassword.Location = new System.Drawing.Point(57, 401);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelConfirmPassword.Size = new System.Drawing.Size(121, 22);
            this.labelConfirmPassword.TabIndex = 207;
            this.labelConfirmPassword.Text = "تاكيد كلمة المرور:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(294, 243);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(42, 22);
            this.label4.TabIndex = 214;
            this.label4.Text = "الدور";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelPassword.Location = new System.Drawing.Point(248, 401);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelPassword.Size = new System.Drawing.Size(88, 22);
            this.labelPassword.TabIndex = 208;
            this.labelPassword.Text = "كلمة المرور:";
            // 
            // checkbIsActive
            // 
            this.checkbIsActive.AutoSize = true;
            this.checkbIsActive.Checked = true;
            this.checkbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbIsActive.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.checkbIsActive.Location = new System.Drawing.Point(119, 269);
            this.checkbIsActive.Name = "checkbIsActive";
            this.checkbIsActive.Size = new System.Drawing.Size(59, 26);
            this.checkbIsActive.TabIndex = 5;
            this.checkbIsActive.Text = "مفعل";
            this.checkbIsActive.UseVisualStyleBackColor = true;
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.AutoSize = true;
            this.llRemoveImage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.llRemoveImage.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.llRemoveImage.Location = new System.Drawing.Point(64, 233);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.llRemoveImage.Size = new System.Drawing.Size(46, 22);
            this.llRemoveImage.TabIndex = 12;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "حذف ";
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtConfirmPassword.Location = new System.Drawing.Point(23, 426);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtConfirmPassword.Size = new System.Drawing.Size(155, 29);
            this.txtConfirmPassword.TabIndex = 8;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.txtAddress.Location = new System.Drawing.Point(21, 326);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(315, 62);
            this.txtAddress.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(278, 303);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 211;
            this.label2.Text = "العنوان:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(226, 184);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(110, 22);
            this.label3.TabIndex = 212;
            this.label3.Text = "البريد الالكتروني";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(102, 120);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 210;
            this.label1.Text = "رقم الهاتف";
            // 
            // llOpenFileDialog
            // 
            this.llOpenFileDialog.AutoSize = true;
            this.llOpenFileDialog.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.llOpenFileDialog.Location = new System.Drawing.Point(116, 233);
            this.llOpenFileDialog.Name = "llOpenFileDialog";
            this.llOpenFileDialog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.llOpenFileDialog.Size = new System.Drawing.Size(87, 22);
            this.llOpenFileDialog.TabIndex = 11;
            this.llOpenFileDialog.TabStop = true;
            this.llOpenFileDialog.Text = "وضع صورة";
            this.llOpenFileDialog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpenFileDialog_LinkClicked);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtEmail.Location = new System.Drawing.Point(22, 206);
            this.txtEmail.MaxLength = 20;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEmail.Size = new System.Drawing.Size(314, 29);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPhone.Location = new System.Drawing.Point(23, 145);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.Size = new System.Drawing.Size(155, 29);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTestBox);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtUserName.Location = new System.Drawing.Point(181, 145);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.Size = new System.Drawing.Size(155, 29);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTestBox);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelUserName.Location = new System.Drawing.Point(241, 120);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelUserName.Size = new System.Drawing.Size(95, 22);
            this.labelUserName.TabIndex = 209;
            this.labelUserName.Text = "اسم المستخدم";
            // 
            // cmbRole
            // 
            this.cmbRole.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(181, 267);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(155, 30);
            this.cmbRole.TabIndex = 4;
            // 
            // circlepbUserImage
            // 
            this.circlepbUserImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.circlepbUserImage.Image = global::POS.Properties.Resources.ic_fluent_person_24_filled;
            this.circlepbUserImage.Location = new System.Drawing.Point(52, 60);
            this.circlepbUserImage.Name = "circlepbUserImage";
            this.circlepbUserImage.Size = new System.Drawing.Size(170, 170);
            this.circlepbUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.circlepbUserImage.TabIndex = 216;
            this.circlepbUserImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.circlepbUserImage);
            this.panel1.Controls.Add(this.llOpenFileDialog);
            this.panel1.Controls.Add(this.llRemoveImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(342, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 542);
            this.panel1.TabIndex = 11;
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(623, 542);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.checkbIsActive);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circlepbUserImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.CheckBox checkbIsActive;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llOpenFileDialog;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label labelUserName;
        private CirclePictureBox circlepbUserImage;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Panel panel1;
    }
}