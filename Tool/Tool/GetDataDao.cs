using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tool
{
    public class GetDataDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        //=================================================================
        // 【傳入商品類別代碼】 取得該類別之商品列表
        //=================================================================
        public DataTable GetProducts(string productKind)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    if (productKind.Equals("1"))
                        cmd.CommandText = "Select (PD_PDTCODE + '   ' + PD_PDTNAME) As fullName, PD_PDTCODE From PLI_PDT_M Where PK_CLASS < 21 ";
                    else
                        cmd.CommandText = "Select (PD_PDTCODE + '   ' + PD_PDTNAME) As fullName, PD_PDTCODE From PLI_PDT_M Where PK_CLASS >= 21 ";

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    return dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("錯誤: " + ex);
                    return null;
                }
            }
        }

        //=================================================================
        // 【傳入商品類別、商品代碼】 取得該參照商品有哪些table 
        //=================================================================
        public DataSet GetProductScriptList(string productKind, string productCode)
        {
            string[] tradRptList = { "SYS_PLDF_REL_FORM_M", "RPT_PRODUCT_D", "RPT_SECTION_D", "RPT_TEXT_D", "IndemnifyRules", "PLI_PDTYEAR", "PLI_PDTDENY", "PLI_PDTRIDERSUM", "PLI_PDTRIDER", "PLI_PDTRIDERDETAIL_D", "PLI_PDTPARAMETER", "PLI_PDTASSUMED_INTERESTRATE", "PLI_PDTDISCOUNT", "PLI_PDTFA" };
            string[] invRptList = { "SYS_PLDF_REL_FORM_M", "RPT_PRODUCT_D", "RPT_SECTION_D", "RPT_TEXT_D", "PLI_INVESTMAP", "PLI_PDTLIMIT", "PLI_INVESTRATE", "PLI_PDTPARAMETER", "PLI_INVESTSALESTB" };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    DataSet ds = new DataSet();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    
                    switch (productKind)
                    {
                        case "1":
                            foreach(var item in tradRptList)
                            {
                                switch (item)
                                {
                                    case "SYS_PLDF_REL_FORM_M":
                                        cmd.CommandText = "select * from SYS_PLDF_REL_FORM_M where PLAN_CODE = '" + productCode + "'";
                                        break;

                                    case "RPT_PRODUCT_D":
                                        cmd.CommandText = "select * from RPT_PRODUCT_D where PRD_PRODUCT = '" + productCode + "'";
                                        break;

                                    case "RPT_SECTION_D":
                                        cmd.CommandText = "select * from RPT_SECTION_D where SEC_PK in (select SEC_PK from RPT_TEXT_D where TXT_PRODUCT = '" + productCode + "')";
                                        break;

                                    case "RPT_TEXT_D":
                                        cmd.CommandText = "select * from RPT_TEXT_D where TXT_PRODUCT = '" + productCode + "'";
                                        break;

                                    case "IndemnifyRules":
                                        cmd.CommandText = "select * from IndemnifyRules where PdtCode = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTYEAR":
                                        cmd.CommandText = "select * from PLI_PDTYEAR where PD_PDTCODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTDENY":
                                        cmd.CommandText = "select * from PLI_PDTDENY where PR_MPDTCODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTRIDERSUM":
                                        cmd.CommandText = "select * from PLI_PDTRIDERSUM where RS_SUMCODE in (select RS_SUMCODE from PLI_PDTRIDERDETAIL_D where RD_PDTCODE = '" + productCode + "')";
                                        break;

                                    case "PLI_PDTRIDER":
                                        cmd.CommandText = "select * from PLI_PDTRIDER where RI_PDTCODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTRIDERDETAIL_D":
                                        cmd.CommandText = "select * from PLI_PDTRIDERDETAIL_D where RD_PDTCODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTPARAMETER":
                                        cmd.CommandText = "select * from PLI_PDTPARAMETER where PR_TYPECODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTASSUMED_INTERESTRATE":
                                        cmd.CommandText = "select * from PLI_PDTASSUMED_INTERESTRATE where PR_PDTCODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTDISCOUNT":
                                        cmd.CommandText = "select * from PLI_PDTDISCOUNT where PD_PDTCODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTFA":
                                        cmd.CommandText = "select * from PLI_PDTFA where FA_PDTCODE = '" + productCode + "'";
                                        break;
                                }
                                cmd.Connection = conn;

                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dt.TableName = item;

                                ds.Tables.Add(dt);
                            }
                            break;

                        case "2":
                            foreach (var item in invRptList)
                            {
                                switch (item)
                                {
                                    case "SYS_PLDF_REL_FORM_M":
                                        cmd.CommandText = "select * from SYS_PLDF_REL_FORM_M where PLAN_CODE = '" + productCode + "'";
                                        break;

                                    case "RPT_PRODUCT_D":
                                        cmd.CommandText = "select * from RPT_PRODUCT_D where PRD_PRODUCT = '" + productCode + "'";
                                        break;

                                    case "RPT_SECTION_D":
                                        cmd.CommandText = "select * from RPT_SECTION_D where SEC_PK in (select SEC_PK from RPT_TEXT_D where TXT_PRODUCT = '" + productCode + "')";
                                        break;

                                    case "RPT_TEXT_D":
                                        cmd.CommandText = "select * from RPT_TEXT_D where TXT_PRODUCT = '" + productCode + "'";
                                        break;

                                    case "PLI_INVESTMAP":
                                        cmd.CommandText = "select * from PLI_INVESTMAP where PDT_CODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTLIMIT":
                                        cmd.CommandText = "select * from PLI_PDTLIMIT where PL_PDTCODE = '" + productCode + "'";
                                        break;

                                    case "PLI_INVESTRATE":
                                        cmd.CommandText = "select * from PLI_INVESTRATE where IR_PDTCODE = '" + productCode + "'";
                                        break;

                                    case "PLI_PDTPARAMETER":
                                        cmd.CommandText = "select * from PLI_PDTPARAMETER where PR_TYPECODE = '" + productCode + "'";
                                        break;

                                    case "PLI_INVESTSALESTB":
                                        cmd.CommandText = "select * from PLI_INVESTSALESTB where IS_PDTCODE = '" + productCode + "'";
                                        break;
                                }
                                cmd.Connection = conn;

                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                dt.TableName = item;

                                ds.Tables.Add(dt);
                            }
                            break;
                    }

                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //=================================================================
        // 【傳入table name、商品代碼】 取得該table之select語句
        //=================================================================
        public string GetScriptString(string script, string productCode)
        {
            string cmdString = string.Empty;

            switch (script)
            {
                case "SYS_PLDF_REL_FORM_M":
                    cmdString = "select * from SYS_PLDF_REL_FORM_M where PLAN_CODE = '" + productCode + "'";
                    break;

                case "RPT_PRODUCT_D":
                    cmdString = "select * from RPT_PRODUCT_D where PRD_PRODUCT = '" + productCode + "'";
                    break;

                case "RPT_SECTION_D":
                    cmdString = "select * from RPT_SECTION_D where SEC_PK in (" + GetTableResultString("select SEC_PK from RPT_TEXT_D where TXT_PRODUCT = '" + productCode + "'") + ")";
                    break;

                case "RPT_TEXT_D":
                    cmdString = "select * from RPT_TEXT_D where TXT_PRODUCT = '" + productCode + "'";
                    break;

                case "IndemnifyRules":
                    cmdString = "select * from IndemnifyRules where PdtCode = '" + productCode + "'";
                    break;

                case "PLI_PDTYEAR":
                    cmdString = "select * from PLI_PDTYEAR where PD_PDTCODE = '" + productCode + "'";
                    break;

                case "PLI_PDTDENY":
                    cmdString = "select * from PLI_PDTDENY where PR_MPDTCODE = '" + productCode + "'";
                    break;

                case "PLI_PDTRIDERSUM":
                    cmdString = "select * from PLI_PDTRIDERSUM where RS_SUMCODE in (" + GetTableResultString("select RS_SUMCODE from PLI_PDTRIDERDETAIL_D where RD_PDTCODE = '" + productCode + "'") + ")";
                    break;

                case "PLI_PDTRIDER":
                    cmdString = "select * from PLI_PDTRIDER where RI_PDTCODE = '" + productCode + "'";
                    break;

                case "PLI_PDTRIDERDETAIL_D":
                    cmdString = "select * from PLI_PDTRIDERDETAIL_D where RD_PDTCODE = '" + productCode + "'";
                    break;

                case "PLI_PDTPARAMETER":
                    cmdString = "select * from PLI_PDTPARAMETER where PR_TYPECODE = '" + productCode + "'";
                    break;

                case "PLI_PDTASSUMED_INTERESTRATE":
                    cmdString = "select * from PLI_PDTASSUMED_INTERESTRATE where PR_PDTCODE = '" + productCode + "'";
                    break;

                case "PLI_PDTDISCOUNT":
                    cmdString = "select * from PLI_PDTDISCOUNT where PD_PDTCODE = '" + productCode + "'";
                    break;

                case "PLI_PDTFA":
                    cmdString = "select * from PLI_PDTFA where FA_PDTCODE = '" + productCode + "'";
                    break;

                case "PLI_INVESTMAP":
                    cmdString = "select * from PLI_INVESTMAP where PDT_CODE = '" + productCode + "'";
                    break;

                case "PLI_PDTLIMIT":
                    cmdString = "select * from PLI_PDTLIMIT where PL_PDTCODE = '" + productCode + "'";
                    break;

                case "PLI_INVESTRATE":
                    cmdString = "select * from PLI_INVESTRATE where IR_PDTCODE = '" + productCode + "'";
                    break;

                case "PLI_INVESTSALESTB":
                    cmdString = "select * from PLI_INVESTSALESTB where IS_PDTCODE = '" + productCode + "'";
                    break;
            }

            return cmdString;
        }

        //=================================================================
        // 【傳入table name、商品代碼】 取得該參照商品之table data
        //=================================================================
        public DataTable GetScriptData(string script, string productCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    cmd.CommandText = GetScriptString(script, productCode);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dt.TableName = script;

                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable GetData(string cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.Text;
                    command.Connection = conn;
                    command.CommandText = cmd;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string GetTableResultString(string cmd)
        {
            DataTable dt = new DataTable();
            dt = GetData(cmd);

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("'" + dr[dc] + "',");
                }
            }
            sb = sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
