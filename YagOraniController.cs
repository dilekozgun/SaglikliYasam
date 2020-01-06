using Asim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asim.Controllers
{
    [Authorize]
    public class YagOraniController : Controller
    {
        // GET: YagOrani
      
        [HttpGet]
        public ActionResult YagOran()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YagOran(YagOrani model, string command)
        {
            if (command == "kadın")
            {
                model.Oran = (model.Boy) * (model.Kalca) ;
                model.d = model.Oran*model.Bel ;
                model.e = model.d * model.Boyun;
                model.f =model.e*0.0000831470;
                model.g = model.f / 100;
            }
            if (command == "erkek")
            {
                model.Oran = (model.Boy) * (model.Kalca);
                model.d = model.Oran * model.Bel;
                model.e = model.d * model.Boyun;
                model.f = model.e * 0.0000831470;
                model.i = model.f / 100;
                model.g = model.i + 5;
                


            }
            return View(model);

        }
    }
}