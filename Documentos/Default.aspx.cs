using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Documentos.includes;

namespace Documentos
{
    public partial class _Default : Page
    {
        static string DC = System.Configuration.ConfigurationManager.ConnectionStrings["facturassqlconn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idusuario = secure.ObjtieneIdUsuario();
            if (idusuario  =="")
                Response.Redirect("http://documentosr.ppenaw.com/login.aspx");
            String strSql = "SELECT file_id, name, type_desc, physical_name, size, max_size FROM sys.database_files ";
            SqlConnection sqlConn = new SqlConnection(DC);
            sqlConn.Open();
            SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
            try
            {
                SqlDataReader dr = sqlCmd.ExecuteReader();
                if (dr.Read())
                    lblBase.Text = "Tamaño de la Base de datos (KBytes): " + dr["size"].ToString() + "    ";
            }   
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }
            strSql = "SELECT Count(*) as NDoc FROM Documentos ";
            sqlConn.Open();
            SqlCommand sqlCmd1 = new SqlCommand(strSql, sqlConn);
            try
            {
                SqlDataReader dr1 = sqlCmd1.ExecuteReader();
                if (dr1.Read())
                    lblDocs.Text = "Número de documentos almacenados: " + dr1["NDoc"].ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }
        }
    }
}