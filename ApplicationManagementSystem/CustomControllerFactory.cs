using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ApplicantManagementSystem
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return SessionStateBehavior.Default;
            }

            var actionName = requestContext.RouteData.Values["action"].ToString();
            Type typeOfRequest = requestContext.HttpContext.Request.RequestType.ToLower() == "get" ? typeof(HttpGetAttribute) : typeof(HttpPostAttribute);

            var cntMethods = controllerType.GetMethods()
                 .Where(m =>
                    m.Name == actionName &&
                    ((typeOfRequest == typeof(HttpPostAttribute) &&
                          m.CustomAttributes.Where(a => a.AttributeType == typeOfRequest).Count() > 0
                       )
                       ||
                       (typeOfRequest == typeof(HttpGetAttribute) &&
                          m.CustomAttributes.Where(a => a.AttributeType == typeof(HttpPostAttribute)).Count() == 0
                       )
                    )
                );
            MethodInfo actionMethodInfo = actionMethodInfo = cntMethods != null && cntMethods.Count() == 1 ? cntMethods.ElementAt(0) : null;
            //MethodInfo actionMethodInfo;
            //actionMethodInfo = controllerType.GetMethod(actionName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (actionMethodInfo != null)
            {
                var actionSessionStateAttr = actionMethodInfo.GetCustomAttributes(typeof(ActionSessionStateAttribute), false)
                                    .OfType<ActionSessionStateAttribute>()
                                    .FirstOrDefault();

                if (actionSessionStateAttr != null)
                {
                    return actionSessionStateAttr.Behavior;
                }
            }
            return base.GetControllerSessionBehavior(requestContext, controllerType);
        }
    }
}