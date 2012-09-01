/* Copyright (c) 2010, 2011 rafael1193
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     - Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     - Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     - Neither the name of the developers nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using Graficas2D.Control;

namespace Graficas2D.Aplicacion
{
    public partial class RPNForm : Form
    {
        Padre padre;
        Graficas2D.Control.ICalculadora calculadora;
        
        SortedList<string,double> vars;

        double ans;

        public RPNForm()
        {
            new RPNForm(null);
        }

        public RPNForm(Padre MDIPadre)
        {
        	InitializeComponent();
        	padre = MDIPadre;
        	
        	calculadora = padre.ObtenerCalculadoraDelUsuario();

        	UpdateVariableGrid();

        }
        
        private void UpdateVariableGrid()
        {
        	vars = calculadora.Variables;
        	varDataGridView.RowCount = vars.Keys.Count;
        	
        	int row = 0;
        	foreach(string nameVar in vars.Keys)
        	{
        		varDataGridView.Rows[row].Cells[0].Value = nameVar;
        		varDataGridView.Rows[row].Cells[1].Value = vars[nameVar];
        		
        		row++;
        	}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //calculadora = padre.ObtenerCalculadoraDelUsuario();
                //calculadora.EliminarVariable("x");
                //calculadora.EliminarVariable("t");

                calculadora.ModificarVariable("ans", ans);

                double num = calculadora.EvaluarExpresion(textBox1.Text);

                ans = num;

                richTextBox1.Text = "<: " + textBox1.Text + '\n' + richTextBox1.Text;
                richTextBox1.Text = ":> " + (num).ToString() + '\n' + richTextBox1.Text;
                
                UpdateVariableGrid();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
            }

            textBox1.Focus();
            textBox1.SelectAll();

            //try
            //{
            //    double num = calc.EvaluarExpresion(textBox1.Text);

            //    richTextBox1.Text = textBox1.Text + '\n' + richTextBox1.Text;
            //    richTextBox1.Text = ">>>" + num.ToString() + '\n' + richTextBox1.Text;
            //}
            //catch (Exception ex)
            //{
            //    errorProvider1.SetError(textBox1, ex.Message);
            //}

            //textBox1.Focus();
            //textBox1.SelectAll();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            errorProvider1.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(this, new EventArgs());
            }
        }
	
		void VarDataGridViewCellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
		{
			string nameVar = varDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
			double oldValue = double.Parse(varDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
			try
			{
				vars[nameVar] = double.Parse(varDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
			}
			catch (Exception ex)
			{
				vars[nameVar] = oldValue;
				varDataGridView.Rows[e.RowIndex].Cells[1].Value = oldValue;
			}
		}
    }
}
