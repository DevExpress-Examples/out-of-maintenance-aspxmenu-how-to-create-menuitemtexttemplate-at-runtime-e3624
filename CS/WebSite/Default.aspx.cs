using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DevExpress.Web;
using System.Web.UI;
using System.Drawing;


public partial class _Default : System.Web.UI.Page {
    protected void Page_Load (object sender, EventArgs e) {

    }
    protected void ASPxMenu2_ItemDataBound (object source, DevExpress.Web.MenuItemEventArgs e) {
        SiteMapNode node = e.Item.DataItem as SiteMapNode;
        if (node != null) {
            e.Item.TextTemplate = new MenuItemTemplate(node);
        }
    }

    class MenuItemTemplate : ITemplate {
        SiteMapNode node;

        public MenuItemTemplate (SiteMapNode node) {
            this.node = node;
        }

        public void InstantiateIn (Control container) {
            ASPxLabel lb = new ASPxLabel();
            lb.Text = node.Title;
            container.Controls.Add(lb);

            if (node["description"] == null)
                return;

            System.Web.UI.HtmlControls.HtmlGenericControl dynBR = new System.Web.UI.HtmlControls.HtmlGenericControl("BR");
            container.Controls.Add(dynBR);

            ASPxHyperLink link = new ASPxHyperLink();
            link.NavigateUrl = node.Url;
            link.Text = node["description"];
            link.ForeColor = Color.Blue;
            container.Controls.Add(link);


        }
    }
}
