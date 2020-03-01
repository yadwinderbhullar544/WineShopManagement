using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineShopManagement.Data;

namespace WineShopManagement.Bussiness
{
    public class WineBiz
    {
        WineShopEntities _db = new WineShopEntities();
        public List<Wine> GetWines()//This is Wines list method
        {
            try
            {
                List<Wine> obj_Wine = null;
                obj_Wine = (from o in _db.Wines select o).ToList();
                return obj_Wine;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveWines(Wine Obj_Wine_Save)//This is Add method.
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    db.Wines.Add(Obj_Wine_Save);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<Wine> GetWineDetails(string selectedValue)
        {
            try
            {
                List<Wine> Obj_Wine_Detail = null;
                using (WineShopEntities db = new WineShopEntities())
                {
                    Obj_Wine_Detail = (from c in db.Wines where c.ID.ToString() == selectedValue select c).ToList();
                }
                return Obj_Wine_Detail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateWine(Wine Obj_Wine_Update)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression

                    Wine c = db.Wines.SingleOrDefault(x => x.ID == Obj_Wine_Update.ID);
                    c.Name = Obj_Wine_Update.Name;
                    db.SaveChanges();
                    return Obj_Wine_Update.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeleteWine(string Obj_Wine_Delete)
        {
            try
            {
                using (WineShopEntities db = new WineShopEntities())
                {
                    //Lambda expression
                    Wine c = db.Wines.SingleOrDefault(x => x.ID.ToString().Trim() == Obj_Wine_Delete.Trim());
                    if (c != null)
                    {
                        db.Wines.Remove(c);
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