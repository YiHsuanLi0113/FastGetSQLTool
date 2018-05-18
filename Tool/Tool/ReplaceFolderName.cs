using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool
{
    class ReplaceFolderName
    {
        //=================================================================
        // 【傳入商品資料夾路徑、需求代碼、商品名稱】 重新命名商品資料夾
        //=================================================================
        public int RenameFolder(string folderPos, string reqNum, string pdtName)
        {
            int isSuccess = 0;
            string folderMainPos = folderPos.Substring(0, folderPos.Length - (folderPos.Length - folderPos.LastIndexOf("\\")));

            DirectoryInfo dir = new DirectoryInfo(folderPos);
            string newFolder = Path.Combine(folderMainPos, reqNum + "-新增" + pdtName + "建議書");
            if (!Directory.Exists(newFolder))
            {
                dir.MoveTo(newFolder);
                string sitFolderPos = Path.Combine(newFolder, "SIT");
                isSuccess = RenameFile(sitFolderPos, reqNum);
                return isSuccess;
            }
            else
            {
                return isSuccess;
            } 
        }

        //=================================================================
        // 【傳入商品資料夾中SIT路徑、需求代碼】 SIT檔名加上需求代碼
        //=================================================================
        private int RenameFile(string sitFolderPos, string reqNum)
        {
            int isSuccess = 0;
            string[] files = Directory.GetFiles(sitFolderPos);

            foreach (var file in files)
            {
                string newPath = file.Substring(0, file.Length - (file.Length - file.LastIndexOf("\\")));
                string oriName = file.Substring(file.LastIndexOf("\\") + 1);
                string recordFileWithEx = file.Substring(file.LastIndexOf("\\") + 1);
                string recordFileName = recordFileWithEx.Remove(recordFileWithEx.LastIndexOf('.'));

                if (file.Contains("測試紀錄"))
                {
                    if (recordFileName.Contains(reqNum))
                    {
                        MessageBox.Show("檔名可能已完成更改，請重新確認");
                    }
                    else
                    {
                        File.Move(file, Path.Combine(newPath, recordFileName + reqNum + file.Substring(file.LastIndexOf('.'))));
                        isSuccess++;
                    }   
                }    
                else
                {
                    if (recordFileName.Contains(reqNum))
                        MessageBox.Show("檔名可能已完成更改，請重新確認");
                    else
                    {
                        File.Move(file, Path.Combine(newPath, reqNum + oriName));
                        isSuccess++;
                    } 
                }         
            }
            return isSuccess;
        }
    }
}
