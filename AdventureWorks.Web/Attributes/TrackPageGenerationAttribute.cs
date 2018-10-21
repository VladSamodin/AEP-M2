using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Web.Attributes
{
    public class TrackPageGenerationAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var path = filterContext.HttpContext.Request.Path;
            if (filterContext.RouteData.Values.ContainsKey("id"))
            {
                new TelemetryClient().TrackEvent($"{path} was generated", new Dictionary<string, string> { { "id", filterContext.RouteData.Values["id"].ToString() } });
            }
            else
            {
                new TelemetryClient().TrackEvent($"{path} was generated");
            }
        }
    }
}