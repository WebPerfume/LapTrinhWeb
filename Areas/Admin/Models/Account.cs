using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LapTrinhWeb.Areas.Admin.Data;

namespace LapTrinhWeb.Areas.Admin.Models
{

    public class Account
    {
        private QLBanHangDbContext db;
        public Account()
        {
            db = new QLBanHangDbContext();
        }
        public bool Login(string user, string pass)
        {
            object[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Email",user),
                new SqlParameter("@Matkhau",pass)
            };
            var res = db.Database.SqlQuery<bool>("Sp_Account_Login @Email,@Matkhau", sqlParams).SingleOrDefault();
            return res;
        }
    }
}