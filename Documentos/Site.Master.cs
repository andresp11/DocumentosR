using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Documentos.includes;
using System.Data;
using System.Data.SqlClient;


namespace Documentos
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        static string DC = System.Configuration.ConfigurationManager.ConnectionStrings["facturassqlconn"].ConnectionString;
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    Server.Transfer("login.aspx", false); 
                    //throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            String strSql = "SELECT P.ProcesoWebKey, P.NombreProcesoWeb FROM PROCESOWEB P";
            strSql += " INNER JOIN PERMISOWEB E ON E.ProcesoWebid = P.ProcesoWebkey ";
            strSql += " Where E.PERFILWEBid = '" + secure.ObtieneIdPerfilWeb() + "' ";
            strSql += " Order by P.ProcesoWebKey";

//            string SqlConn = @"Datasource=ANDRES_P11; database=Documentos;  Uid=sa; pwd=ep1tafi0";
            SqlConnection sqlConn = new SqlConnection(DC);
            sqlConn.Open();
            SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
            try
            {
                SqlDataReader dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    foreach (MenuItem item in Menu1.Items)
                    {
//                        if (item.Value == int.Parse(dr["NombreProcesoWeb"].ToString()))
//                            item.Enabled = true;
                        foreach (MenuItem childItem in item.ChildItems)
                        {
                            if (int.Parse(childItem.Value.ToString()) == int.Parse(dr["ProcesoWebKey"].ToString()))
                                childItem.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("Default.aspx", false);
        }
    }
}