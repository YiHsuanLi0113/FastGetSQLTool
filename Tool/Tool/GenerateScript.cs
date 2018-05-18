using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public partial class Generate
    {
        string strNewPdtCode = Generate._strNewPdtCode;
        public static string strRefPdtCode;
        public static List<string> checkedScript;

        public void CreateScriptHelper(string mainFolderPath)
        {
            string fileName = strNewPdtCode + ".sql";
            var file = File.Create(Path.Combine(mainFolderPath, fileName));
            file.Close();

            string scriptFilePath = Path.Combine(mainFolderPath, fileName);

            string content = GenerateAllSelectScript(strNewPdtCode, strRefPdtCode, checkedScript);
            WriteIntoFile(scriptFilePath, content);
        }

        private string GenerateAllSelectScript(string strNewPdt, string strRefPdt, List<string> checkedScript)
        {
            GetDataDao dao = new GetDataDao();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            foreach (var script in checkedScript)
            {
                if (script.Equals("RPT_SECTION_D") || script.Equals("PLI_PDTRIDERSUM"))
                    sb.AppendLine(dao.GetScriptString(script, strRefPdt));
                else
                    sb.AppendLine(dao.GetScriptString(script, strNewPdt));
                sb.AppendLine(dao.GetScriptString(script, strRefPdt));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void CreateWEBDBScript(string webDBPath)
        {          
            foreach (var script in checkedScript)
            {
                CreateScriptFile(webDBPath, script);
            }
        }

        //=================================================================
        // 【傳入PromoteFile/WEBDB路徑、單個table name】 建立新商品代碼資料夾、SQL檔
        //=================================================================
        private void CreateScriptFile(string webDBPath, string script)
        {
            string fileName = strNewPdtCode + "_" + script + ".sql";
            Directory.CreateDirectory(Path.Combine(webDBPath, strNewPdtCode));
            var file = File.Create(Path.Combine(webDBPath, strNewPdtCode, fileName));
            file.Close();

            string scriptFilePath = Path.Combine(webDBPath, strNewPdtCode, fileName);

            string content = GenerateScript(script);
            WriteIntoFile(scriptFilePath, content);
        }

        //=================================================================
        // 【傳入SQL檔存放路徑、script內容】 將完成之SQL Script寫入至SQL檔
        //=================================================================
        private void WriteIntoFile(string scriptFilePath, string content)
        {
            using (StreamWriter sw = new StreamWriter(scriptFilePath, false, Encoding.GetEncoding("big5")))
            {
                sw.Write(content);
            }
        }

        //=================================================================
        // 【傳入單個Table Name】 取得該tabledata並轉成script
        //=================================================================
        private string GenerateScript(string script)
        {
            GetDataDao dao = new GetDataDao();

            DataTable dt = new DataTable();
            dt = dao.GetScriptData(script, strRefPdtCode);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetDeleteScript(script));
            sb.AppendLine();
            sb.Append("INSERT INTO [dbo].");
            sb.Append("[" + dt.TableName + "]");
            sb.Append("(");
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append("[" + col.ToString() + "], ");
            }
            sb = sb.Remove(sb.Length - 2, 2);
            sb.AppendLine(")");
            sb.AppendLine("values");

            foreach (DataRow row in dt.Rows)
            {
                sb.Append("(");
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.DataType.ToString().Equals("System.String"))
                        sb.Append(" N'" + row[col].ToString() + "',");
                    else if (col.DataType.ToString().Equals("System.DateTime"))
                        sb.Append(" '" + Convert.ToDateTime(row[col]).ToString("yyyyMMdd hh:mm:ss.fff") + "',");
                    else
                        sb.Append(" " + row[col].ToString() + ",");
                }
                sb = sb.Remove(sb.Length - 1, 1);
                sb.AppendLine(" ),");
            }
            sb = sb.Remove(sb.Length - 3, 3);

            string finalStr = ReplaceToNewPdt(sb.ToString());

            return finalStr;
        }

        //=================================================================
        // 【傳入table name】 取得該table的select語句，代換成delete語句
        //=================================================================
        private string GetDeleteScript(string script)
        {
            GetDataDao dao = new GetDataDao();

            string scriptString = string.Empty;
            scriptString = dao.GetScriptString(script, strRefPdtCode);

            scriptString = scriptString.Replace("select * ", "delete ");

            return scriptString;
        }

        //=================================================================
        // 【傳入delete語句 + insert into語句】 將商品代碼代換為新商品代碼
        //=================================================================
        private string ReplaceToNewPdt(string fullScript)
        {
            fullScript = fullScript.Replace(strRefPdtCode, _strNewPdtCode);

            return fullScript;
        }
    }
}
