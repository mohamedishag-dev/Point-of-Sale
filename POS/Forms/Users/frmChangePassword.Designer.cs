namespace POS.Users
{
    partial class frmChangePassword
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtCrruentPassword = new System.Windows.Forms.TextBox();
            this.gbPresonInformation = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labellblPresonID = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.gbPresonInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(8, 350);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 65);
            this.panel1.TabIndex = 222;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 15.75F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.btnClose.Location = new System.Drawing.Point(281, 12);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 43);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "الغاء";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(101)))), ((int)(((byte)(52)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(425, 12);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 43);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "حفظ";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(434, 228);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(132, 22);
            this.label1.TabIndex = 221;
            this.label1.Text = "كلمة المرور الحالية:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtNewPassword.Location = new System.Drawing.Point(200, 263);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewPassword.Size = new System.Drawing.Size(226, 29);
            this.txtNewPassword.TabIndex = 217;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPassword_Validating);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtConfirmPassword.Location = new System.Drawing.Point(200, 298);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtConfirmPassword.Size = new System.Drawing.Size(226, 29);
            this.txtConfirmPassword.TabIndex = 218;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelConfirmPassword.Location = new System.Drawing.Point(434, 301);
            this.labelConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelConfirmPassword.Size = new System.Drawing.Size(121, 22);
            this.labelConfirmPassword.TabIndex = 219;
            this.labelConfirmPassword.Text = "تاكيد كلمة المرور:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelPassword.Location = new System.Drawing.Point(434, 266);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelPassword.Size = new System.Drawing.Size(137, 22);
            this.labelPassword.TabIndex = 220;
            this.labelPassword.Text = "كلمة المرور الجديدة:";
            // 
            // txtCrruentPassword
            // 
            this.txtCrruentPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtCrruentPassword.Location = new System.Drawing.Point(200, 228);
            this.txtCrruentPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCrruentPassword.MaxLength = 32;
            this.txtCrruentPassword.Name = "txtCrruentPassword";
            this.txtCrruentPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCrruentPassword.Size = new System.Drawing.Size(226, 29);
            this.txtCrruentPassword.TabIndex = 216;
            this.txtCrruentPassword.UseSystemPasswordChar = true;
            this.txtCrruentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtCrruentPassword_Validating);
            // 
            // gbPresonInformation
            // 
            this.gbPresonInformation.Controls.Add(this.label4);
            this.gbPresonInformation.Controls.Add(this.label6);
            this.gbPresonInformation.Controls.Add(this.labelUserName);
            this.gbPresonInformation.Controls.Add(this.label2);
            this.gbPresonInformation.Controls.Add(this.label3);
            this.gbPresonInformation.Controls.Add(this.label5);
            this.gbPresonInformation.Controls.Add(this.labellblPresonID);
            this.gbPresonInformation.Controls.Add(this.lblUsername);
            this.gbPresonInformation.Controls.Add(this.lblEmail);
            this.gbPresonInformation.Controls.Add(this.lblPhone);
            this.gbPresonInformation.Controls.Add(this.lblRoleName);
            this.gbPresonInformation.Controls.Add(this.lblAddress);
            this.gbPresonInformation.Controls.Add(this.lblFullName);
            this.gbPresonInformation.Controls.Add(this.lblUserID);
            this.gbPresonInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbPresonInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPresonInformation.Location = new System.Drawing.Point(8, 12);
            this.gbPresonInformation.Name = "gbPresonInformation";
            this.gbPresonInformation.Size = new System.Drawing.Size(569, 187);
            this.gbPresonInformation.TabIndex = 223;
            this.gbPresonInformation.TabStop = false;
            this.gbPresonInformation.Text = "Preson Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(130, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(42, 22);
            this.label4.TabIndex = 220;
            this.label4.Text = "الدور";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(449, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(83, 22);
            this.label6.TabIndex = 221;
            this.label6.Text = "الاسم الكامل";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelUserName.Location = new System.Drawing.Point(130, 58);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelUserName.Size = new System.Drawing.Size(95, 22);
            this.labelUserName.TabIndex = 216;
            this.labelUserName.Text = "اسم المستخدم";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(130, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 217;
            this.label2.Text = "رقم الهاتف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(449, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(110, 22);
            this.label3.TabIndex = 219;
            this.label3.Text = "البريد الالكتروني";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(449, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(58, 22);
            this.label5.TabIndex = 218;
            this.label5.Text = "العنوان:";
            // 
            // labellblPresonID
            // 
            this.labellblPresonID.AutoSize = true;
            this.labellblPresonID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.labellblPresonID.Location = new System.Drawing.Point(449, 28);
            this.labellblPresonID.Name = "labellblPresonID";
            this.labellblPresonID.Size = new System.Drawing.Size(93, 22);
            this.labellblPresonID.TabIndex = 70;
            this.labellblPresonID.Text = "رقم المستخدم";
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(6, 58);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUsername.Size = new System.Drawing.Size(117, 22);
            this.lblUsername.TabIndex = 72;
            this.lblUsername.Text = "[????]";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(232, 94);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEmail.Size = new System.Drawing.Size(210, 22);
            this.lblEmail.TabIndex = 73;
            this.lblEmail.Text = "[????]";
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Location = new System.Drawing.Point(6, 96);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPhone.Size = new System.Drawing.Size(117, 22);
            this.lblPhone.TabIndex = 78;
            this.lblPhone.Text = "[????]";
            // 
            // lblRoleName
            // 
            this.lblRoleName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblRoleName.Location = new System.Drawing.Point(6, 26);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRoleName.Size = new System.Drawing.Size(117, 22);
            this.lblRoleName.TabIndex = 74;
            this.lblRoleName.Text = "[????]";
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress.Location = new System.Drawing.Point(232, 132);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAddress.Size = new System.Drawing.Size(210, 22);
            this.lblAddress.TabIndex = 75;
            this.lblAddress.Text = "[????]";
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblFullName.ForeColor = System.Drawing.Color.Red;
            this.lblFullName.Location = new System.Drawing.Point(232, 58);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFullName.Size = new System.Drawing.Size(210, 22);
            this.lblFullName.TabIndex = 80;
            this.lblFullName.Text = "[????]";
            // 
            // lblUserID
            // 
            this.lblUserID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblUserID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserID.Location = new System.Drawing.Point(232, 24);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserID.Size = new System.Drawing.Size(210, 22);
            this.lblUserID.TabIndex = 79;
            this.lblUserID.Text = "N/A";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 427);
            this.Controls.Add(this.gbPresonInformation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.txtCrruentPassword);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحديث كلمة المرور";
            this.Load += new System.EventHandler(this.frmChangePassword2_Load);
            this.panel1.ResumeLayout(false);
            this.gbPresonInformation.ResumeLayout(false);
            this.gbPresonInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtCrruentPassword;
        private System.Windows.Forms.GroupBox gbPresonInformation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labellblPresonID;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}