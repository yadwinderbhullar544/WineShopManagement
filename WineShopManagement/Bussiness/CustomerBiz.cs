using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineShopManagement.Data;

namespace WineShopManagement.Bussiness
{
    public class CustomerBiz
    {
        WineShopEntities _db = new WineShopEntities();
        public List<Customer> GetCustomers()//This is Customers list method
        {
            try
            {
                List<Customer> obj_Customer = null;
                obj_Customer = (from o in _db.Customers select o).ToList();
                return obj_Customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveCustomers(Customer Obj_Customer_Save)//This is Add method.
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    db.Customers.Add(Obj_Customer_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Customer> GetCustomerDetails(string selectedValue)
        {
            try
            {
                List<Customer> Obj_Customer_Detail = null;
                using (WineShopEntities db = new WineShopEntities())
                {
                    Obj_Customer_Detail = (from c in db.Customers where c.ID.ToString() == selectedValue select c).ToList();
                }
                return Obj_Customer_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateCustomer(Customer Obj_Customer_Update)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    Customer c = db.Customers.SingleOrDefault(x => x.ID == Obj_Customer_Update.ID);
                    c.Name = Obj_Customer_Update.Name;
                    c.Age = Obj_Customer_Update.Age;
                    c.Email = Obj_Customer_Update.Email;
                    c.RateListID = Obj_Customer_Update.RateListID;
                    c.WineID = Obj_Customer_Update.WineID;
                    db.SaveChanges();
                    return Obj_Customer_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteCustomer(string Obj_Customer_Delete)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    Customer c = db.Customers.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Customer_Delete.Trim());
                    if (c != null)
                    {
                        db.Customers.Remove(c);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}