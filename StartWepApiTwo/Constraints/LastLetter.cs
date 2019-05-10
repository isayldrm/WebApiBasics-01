using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace StartWepApiTwo.Constraints
{
    public class LastLetter : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            string paramValue = values[parameterName].ToString().ToLower();

            if (paramValue.EndsWith("a")|| paramValue.EndsWith("b") || paramValue.EndsWith("c"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}