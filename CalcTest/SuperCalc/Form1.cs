using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalcLibrary;

namespace SuperCalc
{
    public partial class Form1 : Form
    {
        private class OperationBeauty
        {
            public CalcLibrary.IOperation Operation { get; set; }
            public string Name { get; set; }
            public OperationBeauty(CalcLibrary.IOperation operation)
            {
                Operation = operation;
                var type = operation.GetType();
                Name = $"{type.Name}.{operation.Name}";
            }
        }
        private CalcLibrary.Calc Calc { get; set; }
        public Form1()
        {
            InitializeComponent();
            Calc = new CalcLibrary.Calc();

            cbOper.DataSource = Calc.Operations.Select(o => new OperationBeauty(o)).ToList();
            cbOper.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lResult.Text = "";

            var operB = cbOper.SelectedItem as OperationBeauty;
            var oper = operB.Operation is IOperationArgs;

            object result = null;

            var moreArgs = cbOper.SelectedItem is CalcLibrary.IOperationArgs;

            var args = new List<object>();

            var x = "";
            var y = "";

            if (moreArgs)
            {
                lInterface.Text = "IOperationArgs";
                args.AddRange(tbMore.Text.Split(new char[] { ' ' }));
                try
                {
                    result = Calc.Execute(cbOper.SelectedItem as CalcLibrary.IOperationArgs, args.ToArray());
                }
                catch (DivideByZeroException ex)
                {
                    lResult.Text = $"Error : {ex.Message}";
                }
                catch (Exception ex)
                {
                    lResult.Text = $"Error : {ex.Message}";
                }
                if (result != null)
                {
                    if (moreArgs)
                        lResult.Text = $"{oper}( args ( {tbMore.Text} ) ) = {result}";
                    else
                        lResult.Text = $"{x} {oper} {y} = {result}";
                }
            }
            else
            {
                lInterface.Text = "IOperation";
                x = tbX.Text;
                y = tbY.Text;
                args.Add(x);
                args.Add(y);
                try
                {
                    result = result = Calc.Execute(cbOper.SelectedItem as CalcLibrary.IOperation, args.ToArray());
                }
                catch (DivideByZeroException ex)
                {
                    lResult.Text = $"Error : {ex.Message}";
                }
                catch (Exception ex)
                {
                    lResult.Text = $"Error : {ex.Message}";
                }
                if (result != null)
                {
                    if (moreArgs)
                        lResult.Text = $"{oper}( args ( {tbMore.Text} ) ) = {result}";
                    else
                        lResult.Text = $"{x} {oper} {y} = {result}";
                }
            }
        }

        private void cbOper_SelectedIndexChanged(object sender, EventArgs e)
        {
            var moreArgs =  cbOper.SelectedItem is CalcLibrary.IOperationArgs;
            
            panTwoArgs.Visible = !moreArgs;
            panMoreArgs.Visible = moreArgs;
        }
    }
}
