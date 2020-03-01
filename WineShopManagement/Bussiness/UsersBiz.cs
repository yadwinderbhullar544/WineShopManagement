using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineShopManagement.Data;

namespace WineShopManagement.Bussiness
{
    public class UsersBiz
    {
        WineShopEntities db = new WineShopEntities();

        public bool LoginUser(UserVM vmModel)//login method
        {
            bool isLogin = false;
            try
            {
                var record = (from a in db.Users
                              where a.Email == vmModel.Email && a.Password == vmModel.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isLogin = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isLogin;
        }
    }
}