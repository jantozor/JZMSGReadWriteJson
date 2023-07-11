namespace JZMSGReadWriteJson
{
    partial class MsgBoxExForm
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

        // Disable double click on the message label.
        [System.Security.Permissions.SecurityPermissionAttribute(System.Security.Permissions.SecurityAction.Demand, UnmanagedCode = true)]
        private class SingleClickLabel : System.Windows.Forms.Label
        {
            protected override System.Windows.Forms.CreateParams CreateParams
            {
                get
                {
                    // From the original code, found at the web but the code is obsolete, so I changed it
                    // to [SecurityPermissionAttribute(SecurityAction.Demand, UnmanagedCode = true)] which is added
                    // before the class.
                    //new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();

                    System.Windows.Forms.CreateParams cp = base.CreateParams;
                    cp.ClassStyle &= ~0x0008;
                    cp.ClassName = null;

                    return cp;
                }
            }
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.chkDoNotShowAgain = new System.Windows.Forms.CheckBox();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.pnlIcon = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblMessage = new MsgBoxExForm.SingleClickLabel();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.pnlIcon.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Controls.Add(this.chkDoNotShowAgain);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 100);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(262, 41);
            this.pnlButtons.TabIndex = 2;
            // 
            // chkDoNotShowAgain
            // 
            this.chkDoNotShowAgain.AutoSize = true;
            this.chkDoNotShowAgain.BackColor = System.Drawing.Color.Transparent;
            this.chkDoNotShowAgain.Location = new System.Drawing.Point(3, 0);
            this.chkDoNotShowAgain.Name = "chkDoNotShowAgain";
            this.chkDoNotShowAgain.Size = new System.Drawing.Size(189, 17);
            this.chkDoNotShowAgain.TabIndex = 3;
            this.chkDoNotShowAgain.Text = "Do not display this message again.";
            this.chkDoNotShowAgain.UseVisualStyleBackColor = false;
            this.chkDoNotShowAgain.Visible = false;
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(17, 23);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(32, 32);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIcon.TabIndex = 5;
            this.picIcon.TabStop = false;
            // 
            // pnlIcon
            // 
            this.pnlIcon.BackColor = System.Drawing.Color.Transparent;
            this.pnlIcon.Controls.Add(this.picIcon);
            this.pnlIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIcon.Location = new System.Drawing.Point(0, 0);
            this.pnlIcon.Name = "pnlIcon";
            this.pnlIcon.Size = new System.Drawing.Size(51, 100);
            this.pnlIcon.TabIndex = 6;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.lblMessage);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(51, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(211, 100);
            this.pnlMain.TabIndex = 7;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(5, 28);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message";
            // 
            // MsgBoxExForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(262, 141);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlIcon);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(497, 800);
            this.MinimizeBox = false;
            this.Name = "MsgBoxExForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MsgBoxForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MsgBoxForm_KeyDown);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.pnlIcon.ResumeLayout(false);
            this.pnlIcon.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.CheckBox chkDoNotShowAgain;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Panel pnlIcon;
        private System.Windows.Forms.Panel pnlMain;
        private MsgBoxExForm.SingleClickLabel lblMessage;
    }
}