using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThietBiBosch.Database;
using ThietBiBosch.Helpers;

namespace ThietBiBosch.Controllers
{
    [GetSession]
    public class BaseController : Controller
    {
        // GET: Base
        protected readonly ThietBiNoiThatEntities db = new ThietBiNoiThatEntities();
    }
}