using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using SitecoreDev.Feature.Tasks.Models;

namespace SitecoreDev.Feature.Tasks.Controllers
{
    public class TasksController : Controller
    {

        // GET api/<controller>
        public ActionResult GetTask ()
        {
            return View();
        }

      
    }
}