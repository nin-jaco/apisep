using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using ApiSep.Dal.Entities;
using ApiSep.Library.Handlers;
using ApiSep.Library.Models.dto;
using ApiSep.Library.RequestObjects;
using ApiSep.Library.Utilities;
using ApiSep.Wcf;
using Telerik.Web.UI;

namespace ApiSep.Ui.Grid
{
    public partial class Grid : System.Web.UI.Page
    {
        private static WcfProxy Proxy { get; } = new WcfProxy();

        public static List<User> GetAll()
        {
            try
            {
                return Proxy.PerformRemote<IUserService, List<User>>(x => x.GetAll());
            }
            catch (Exception e)
            {
                ErrorHandler.LogException(e);
                return null;
            }
        }

        public static string GetBrowserVersion()
        {
            return HttpContext.Current.Request.Browser.Version;
        }

        public static string GetBrowser()
        {
            return HttpContext.Current.Request.Browser.Browser;
        }

        public static string GetUserAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }

        public static string GetRequestUrl()
        {
            return HttpContext.Current.Request.Url?.AbsoluteUri;
        }

        public static string GetUserIp()
        {
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = GetAll();
        }

        protected void RadGrid1_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            //Hashtable table = new Hashtable();
            //(e.Item as GridEditableItem).ExtractValues(table);

            //DataRow row = this.Users.Rows.Find((e.Item as GridEditableItem).GetDataKeyValue("ID"));

            //foreach (string key in table.Keys)
            //{
            //    row[key] = table[key] ?? DBNull.Value;
            //}
            //DateTime date;
            //if (DateTime.TryParse((row["BirthDate"].ToString()), out date))
            //{
            //    row["Age"] = DateTime.Now.Year - date.Year;
            //}
            //else
            //{
            //    row["Age"] = 0;
            //}
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            //Hashtable table = new Hashtable();
            //(e.Item as GridEditableItem).ExtractValues(table);
            //DataRow row = this.Users.NewRow();

            //foreach (string key in table.Keys)
            //{
            //    if (table[key] != null)
            //    {
            //        row[key] = table[key];
            //    }
            //}
            //row["ID"] = new Random().Next(int.MaxValue);
            //DateTime date;
            //if (DateTime.TryParse((row["BirthDate"].ToString()), out date))
            //{
            //    row["Age"] = DateTime.Now.Date.Year - date.Year;
            //}
            //this.Users.Rows.InsertAt(row, 0);
        }

        protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            //this.Users.Rows.Remove(this.Users.Rows.Find((e.Item as GridEditableItem).GetDataKeyValue("ID")));
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //RadComboBox comboBox = e.Item.FindControl("RCB_City") as RadComboBox;
            //if (comboBox != null)
            //{
            //    if (!(e.Item.DataItem is GridInsertionObject))
            //    {
            //        comboBox.SelectedValue = (e.Item.DataItem as DataRowView)["City"].ToString();
            //    }
            //    comboBox.DataTextField = string.Empty;
            //    comboBox.DataBind();
            //    if (this.RadGrid1.ResolvedRenderMode == RenderMode.Mobile)
            //    {
            //        (e.Item.FindControl("TB_Age") as WebControl).Enabled = false;
            //    }
            //    else
            //    {
            //        ((e.Item as GridEditableItem)["Age"].Controls[0] as WebControl).Enabled = false;
            //    }
            //}
        }

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            //GridHeaderItem headerItem = e.Item as GridHeaderItem;
            //if (headerItem != null)
            //{
            //    headerItem["EditColumn"].Text = string.Empty;
            //    headerItem["DeleteColumn"].Text = string.Empty;
            //}
        }
    }
}
