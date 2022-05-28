using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ApplicantManagementSystem
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ActionSessionStateAttribute :Attribute
    {
        public SessionStateBehavior Behavior { get; private set; }
        public ActionSessionStateAttribute(SessionStateBehavior behavior)
        {
            this.Behavior = behavior;
        }
    }
}