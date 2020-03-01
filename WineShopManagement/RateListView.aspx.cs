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
    public partial class RateListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RateList_Fill();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("RateListView.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            RateList Obj_Add_Rl = new RateList
            {
                Price = Convert.ToDecimal(txtPrice.Text),
            };
            RateListBiz.SaveRateLists(Obj_Add_Rl);
            RateList_Fill();
        }

        private void RateList_Fill()
        {
            RateListBiz Obj_RateList = new RateListBiz();
            List<RateList> Obj_Rl = Obj_RateList.GetRateLists();
            if (Obj_Rl != null && Obj_Rl.Count > 0)
            {
                grd.DataSource = Obj_Rl;
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