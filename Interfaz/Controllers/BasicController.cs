﻿using Microsoft.AspNetCore.Mvc;
using NHibernate;
using DsmGen.Infraestructure.CP;
using DsmGen.Infraestructure.Repository.Dominio_dsm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaz.Controllers
{
    public class BasicController:Controller
    {
        private ISession sessionInside;


        protected SessionCPNHibernate session;

        protected BasicController()
        {
        }

        protected void SessionInitialize()
        {
            if (session == null)
            {
                sessionInside = NHibernateHelper.OpenSession();
                session = new SessionCPNHibernate(sessionInside);
            }
        }


        protected void SessionClose()
        {
            if (session != null && sessionInside.IsOpen)
            {
                sessionInside.Close();
                sessionInside.Dispose();
                session = null;
            }
        }
    }
}


