using AspNetDesign.Repository.NHibernat.SessionStorage;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Repository.NHibernat
{
    public static class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        private static void Init()
        {
            Configuration config = new Configuration();
            config.AddAssembly("AspNetDesign.Repository.NHibernat");

            log4net.Config.XmlConfigurator.Configure();
            config.Configure();

            _sessionFactory = config.BuildSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                Init();
            }
            return _sessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();
            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }
            return currentSession;
        }
    }
}
