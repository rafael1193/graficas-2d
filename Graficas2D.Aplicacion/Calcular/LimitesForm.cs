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
using System.Windows.Forms;
using Graficas2D.Control;

namespace Graficas2D.Aplicacion
{
    public partial class LimitesForm : Form
    {
        Padre padre;

        public LimitesForm()
        {
            InitializeComponent();
        }

        public LimitesForm(Padre MDIpadre)
        {
            InitializeComponent();

            padre = MDIpadre;
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            label4.Visible = true;

            ICalculadora calc = padre.ObtenerCalculadoraDelUsuario();
            double res;
            

            try
            {
                Double.TryParse(valxTextBox.Text, out res);
                calc.Variables["x"] = res;
                calc.Expresion = textBox1.Text;
                res = calc.EvaluarExpresion();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.IsNaN(res))
            {
                textBox2.Text = res.ToString();
            }
            else 
            {
                try
                {
                    if(double.IsPositiveInfinity(Convert.ToDouble(valxTextBox.Text)))
                    {
                        calc.Variables["x"] = float.MaxValue;
                    }
                    else if (double.IsNegativeInfinity(Convert.ToDouble(valxTextBox.Text)))
                    {
                        calc.Variables["x"] = float.MinValue;
                    }
                    else 
                    {
                        calc.Variables["x"] = Convert.ToSingle(valxTextBox.Text) - float.Epsilon;
                    }

                    res = Convert.ToSingle(calc.EvaluarExpresion(textBox1.Text));

                    textBox2.Text = Math.Round(res,6).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void masInfButton_Click(object sender, EventArgs e)
        {
            valxTextBox.Text = double.PositiveInfinity.ToString();
        }

        private void menosInfButton_Click(object sender, EventArgs e)
        {
            valxTextBox.Text = double.NegativeInfinity.ToString();
        }
    }
}
