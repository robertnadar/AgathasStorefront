using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetDesign.Repository.NHibernat.SessionStorage
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        private readonly Hashtable _nhSession = new Hashtable();
        public ISession GetCurrentSession()
        {
            ISession nhSession = null;
            if(_nhSession.Contains(GetThreadName()))
            {
                nhSession = (ISession)_nhSession[GetThreadName()];
            }
            return nhSession;
        }

        private string  GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }

        public void Store(ISession session)
        {
            if (_nhSession.Contains(GetThreadName()))
            {
                _nhSession[GetThreadName()] = session;
            }
            else {
                _nhSession.Add(GetThreadName(), session);
            }
        }
    }
}
