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
    public partial class UpdateWineView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WineFill();
                Wine_Fill();
            }
        }

        private void WineFill()
        {
            WineBiz Obj_Wine = new WineBiz();
            List<Wine> Obj_Wine_ID = Obj_Wine.GetWines();

            if (Obj_Wine_ID != null && Obj_Wine_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Wine_ID.Count; i++)
                {
                    ddl_Wine.Items.Add(Obj_Wine_ID[i].ID.ToString());
                }
                ddl_Wine.Items.Insert(0, new ListItem("Select Wine", " "));
            }
            else
            {
                ddl_Wine.Items.Clear();
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            WineBiz.DeleteWine(ddl_Wine.SelectedValue);
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
        protected void Submit_Click(object sender, EventArgs e)
        {
            Wine Obj_Wine = new Wine
            {
                ID = Convert.ToInt32(ddl_Wine.SelectedValue),
                Name = txtName.Text,

            };
            WineBiz.UpdateWine(Obj_Wine);
            Wine_Fill();
        }

        protected void ddl_Wine_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Wine> Obj_Wine = WineBiz.GetWineDetails(ddl_Wine.SelectedValue);
            if (Obj_Wine != null && Obj_Wine.Count > 0)
            {
                for (int i = 0; i < Obj_Wine.Count; i++)
                {
                    txtName.Text = Obj_Wine[i].Name;
                }
            }
        }
    }
}