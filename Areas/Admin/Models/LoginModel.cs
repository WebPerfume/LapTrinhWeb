using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LapTrinhWeb.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        public string Matkhau { get; set; }
        public bool Remember { get; set; }
    }
}