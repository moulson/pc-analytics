using MonitorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MonitorApp
{
    public class MetricController : ApiController
    {
        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }

        [HttpGet]
        public IHttpActionResult Index()
        {
            var metric = new ComputerMetric();
            return Json(metric);
        }
    }
}
