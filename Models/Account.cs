using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LapTrinhWeb.Models;

namespace LapTrinhWeb.Areas.Admin.Models
{

    public class Account
    {
        private QLBHEntities3 db;
        public Account()
        {
            db = new QLBHEntities3();
        }
        public bool Login(string user, string pass)
        {

            var res = db.Admins.Where(p => p.Email.Equals(user) && p.Pass.Equals(pass)).Count() == 1 ? true : false;
            return res;
        }
    }
}