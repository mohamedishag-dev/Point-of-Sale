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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.checkbIsActive = new System.Windows.Forms.CheckBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.llRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llOpenFileDialog = new System.Windows.Forms.LinkLabel();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPassword.Location = new System.Drawing.Point(323, 182);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(175, 29);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtConfirmPassword.Location = new System.Drawing.Point(323, 220);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtConfirmPassword.Size = new System.Drawing.Size(175, 29);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtUserName.Location = new System.Drawing.Point(17, 44);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.Size = new System.Drawing.Size(175, 29);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTestBox);
            // 
            // checkbIsActive
            // 
            this.checkbIsActive.AutoSize = true;
            this.checkbIsActive.Checked = true;
            this.checkbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbIsActive.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.checkbIsActive.Location = new System.Drawing.Point(504, 260);
            this.checkbIsActive.Name = "checkbIsActive";
            this.checkbIsActive.Size = new System.Drawing.Size(59, 26);
            this.checkbIsActive.TabIndex = 8;
            this.checkbIsActive.Text = "مفعل";
            this.checkbIsActive.UseVisualStyleBackColor = true;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelUserName.Location = new System.Drawing.Point(198, 47);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelUserName.Size = new System.Drawing.Size(100, 22);
            this.labelUserName.TabIndex = 174;
            this.labelUserName.Text = "اسم المستخدم:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelPassword.Location = new System.Drawing.Point(504, 185);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelPassword.Size = new System.Drawing.Size(88, 22);
            this.labelPassword.TabIndex = 173;
            this.labelPassword.Text = "كلمة المرور:";
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelConfirmPassword.Location = new System.Drawing.Point(504, 223);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelConfirmPassword.Size = new System.Drawing.Size(121, 22);
            this.labelConfirmPassword.TabIndex = 172;
            this.labelConfirmPassword.Text = "تاكيد كلمة المرور:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblUserID.Location = new System.Drawing.Point(458, 14);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserID.Size = new System.Drawing.Size(40, 22);
            this.lblUserID.TabIndex = 171;
            this.lblUserID.Text = "???";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelUserID.Location = new System.Drawing.Point(504, 14);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelUserID.Size = new System.Drawing.Size(60, 22);
            this.labelUserID.TabIndex = 170;
            this.labelUserID.Text = "المعرف:";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(669, 47);
            this.lblTitle.TabIndex = 175;
            this.lblTitle.Text = "اضافة مستخدم جديد";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.labelConfirmPassword);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelPassword);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.checkbIsActive);
            this.panel1.Controls.Add(this.llRemoveImage);
            this.panel1.Controls.Add(this.txtConfirmPassword);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.llOpenFileDialog);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.pbPersonImage);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.lblUserID);
            this.panel1.Controls.Add(this.labelUserID);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.labelUserName);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(12, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 387);
            this.panel1.TabIndex = 176;
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtFullName.Location = new System.Drawing.Point(323, 44);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFullName.Size = new System.Drawing.Size(175, 29);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTestBox);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(504, 47);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(88, 22);
            this.label6.TabIndex = 191;
            this.label6.Text = "الاسم الكامل:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(198, 117);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(56, 22);
            this.label4.TabIndex = 188;
            this.label4.Text = "الادوار:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = new System.Drawing.Point(17, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(175, 29);
            this.textBox2.TabIndex = 5;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.txtAddress.Location = new System.Drawing.Point(323, 114);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(175, 62);
            this.txtAddress.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(504, 117);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 181;
            this.label2.Text = "العنوان:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(504, 82);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(55, 22);
            this.label3.TabIndex = 182;
            this.label3.Text = "الايميل:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(198, 82);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 180;
            this.label1.Text = "رقم الهاتف:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtEmail.Location = new System.Drawing.Point(323, 79);
            this.txtEmail.MaxLength = 20;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEmail.Size = new System.Drawing.Size(175, 29);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPhone.Location = new System.Drawing.Point(17, 79);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.Size = new System.Drawing.Size(175, 29);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTestBox);
            // 
            // llRemoveImage
            // 
            this.llRemoveImage.AutoSize = true;
            this.llRemoveImage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.llRemoveImage.Location = new System.Drawing.Point(73, 349);
            this.llRemoveImage.Name = "llRemoveImage";
            this.llRemoveImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.llRemoveImage.Size = new System.Drawing.Size(46, 22);
            this.llRemoveImage.TabIndex = 10;
            this.llRemoveImage.TabStop = true;
            this.llRemoveImage.Text = "حذف ";
            this.llRemoveImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveImage_LinkClicked);
            // 
            // llOpenFileDialog
            // 
            this.llOpenFileDialog.AutoSize = true;
            this.llOpenFileDialog.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.llOpenFileDialog.Location = new System.Drawing.Point(57, 327);
            this.llOpenFileDialog.Name = "llOpenFileDialog";
            this.llOpenFileDialog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.llOpenFileDialog.Size = new System.Drawing.Size(87, 22);
            this.llOpenFileDialog.TabIndex = 9;
            this.llOpenFileDialog.TabStop = true;
            this.llOpenFileDialog.Text = "وضع صورة";
            this.llOpenFileDialog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpenFileDialog_LinkClicked);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonImage.Image = global::POS.Properties.Resources.Male_512;
            this.pbPersonImage.Location = new System.Drawing.Point(17, 149);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(175, 175);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 185;
            this.pbPersonImage.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(381, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 43);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "الغاء";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(504, 317);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 43);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(669, 454);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.CheckBox checkbIsActive;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llRemoveImage;
        private System.Windows.Forms.LinkLabel llOpenFileDialog;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}