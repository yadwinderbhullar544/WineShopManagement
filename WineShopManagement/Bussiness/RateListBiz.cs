using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineShopManagement.Data;

namespace WineShopManagement.Bussiness
{
    public class RateListBiz
    {
        WineShopEntities _db = new WineShopEntities();
        public List<RateList> GetRateLists()//This is RateLists list method
        {
            try
            {
                List<RateList> obj_RateList = null;
                obj_RateList = (from o in _db.RateLists select o).ToList();
                return obj_RateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveRateLists(RateList Obj_RateList_Save)//This is Add method.
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    db.RateLists.Add(Obj_RateList_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<RateList> GetRateListDetails(string selectedValue)
        {
            try
            {
                List<RateList> Obj_RateList_Detail = null;
                using (WineShopEntities db = new WineShopEntities())
                {
                    Obj_RateList_Detail = (from c in db.RateLists where c.ID.ToString() == selectedValue select c).ToList();
                }
                return Obj_RateList_Detail
;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateRateList(RateList Obj_RateList_Update)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    RateList c = db.RateLists.SingleOrDefault(x => x.ID == Obj_RateList_Update.ID);
                    c.Price = Obj_RateList_Update.Price;
                    db.SaveChanges();
                    return Obj_RateList_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteRateList(string Obj_RateList_Delete)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    RateList c = db.RateLists.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_RateList_Delete.Trim());
                    if (c != null)
                    {
                        db.RateLists.Remove(c);
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