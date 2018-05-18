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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rdoTrad.Checked = true;
        }

        //=================================================================
        // 【傳入商品類別代碼】 帶出商品下拉列表
        //=================================================================
        protected void ShowProductList(string productKind)
        {
            GetDataDao dao = new GetDataDao();
            DataTable dt = dao.GetProducts(productKind);
            DataRow row = dt.NewRow();
            row["fullName"] = "請選擇";
            row["PD_PDTCODE"] = "";
            dt.Rows.InsertAt(row, 0);

            comboBox1.DisplayMember = "fullName";
            comboBox1.ValueMember = "PD_PDTCODE";
            comboBox1.DataSource = dt; 
        }

        //=================================================================
        // 【傳入商品類別代碼】 帶出該類別所有可能需設定的table name
        //=================================================================
        protected void ShowScriptList(string productKind)
        {
            groupSQLScript.Controls.Clear();
            string[] tradRptList = { "SYS_PLDF_REL_FORM_M", "RPT_PRODUCT_D", "RPT_SECTION_D", "RPT_TEXT_D", "IndemnifyRules",  "PLI_PDTYEAR", "PLI_PDTDENY", "PLI_PDTRIDERSUM", "PLI_PDTRIDER", "PLI_PDTRIDERDETAIL_D", "PLI_PDTPARAMETER", "PLI_PDTASSUMED_INTERESTRATE", "PLI_PDTDISCOUNT", "PLI_PDTFA"};
            string[] invRptList = { "SYS_PLDF_REL_FORM_M", "RPT_PRODUCT_D", "RPT_SECTION_D", "RPT_TEXT_D", "PLI_INVESTMAP", "PLI_PDTLIMIT", "PLI_INVESTRATE", "PLI_PDTPARAMETER", "PLI_INVESTSALESTB" };

            int a = 30;
            int b = 30;

            switch (productKind)
            {
                case "1":
                    for (int i = 0; i < tradRptList.Length; i++)
                    {
                        CheckBox ckb = new CheckBox();
                        //ckb.Click += new System.EventHandler(scriptCheckbox_Click);
                        ckb.Name = tradRptList[i];
                        ckb.Text = tradRptList[i];
                        ckb.Width = 200;
                        if ((i > 6 && i <= 12) || (i > 12 && i <= 19))
                        {
                            ckb.Location = new Point(220, b);
                            b += 30;
                        }
                        else
                        {
                            ckb.Location = new Point(20, a);
                            a += 30;
                        }
                        groupSQLScript.Controls.Add(ckb);
                        ckb.Show();
                    }
                    break;

                case "2":
                    for (int i = 0; i < invRptList.Length; i++)
                    {
                        CheckBox ckb = new CheckBox();
                        //ckb.Click += new System.EventHandler(scriptCheckbox_Click);
                        ckb.Name = invRptList[i];
                        ckb.Text = invRptList[i];
                        ckb.Width = 200;
                        if ((i > 6 && i <= 12) || (i > 12 && i <= 19))
                        {
                            ckb.Location = new Point(220, b);
                            b += 30;
                        }
                        else
                        {
                            ckb.Location = new Point(20, a);
                            a += 30;
                        }
                        groupSQLScript.Controls.Add(ckb);
                        ckb.Show();
                    }
                    break;
            }
        }

        //=================================================================
        // 【ComboBox SelectedIndexChanged】 選擇商品代碼，將該商品已設定之table name勾選
        //=================================================================
        protected void cbbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.Equals(0))
            {
                if (rdoTrad.Checked.Equals(true))
                    ShowScriptList("1");
                else
                    ShowScriptList("2");
            }

            ComboBox cbb = (ComboBox)sender;
            string pdtCode = cbb.SelectedValue.ToString();
            Generate.strRefPdtCode = pdtCode;

            DataSet ds = new DataSet();

            GetDataDao dao = new GetDataDao();

            if (rdoTrad.Checked.Equals(true))
            {
                ds = dao.GetProductScriptList("1", pdtCode);

                foreach (DataTable tb in ds.Tables)
                {
                    if (tb.Rows.Count > 0)
                    {
                        CheckBox ckb = groupSQLScript.Controls.Find(tb.TableName, true).First() as CheckBox;
                        ckb.Checked = true;
                    }
                }
            }
            else
            {
                ds = dao.GetProductScriptList("2", pdtCode);

                foreach (DataTable tb in ds.Tables)
                {
                    if (tb.Rows.Count > 0)
                    {
                        CheckBox ckb = groupSQLScript.Controls.Find(tb.TableName, true).First() as CheckBox;
                        ckb.Checked = true;
                    }
                }
            }                  
        }

        //private void scriptCheckbox_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //=================================================================
        // 【RadioButton CheckedChanged】 選擇商品類別，切換商品列表及table清單
        //=================================================================
        private void rdoKind_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            if (rdo.Checked.Equals(true))
            {
                switch (rdo.Name)
                {
                    case "rdoTrad":
                        ShowProductList("1");
                        ShowScriptList("1");
                        break;

                    case "rdoInv":
                        ShowProductList("2");
                        ShowScriptList("2");
                        break;
                }
            }         
        }

        //=================================================================
        // 【Button Click】 選擇存放路徑資料夾(預設畫面為我的電腦)
        //=================================================================
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.ShowDialog();

            txtFilePos.Text = dialog.SelectedPath;
        }

        //=================================================================
        // 【Button Click】 產生新商品資料夾及SQL檔
        //=================================================================
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string strNewPdt = txtNewPdt.Text;
            Generate._strNewPdtCode = strNewPdt;

            List<string> checkedScripts = new List<string>();

            foreach (CheckBox ckb in groupSQLScript.Controls)
            {
                if (ckb.Checked.Equals(true))
                    checkedScripts.Add(ckb.Name);
            }
            Generate.checkedScript = checkedScripts;

            string folderPos = txtFilePos.Text;

            Generate gen = new Generate();
            gen.CreateFolders(folderPos, strNewPdt);

            MessageBox.Show("新增完成");
        }
    }
}
