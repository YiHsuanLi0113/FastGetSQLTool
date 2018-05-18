namespace Tool
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rdoTrad = new System.Windows.Forms.RadioButton();
            this.rdoInv = new System.Windows.Forms.RadioButton();
            this.groupKind = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupSQLScript = new System.Windows.Forms.GroupBox();
            this.groupNewPdt = new System.Windows.Forms.GroupBox();
            this.txtNewPdt = new System.Windows.Forms.TextBox();
            this.groupSavePos = new System.Windows.Forms.GroupBox();
            this.txtFilePos = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupKind.SuspendLayout();
            this.groupNewPdt.SuspendLayout();
            this.groupSavePos.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(471, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.cbbProduct_SelectedIndexChanged);
            // 
            // rdoTrad
            // 
            this.rdoTrad.AutoSize = true;
            this.rdoTrad.Location = new System.Drawing.Point(26, 21);
            this.rdoTrad.Name = "rdoTrad";
            this.rdoTrad.Size = new System.Drawing.Size(59, 16);
            this.rdoTrad.TabIndex = 3;
            this.rdoTrad.TabStop = true;
            this.rdoTrad.Text = "傳統型";
            this.rdoTrad.UseVisualStyleBackColor = true;
            this.rdoTrad.CheckedChanged += new System.EventHandler(this.rdoKind_CheckedChanged);
            // 
            // rdoInv
            // 
            this.rdoInv.AutoSize = true;
            this.rdoInv.Location = new System.Drawing.Point(104, 21);
            this.rdoInv.Name = "rdoInv";
            this.rdoInv.Size = new System.Drawing.Size(59, 16);
            this.rdoInv.TabIndex = 4;
            this.rdoInv.TabStop = true;
            this.rdoInv.Text = "投資型";
            this.rdoInv.UseVisualStyleBackColor = true;
            this.rdoInv.CheckedChanged += new System.EventHandler(this.rdoKind_CheckedChanged);
            // 
            // groupKind
            // 
            this.groupKind.Controls.Add(this.rdoTrad);
            this.groupKind.Controls.Add(this.rdoInv);
            this.groupKind.Location = new System.Drawing.Point(12, 22);
            this.groupKind.Name = "groupKind";
            this.groupKind.Size = new System.Drawing.Size(471, 50);
            this.groupKind.TabIndex = 5;
            this.groupKind.TabStop = false;
            this.groupKind.Text = "商品類型";
            // 
            // groupSQLScript
            // 
            this.groupSQLScript.Location = new System.Drawing.Point(12, 114);
            this.groupSQLScript.Name = "groupSQLScript";
            this.groupSQLScript.Size = new System.Drawing.Size(471, 265);
            this.groupSQLScript.TabIndex = 6;
            this.groupSQLScript.TabStop = false;
            this.groupSQLScript.Text = "SQL Script";
            // 
            // groupNewPdt
            // 
            this.groupNewPdt.Controls.Add(this.txtNewPdt);
            this.groupNewPdt.Location = new System.Drawing.Point(13, 385);
            this.groupNewPdt.Name = "groupNewPdt";
            this.groupNewPdt.Size = new System.Drawing.Size(470, 59);
            this.groupNewPdt.TabIndex = 7;
            this.groupNewPdt.TabStop = false;
            this.groupNewPdt.Text = "新商品代號";
            // 
            // txtNewPdt
            // 
            this.txtNewPdt.Location = new System.Drawing.Point(7, 22);
            this.txtNewPdt.Name = "txtNewPdt";
            this.txtNewPdt.Size = new System.Drawing.Size(457, 22);
            this.txtNewPdt.TabIndex = 0;
            // 
            // groupSavePos
            // 
            this.groupSavePos.Controls.Add(this.btnBrowse);
            this.groupSavePos.Controls.Add(this.txtFilePos);
            this.groupSavePos.Location = new System.Drawing.Point(13, 450);
            this.groupSavePos.Name = "groupSavePos";
            this.groupSavePos.Size = new System.Drawing.Size(471, 61);
            this.groupSavePos.TabIndex = 8;
            this.groupSavePos.TabStop = false;
            this.groupSavePos.Text = "存檔位置";
            // 
            // txtFilePos
            // 
            this.txtFilePos.Location = new System.Drawing.Point(8, 22);
            this.txtFilePos.Name = "txtFilePos";
            this.txtFilePos.Size = new System.Drawing.Size(370, 22);
            this.txtFilePos.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(385, 22);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "瀏覽..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 526);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(470, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "新增";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 580);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupSavePos);
            this.Controls.Add(this.groupNewPdt);
            this.Controls.Add(this.groupSQLScript);
            this.Controls.Add(this.groupKind);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupKind.ResumeLayout(false);
            this.groupKind.PerformLayout();
            this.groupNewPdt.ResumeLayout(false);
            this.groupNewPdt.PerformLayout();
            this.groupSavePos.ResumeLayout(false);
            this.groupSavePos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rdoTrad;
        private System.Windows.Forms.RadioButton rdoInv;
        private System.Windows.Forms.GroupBox groupKind;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupSQLScript;
        private System.Windows.Forms.GroupBox groupNewPdt;
        private System.Windows.Forms.TextBox txtNewPdt;
        private System.Windows.Forms.GroupBox groupSavePos;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilePos;
        private System.Windows.Forms.Button btnGenerate;
    }
}

