using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalcLibrary;

namespace WebCalc.Models
{
    public class OperationViewModel
    {
        //public IOperation Operation { get; set; }
        public string Operation { get; set; }
        public string InputData { get; set; }
        public string Result { get; set; }

    }
}