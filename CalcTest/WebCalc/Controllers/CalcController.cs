using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;
using CalcLibrary;
using WebCalc.Managers;

namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {
        #region Private Members
        private Calc Calc { get; set; }

        private IEnumerable<SelectListItem> OperationList { get; set; }

        private IOperationResultRepository OperationResultRepository { get; set; }
        #endregion
        public CalcController()
        {
            Calc = new Calc(@"C:\Users\Jacob\Desktop\Elma\Tasks\CalcTest\WebCalc\bin");
            OperationList = Calc.Operations.Select(o => new SelectListItem() { Text = $"{o.GetType().Name}.{o.Name}", Value = $"{o.GetType().Name}.{o.Name}" });
            OperationResultRepository = new OperationManager();
        }
        // GET: Calc
        public ActionResult Index()
        {
            var model = new OperationViewModel(OperationList);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(OperationViewModel model)
        {
            //var calc = new CalcLibrary.Calc(@"C:\Users\Jacob\Desktop\Elma\Tasks\CalcTest\WebCalc\bin\");

            #region Поиск в базе
            var operResults = OperationResultRepository.GetAll();
            #endregion

            var names = model.Operation.Split('.');
            
            var opers = Calc.Operations.Where(o => o.Name == names[1]);
            
            var oper = opers.FirstOrDefault(o => o.GetType().Name == names[0]);

            //model.GetOperations();

            var result = Calc.Execute(oper, model.InputData.Split(' '));

            //var result = calc.Execute(model.Operation, model.InputData.Split(' '));

            model.Result = $"{result}";

            model.Operations = OperationList;


            return View(model);
        }
    }
}