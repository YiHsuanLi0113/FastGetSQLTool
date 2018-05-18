using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool
{
    public partial class Generate
    {
        public static string _strNewPdtCode;

        //=================================================================
        // 【傳入存放新商品資料夾之路徑、新商品代碼】 建立最外層商品資料夾
        //=================================================================
        public void CreateFolders(string folderPosition, string strNewPdtCode)
        {
            if (Directory.Exists(folderPosition))
            {
                string mainFolder = Path.Combine(folderPosition, DateTime.Now.ToString("yyyyMMdd") + "- 新增商品 -" + strNewPdtCode);
                if (!Directory.Exists(mainFolder))
                {
                    Directory.CreateDirectory(mainFolder);
                    CreateSubFolders(mainFolder);
                    CreateScriptHelper(mainFolder);
                }
                else
                    MessageBox.Show("路徑中已含相同資料夾名稱，無法新增此資料夾");
            }
        }

        //=================================================================
        // 【傳入最外層資料夾路徑】 建立子資料夾(PromoteFile、SIT、UAT、UserDoc)
        //=================================================================
        private void CreateSubFolders(string mainFolderPos)
        {
            string[] subFolders = { "PromoteFile", "SIT", "UAT", "UserDoc" };
            
            foreach (var f in subFolders)
            {
                Directory.CreateDirectory(Path.Combine(mainFolderPos, f));

                if (f.Equals("PromoteFile"))
                    CreatePromoteFileFolder(Path.Combine(mainFolderPos, f));
                else if (f.Equals("SIT"))
                    AddSitFile(Path.Combine(mainFolderPos, f));
            }
        }

        //=================================================================
        // 【傳入PrmoteFile資料夾路徑】 建立PromoteFile子資料夾(ExecFiles、SSISDB、SSISFILE、WEBAP、WEBDB、WEBDBSSISFILE、資料源更新)
        //=================================================================
        private void CreatePromoteFileFolder(string pfFolderPath)
        {
            string[] promoteFileSub = { "ExecFiles", "SSISDB", "SSISFILE", "WEBAP", "WEBDB", "WEBDBSSISFILE", "資料源更新" };

            foreach (var f in promoteFileSub)
            {
                Directory.CreateDirectory(Path.Combine(pfFolderPath, f));
                string path = Path.Combine(pfFolderPath, f);

                if (f.Equals("WEBAP"))
                {
                    Directory.CreateDirectory(Path.Combine(path, "SFA"));
                }
                else if (f.Equals("WEBDB"))
                {
                    Generate gen = new Generate();
                    gen.CreateWEBDBScript(path);
                }               
            }
        }

        //=================================================================
        // 【傳入SIT資料夾路徑】 新增SIT三個檔案(測試紀錄、程式碼分析、工作項目追蹤)
        //=================================================================
        private void AddSitFile(string sitFolderPath)
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\files");
            FileInfo[] fileList = dir.GetFiles();

            foreach (var subFile in fileList)
            {
                File.Copy(subFile.FullName, Path.Combine(sitFolderPath, subFile.Name));
            }
        }
    }
}
