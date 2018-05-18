namespace Tool
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.需求單號一鍵帶入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.行政表單懶人包ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增商品ToolStripMenuItem,
            this.需求單號一鍵帶入ToolStripMenuItem,
            this.行政表單懶人包ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // 新增商品ToolStripMenuItem
            // 
            this.新增商品ToolStripMenuItem.Name = "新增商品ToolStripMenuItem";
            this.新增商品ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.新增商品ToolStripMenuItem.Text = "新增商品";
            this.新增商品ToolStripMenuItem.Click += new System.EventHandler(this.新增商品ToolStripMenuItem_Click);
            // 
            // 需求單號一鍵帶入ToolStripMenuItem
            // 
            this.需求單號一鍵帶入ToolStripMenuItem.Name = "需求單號一鍵帶入ToolStripMenuItem";
            this.需求單號一鍵帶入ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.需求單號一鍵帶入ToolStripMenuItem.Text = "需求單號一鍵帶入";
            this.需求單號一鍵帶入ToolStripMenuItem.Click += new System.EventHandler(this.需求單號一鍵帶入ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 需求單號一鍵帶入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 行政表單懶人包ToolStripMenuItem;
    }
}