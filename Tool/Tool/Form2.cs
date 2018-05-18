using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            string requireNum = txtReqNum.Text;
            string pdtName = txtPdtName.Text;
            string folderPos = txtFolderPos.Text;

            int isSuccess = 0;

            ReplaceFolderName rplc = new ReplaceFolderName();
            isSuccess = rplc.RenameFolder(folderPos, requireNum, pdtName);

            if (isSuccess.Equals(3))
                MessageBox.Show("重新命名完成");
            else
                MessageBox.Show("相同資料夾名稱已存在");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.ShowDialog();

            txtFolderPos.Text = dialog.SelectedPath;
        }
    }
}
