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
    public partial class CustomerView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WineFill();
                RateListFill();
                Customer_Fill();
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

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerView.aspx");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            Customer Obj_Add_Customer = new Customer
            {
                Name = txtName.Text,
                Age = txtAge.Text,
                Email = txtEmail.Text,
                RateListID = Convert.ToInt32(ddl_RateList.SelectedValue),
                WineID = Convert.ToInt32(ddl_Wine.SelectedValue),
            };
            CustomerBiz.SaveCustomers(Obj_Add_Customer);
            Customer_Fill();
        }

        private void Customer_Fill()
        {
            CustomerBiz Obj_Customer = new CustomerBiz();
            List<Customer> Obj_Cs = Obj_Customer.GetCustomers();
            if (Obj_Cs != null && Obj_Cs.Count > 0)
            {
                grd.DataSource = Obj_Cs;
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