using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalc
{
    public partial class Form1 : Form
    {
        private CalcLibrary.Calc Calc { get; set; }
        public Form1()
        {
            InitializeComponent();
            Calc = new CalcLibrary.Calc();

            //cbOper.Items.AddRange(Calc.Operations.Select(o => o.Name).ToArray());

            cbOper.DataSource = Calc.Operations;
            cbOper.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lResult.Text = "";

            var oper = cbOper.Text;
            object result = null;

            var moreArgs = cbOper.SelectedItem is CalcLibrary.IOperationArgs;

            var args = new List<object>();

            var x = "";
            var y = "";

            if (moreArgs)
            {
                args.AddRange(tbMore.Text.Split(new char[] { ' ' }));
            }
            else
            {
                x = tbX.Text;
                y = tbY.Text;
                args.Add(x);
                args.Add(y);
            }

            try
            {
                result = Calc.Execute(oper, args.ToArray());
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
                tbMore.ResetText();
                tbX.ResetText();
                tbY.ResetText();
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
