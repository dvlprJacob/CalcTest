using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;
using CalcLibrary;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(OperationViewModel model)
        {
            var calc = new CalcLibrary.Calc(@"C:\Users\Jacob\Desktop\Elma\Tasks\CalcTest\WebCalc\bin\");

            model.GetOperations();
            
            var result = calc.Execute(model.Operation, model.InputData.Split(' '));

            model.Result = $"{result}";
            

            return View(model);
        }
    }
}