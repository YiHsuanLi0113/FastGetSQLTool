using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void 新增商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 addNew = new Form1();
            addNew.Show();
            Hide();  
        }

        private void 需求單號一鍵帶入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 replaceName = new Form2();
            replaceName.Show();
            Hide();
        }
    }
}
