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
    public partial class UpdateCustomerView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WineFill();
                RateListFill();
                Customer_Fill();
                CustomerFill();
            }
        }
        private void CustomerFill()
        {
            CustomerBiz Obj_Customer = new CustomerBiz();
            List<Customer> Obj_Customer_ID = Obj_Customer.GetCustomers();

            if (Obj_Customer_ID != null && Obj_Customer_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Customer_ID.Count; i++)
                {
                    ddl_Customer.Items.Add(Obj_Customer_ID[i].ID.ToString());
                }
                ddl_Wine.Items.Insert(0, new ListItem("Select Customer", " "));
            }
            else
            {
                ddl_Customer.Items.Clear();
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            Customer Obj_Ins_Cs = new Customer
            {
                ID = Convert.ToInt32(ddl_Customer.SelectedValue),
                Name = txtName.Text,
                Age = txtAge.Text,
                Email = txtEmail.Text,
                
                WineID = Convert.ToInt32(ddl_Wine.SelectedValue),
                RateListID = Convert.ToInt32(ddl_RateList.SelectedValue),
            };
            CustomerBiz.UpdateCustomer(Obj_Ins_Cs);
            Customer_Fill();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            CustomerBiz.DeleteCustomer(ddl_Customer.SelectedValue);
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

        protected void ddl_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Customer> Obj_Customer = CustomerBiz.GetCustomerDetails(ddl_Customer.SelectedValue);
            if (Obj_Customer != null && Obj_Customer.Count > 0)
            {
                for (int i = 0; i < Obj_Customer.Count; i++)
                {
                    txtName.Text = Convert.ToString(Obj_Customer[i].Name);
                    txtAge.Text = Convert.ToString(Obj_Customer[i].Age);
                    txtEmail.Text = Convert.ToString(Obj_Customer[i].Email);
                    ddl_Wine.SelectedValue = Convert.ToString(Obj_Customer[i].WineID);
                    ddl_RateList.SelectedValue = Convert.ToString(Obj_Customer[i].RateListID);

                }
            }
        }
    }
}