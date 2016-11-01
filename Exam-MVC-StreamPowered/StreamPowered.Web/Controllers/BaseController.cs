using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    using Data;

    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Data = new StreamPoweredContext();
        }

        protected StreamPoweredContext Data { get; set; }
    }
}