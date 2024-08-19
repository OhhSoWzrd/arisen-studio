﻿using System.ComponentModel;
using DevExpress.XtraEditors;

namespace ArisenStudio.Forms.Dialogs
{
    partial class LoginDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
            this.LabelUsername = new DevExpress.XtraEditors.LabelControl();
            this.LabelPassword = new DevExpress.XtraEditors.LabelControl();
            this.TextBoxUsername = new DevExpress.XtraEditors.TextEdit();
            this.TextBoxPassword = new DevExpress.XtraEditors.TextEdit();
            this.ButtonUseDefault = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelUsername
            // 
            this.LabelUsername.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LabelUsername.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.LabelUsername.Appearance.Options.UseFont = true;
            this.LabelUsername.Appearance.Options.UseForeColor = true;
            this.LabelUsername.Location = new System.Drawing.Point(12, 14);
            this.LabelUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.LabelUsername.Name = "LabelUsername";
            this.LabelUsername.Size = new System.Drawing.Size(56, 15);
            this.LabelUsername.TabIndex = 15;
            this.LabelUsername.Text = "Username:";
            // 
            // LabelPassword
            // 
            this.LabelPassword.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LabelPassword.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.LabelPassword.Appearance.Options.UseFont = true;
            this.LabelPassword.Appearance.Options.UseForeColor = true;
            this.LabelPassword.Location = new System.Drawing.Point(12, 43);
            this.LabelPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(53, 15);
            this.LabelPassword.TabIndex = 16;
            this.LabelPassword.Text = "Password:";
            // 
            // TextBoxUsername
            // 
            this.TextBoxUsername.Location = new System.Drawing.Point(90, 12);
            this.TextBoxUsername.Name = "TextBoxUsername";
            this.TextBoxUsername.Size = new System.Drawing.Size(282, 22);
            this.TextBoxUsername.TabIndex = 0;
            this.TextBoxUsername.EditValueChanged += new System.EventHandler(this.TextBoxUsername_EditValueChanged);
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(90, 41);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(282, 22);
            this.TextBoxPassword.TabIndex = 1;
            this.TextBoxPassword.EditValueChanged += new System.EventHandler(this.TextBoxPassword_EditValueChanged);
            // 
            // ButtonUseDefault
            // 
            this.ButtonUseDefault.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.ButtonUseDefault.Location = new System.Drawing.Point(90, 80);
            this.ButtonUseDefault.Name = "ButtonUseDefault";
            this.ButtonUseDefault.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.ButtonUseDefault.Size = new System.Drawing.Size(102, 23);
            this.ButtonUseDefault.TabIndex = 2;
            this.ButtonUseDefault.Text = "Use Default";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(198, 80);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.ButtonCancel.Size = new System.Drawing.Size(84, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancel";
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Enabled = false;
            this.ButtonOK.Location = new System.Drawing.Point(288, 80);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.ButtonOK.Size = new System.Drawing.Size(84, 23);
            this.ButtonOK.TabIndex = 4;
            this.ButtonOK.Text = "OK";
            // 
            // LoginDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 117);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonUseDefault);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUsername);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.LabelUsername);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ColorizeInactiveIcon = DevExpress.Utils.DefaultBoolean.True;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("LoginDialog.IconOptions.Icon")));
            this.IconOptions.Image = global::ArisenStudio.Properties.Resources.arisenstudio;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login Details";
            this.Load += new System.EventHandler(this.LoginDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LabelControl LabelUsername;
        private LabelControl LabelPassword;
        public SimpleButton ButtonUseDefault;
        public SimpleButton ButtonCancel;
        public SimpleButton ButtonOK;
        public TextEdit TextBoxUsername;
        public TextEdit TextBoxPassword;
    }
}