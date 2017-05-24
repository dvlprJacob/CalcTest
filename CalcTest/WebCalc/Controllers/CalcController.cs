using CalcLibrary;
using DBModel.Helpers;
using DBModel.Managers;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebCalc.Managers;
using WebCalc.Models;

namespace WebCalc.Controllers
{
    [Authorize]
    public class CalcController : Controller
    {
        #region Private Members

        private Calc Calc { get; set; }

        private IEnumerable<SelectListItem> OperationList { get; set; }

        private IOperationResultRepository OperationResultRepository { get; set; }

        private IUserRepository UserRepository { get; set; }

        #endregion

        public CalcController()
        {
            Calc = new Calc(@"C:\Users\Jacob\Desktop\Elma\Tasks\CalcTest\WebCalc\bin\");
            OperationList = Calc.Operations.Select(o => new SelectListItem() { Text = $"{o.GetType().Name}.{o.Name}", Value = $"{o.GetType().Name}.{o.Name}" });

            //entity frmwrk
            //var calcContext = new CalcContext();
            //OperationResultRepository = new EFOperResultRepository(calcContext);
            //UserRepository = new UserRepository(calcContext);

            //NHibernate
            OperationResultRepository = new NHOperResultRepository();
            UserRepository = new NHUserRepository();


        }

        private User GetCurrentUser()
        {
            return UserRepository.GetAll().FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
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
            var operResults = OperationResultRepository.GetAll();

            var oldResult = operResults.FirstOrDefault(
                op => op.OperationName == model.Operation && op.Arguments == model.InputData.Trim()
            );

            if (oldResult != null)
            {
                model.Result = $"Это уже вычислял {oldResult.Iniciator?.Name}  {oldResult.ExecutionDate}(заняло {oldResult.ExecutionTime} ms.) и получили {oldResult.Result}";
            }
            else
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                var names = model.Operation.Split('.');
                var opers = Calc.Operations.Where(o => o.Name == names[1]);
                var oper = opers.FirstOrDefault(o => o.GetType().Name == names[0]);
                var result = Calc.Execute(oper, model.InputData.Trim().Split(' '));
                Thread.Sleep(new Random().Next(1, 100));
                stopWatch.Stop();

                model.Result = $"{result}";

                var operResult = new OperationResult()
                {
                    OperationName = model.Operation,
                    Result = result as double?,
                    Arguments = model.InputData.Trim(),
                    ExecutionTime = stopWatch.ElapsedMilliseconds * 10,
                    ExecutionDate = DateTime.Now,
                    Iniciator = GetCurrentUser()
                };

                OperationResultRepository.Save(operResult);
            }

            model.Operations = OperationList;

            return View(model);
        }


        public ActionResult History(string oper)
        {
            ViewBag.TopOperations = OperationResultRepository.GetTop(2);
            var operations = !string.IsNullOrWhiteSpace(oper)
               ? OperationResultRepository.GetAll(true).Where(o => o.OperationName == oper)
                : OperationResultRepository.GetAll(true);

            return View(operations);
        }
    }
}