using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class ActiveSession
    {
        public static ActiveSession Current { get {
          ActiveSession session = (ActiveSession)HttpContext.Current.Session["ActiveSession"];
          if(session == null)
                {
                    session = new ActiveSession();
                    HttpContext.Current.Session["ActiveSession"] = session;
                }
                return session;
        } }

        public User ActiveUser { get; set; }
    }
}