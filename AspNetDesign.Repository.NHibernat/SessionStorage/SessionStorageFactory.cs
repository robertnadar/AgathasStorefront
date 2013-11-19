﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AspNetDesign.Repository.NHibernat.SessionStorage
{
    public class SessionStorageFactory
    {
        private static ISessionStorageContainer _nhSessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_nhSessionStorageContainer == null)
            {
                if (HttpContext.Current == null)
                {
                    _nhSessionStorageContainer = new ThreadSessionStorageContainer();
                }
                else
                {
                    _nhSessionStorageContainer = new HttpSessionContainer();
                }
            }
            return _nhSessionStorageContainer;
        }
    }
}
