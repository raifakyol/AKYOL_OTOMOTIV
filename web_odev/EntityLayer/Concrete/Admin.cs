﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

       
        public string Admin_UserName { get; set; }
       
        public string Password { get; set; }
       
        public string AdminRole { get; set; }
       
    }
}
