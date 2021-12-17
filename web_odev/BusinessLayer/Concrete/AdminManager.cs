﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;
        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }
        public void AdminAdd(Admin admin)
        {
            _admindal.Insert(admin);
        }
    }
}
