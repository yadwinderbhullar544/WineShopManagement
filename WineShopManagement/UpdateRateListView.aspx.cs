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
    public partial class UpdateRateListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RateListFill();
                RateList_Fill();
            }
        }

        private void RateListFill()
        {
            RateListBiz Obj_RateList = new RateListBiz();
            List<RateList> Obj_RateList_ID = Obj_RateList.GetRateLists();
            if (Obj_RateList_ID != null && Obj_RateList_ID.Count > 0)
            {
                for (int i = 0; i < Obj_RateList_ID.Count; i++)
                {
                    ddl_RateList.Items.Add(Obj_RateList_ID[i].ID.ToString());
                }
                ddl_RateList.Items.Insert(0, new ListItem("Select Price", " "));
            }
            else
            {
                ddl_RateList.Items.Clear();
            }
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            RateList Obj_RateList = new RateList
            {
                ID = Convert.ToInt32(ddl_RateList.SelectedValue),
                Price = Convert.ToDecimal(txtPrice.Text),

            };
            RateListBiz.UpdateRateList(Obj_RateList);
            RateList_Fill();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            RateListBiz.DeleteRateList(ddl_RateList.SelectedValue);
            RateList_Fill();
        }

        protected void ddl_Price_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<RateList> Obj_Price = RateListBiz.GetRateListDetails(ddl_RateList.SelectedValue);
            if (Obj_Price != null && Obj_Price.Count > 0)
            {
                for (int i = 0; i < Obj_Price.Count; i++)
                {
                    txtPrice.Text = Convert.ToString(Obj_Price[i].Price);
                }
            }
        }
    }
}