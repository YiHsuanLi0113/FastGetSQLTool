namespace Tool
{
    partial class Form2
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
            this.groupNumber = new System.Windows.Forms.GroupBox();
            this.txtReqNum = new System.Windows.Forms.TextBox();
            this.groupName = new System.Windows.Forms.GroupBox();
            this.txtPdtName = new System.Windows.Forms.TextBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFolderPos = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupNumber.SuspendLayout();
            this.groupName.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupNumber
            // 
            this.groupNumber.Controls.Add(this.txtReqNum);
            this.groupNumber.Location = new System.Drawing.Point(13, 76);
            this.groupNumber.Name = "groupNumber";
            this.groupNumber.Size = new System.Drawing.Size(318, 56);
            this.groupNumber.TabIndex = 0;
            this.groupNumber.TabStop = false;
            this.groupNumber.Text = "需求單號";
            // 
            // txtReqNum
            // 
            this.txtReqNum.Location = new System.Drawing.Point(7, 22);
            this.txtReqNum.Name = "txtReqNum";
            this.txtReqNum.Size = new System.Drawing.Size(305, 22);
            this.txtReqNum.TabIndex = 0;
            // 
            // groupName
            // 
            this.groupName.Controls.Add(this.txtPdtName);
            this.groupName.Location = new System.Drawing.Point(12, 138);
            this.groupName.Name = "groupName";
            this.groupName.Size = new System.Drawing.Size(318, 56);
            this.groupName.TabIndex = 1;
            this.groupName.TabStop = false;
            this.groupName.Text = "商品名稱";
            // 
            // txtPdtName
            // 
            this.txtPdtName.Location = new System.Drawing.Point(7, 22);
            this.txtPdtName.Name = "txtPdtName";
            this.txtPdtName.Size = new System.Drawing.Size(305, 22);
            this.txtPdtName.TabIndex = 0;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(12, 213);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(318, 23);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "代換";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtFolderPos);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 57);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料夾位置";
            // 
            // txtFolderPos
            // 
            this.txtFolderPos.Location = new System.Drawing.Point(7, 22);
            this.txtFolderPos.Name = "txtFolderPos";
            this.txtFolderPos.Size = new System.Drawing.Size(231, 22);
            this.txtFolderPos.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(245, 22);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(66, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "瀏覽..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 259);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.groupName);
            this.Controls.Add(this.groupNumber);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupNumber.ResumeLayout(false);
            this.groupNumber.PerformLayout();
            this.groupName.ResumeLayout(false);
            this.groupName.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupNumber;
        private System.Windows.Forms.TextBox txtReqNum;
        private System.Windows.Forms.GroupBox groupName;
        private System.Windows.Forms.TextBox txtPdtName;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFolderPos;
    }
}