using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;
using CalcLibrary;
using WebCalc.Managers;
using System.Diagnostics;
using System.Threading;
using WebCalc.Helpers;

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
        // History
        public ViewResult OperationHistory()
        {
            var model = new OperationViewModel(OperationList);

            // Загрузим историю операцийп при первоначальной загрузке страницы
            model.OperationHistory = OperationResultRepository.GetAll();

            //Redirect("Shared/EditorTemplates/OperationHistory");
            return View(model);
        }
        // GET: Calc
        public ActionResult Index()
        {
            var model = new OperationViewModel(OperationList);

            // Загрузим историю операцийп при первоначальной загрузке страницы
            model.OperationHistory = OperationResultRepository.GetAll();

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(OperationViewModel model)
        {
            #region Поиск в базе
            var operResults = OperationResultRepository.GetAll();
            #endregion

            var oldResult = operResults.FirstOrDefault(
                op => op.OperationName == model.Operation
                && op.Arguments == model.InputData);

            if (oldResult != null)
            {
                model.Result = $"Это уже вычисляли {oldResult.ExecutionDate}( заняло {oldResult.ExecutionTime} ms ) и получили {oldResult.Result}";
            }
            else
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                var names = model.Operation.Split('.');
                var opers = Calc.Operations.Where(o => o.Name == names[1]);
                var oper = opers.FirstOrDefault(o => o.GetType().Name == names[0]);
                var result = Calc.Execute(oper, model.InputData.Split(' '));
                stopWatch.Stop();

                model.Result = $"{result}";

                var operResult = new OperationResult()
                {
                    OperationName = model.Operation,
                    Result = result as double?,
                    Arguments = model.InputData.Trim(),
                    ExecutionTime = stopWatch.ElapsedMilliseconds * 10,
                    ExecutionDate = DateTime.Now
                };
                OperationResultRepository.Save(operResult);
            }
            model.Operations = OperationList;
            return View(model);
        }
    }
}