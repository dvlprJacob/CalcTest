using CalcLibrary;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SuperCalc
{
    public partial class Form1 : Form
    {

        private class OperationBeauty
        {
            public OperationBeauty(IOperation operation)
            {
                Operation = operation;

                var type = operation.GetType();
                
                Name = $"{type.Name}.{operation.Name}";
            }

            public IOperation Operation { get; set; }

            public string Name { get; set; }
        }

        private Calc Calc { get; set; }

        public Form1()
        {
            InitializeComponent();
            Calc = new Calc();

            cbOper.DataSource = Calc.Operations.Select(o => new OperationBeauty(o)).ToList();
            cbOper.DisplayMember = "Name";   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lResult.Text = "";
            
            object result = null;

            var operB = cbOper.SelectedItem as OperationBeauty;

            var oper = operB.Operation;

            var moreArgs = oper is IOperationArgs;

            var args = new List<object>();

            if (moreArgs)
            {
                // "1 2 3" => new string [] {"1", "2", "3"}
                args.AddRange(tbMore.Text.Split(' '));
            }
            else
            {
                var x = tbX.Text;
                var y = tbY.Text;
                args.Add(x);
                args.Add(y);
            }

            try
            {
                result = Calc.Execute(oper, args.ToArray());
            }
            catch (DivideByZeroException ex)
            {
                lResult.Text = $"DivideByZero: {ex.Message}";
            }
            catch (Exception ex)
            {
                lResult.Text = $"Error: {ex.Message}";
            }

            if (result != null)
            {
                lResult.Text = $"{result}";
            }
        }

        private void cbOper_SelectedIndexChanged(object sender, EventArgs e)
        {
            var operB = cbOper.SelectedItem as OperationBeauty;
            var moreArgs = operB.Operation is IOperationArgs;

            panTwoArgs.Visible = !moreArgs;
            panMoreArgs.Visible = moreArgs;
        }

        private void cbOper_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var item = (cbOper.Items[e.Index] as OperationBeauty);
            Brush brush = item.Operation is IOperationArgs ? Brushes.Green : Brushes.Black;
            e.Graphics.DrawString(item.Name, e.Font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}
