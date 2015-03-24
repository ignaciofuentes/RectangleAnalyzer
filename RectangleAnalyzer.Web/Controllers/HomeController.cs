using RectangleAnalyzer.Core;
using RectangleAnalyzer.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RectangleAnalyzer.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRectangleAnalysis(RectanglesFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rectangle1 = new RectangleF(model.Rectangle1.X, model.Rectangle1.Y, model.Rectangle1.Width, model.Rectangle1.Height);
                var rectangle2 = new RectangleF(model.Rectangle2.X, model.Rectangle2.Y, model.Rectangle2.Width, model.Rectangle2.Height);
                
                var rectangleProcessor = new RectangleProcessor(rectangle1, rectangle2);
                return PartialView(rectangleProcessor.GetAnalysis());
            }
            else return new HttpStatusCodeResult(400);
        }
    }
}