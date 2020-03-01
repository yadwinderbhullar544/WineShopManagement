using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WineShopManagement.Bussiness;
using WineShopManagement.Data;

namespace WineShopManagement
{
    public partial class WineView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Wine_Fill();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("WineView.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Wine Obj_Add_Wn = new Wine
            {
                Name = txtName.Text,
            };
            WineBiz.SaveWines(Obj_Add_Wn);
            Wine_Fill();
        }

        private void Wine_Fill()
        {
            WineBiz Obj_Wine = new WineBiz();
            List<Wine> Obj_Wn = Obj_Wine.GetWines();
            if (Obj_Wn != null && Obj_Wn.Count > 0)
            {
                grd.DataSource = Obj_Wn;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
    }
}