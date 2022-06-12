using Lord_of_the_rings.Data;
using Lord_of_the_rings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lord_of_the_rings.Controllers
{
    public class LOTRController : Controller
    {
        // GET: LOTR
        public ActionResult Index()
        {
            List<LOTRModel> LOTR = new List<LOTRModel>();
            LOTRDATA LOTRData = new LOTRDATA();

            LOTR = LOTRData.FetchAll();

            return View("Index",LOTR);
        }

        public ActionResult Details(int id)
        {
            LOTRDATA LOTRDAO = new LOTRDATA();
            LOTRModel LOTR = LOTRDAO.FetchOne(id);

            return View("Details", LOTR);
        }


    }
}