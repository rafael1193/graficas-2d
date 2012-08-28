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
    public partial class Agregar2Form : Form
    {
        Funcion2D funcionFinal;

        Grafica2Form formGrafica;

        public Funcion2D FuncionCreada
        {
            get { return funcionFinal; }
        }

        public Agregar2Form(Grafica2Form formQueLlama)
        {
            InitializeComponent();

            formGrafica = formQueLlama;
        }

        private void colorPanel_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                colorPanel.BackColor = colorDialog1.Color;
            }
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
#if muParser
            int i = 0;
            int j = 0;

            if (Int32.TryParse(intervaloIniTextBox.Text, out i) && Int32.TryParse(intervaloFinTextBox.Text, out j) && j > i)
            {
                Graficas2D.Control.muParser.Parser parser = new Graficas2D.Control.muParser.Parser();
                Exception error = null;

                try
                {
                    parser.SetDecSep('.'); // default: "."
                    parser.SetArgSep(','); // default: ","
                    parser.DefineVar("t", new Graficas2D.Control.muParser.ParserVariable(200.5));
                    parser.DefineVar("x", new Graficas2D.Control.muParser.ParserVariable(200.5));
                    parser.SetExpr(funcionXTextBox.Text);
                    parser.Eval();
                }
                catch (Exception ex)
                {
                    error = ex;
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                }

                if (error == null)
                {
                    error = null;
                    try
                    {
                        parser.SetDecSep('.'); // default: "."
                        parser.SetArgSep(','); // default: ","
                        parser.DefineVar("t", new Graficas2D.Control.muParser.ParserVariable(200.5));
                        parser.DefineVar("x", new Graficas2D.Control.muParser.ParserVariable(200.5));
                        parser.SetExpr(funcionXTextBox.Text);
                        parser.Eval();
                    }
                    catch (Exception ex)
                    {
                        error = ex;
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }

                    if (error == null)
                    {
                        color = colorPanel.BackColor;
                        interv = new Intervalo(i, j);
                        ecuX = funcionXTextBox.Text;
                        ecuY = funcionYTextBox.Text;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(error.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                }
                else
                {
                    MessageBox.Show(error.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
            }
            else
            {
                MessageBox.Show("Los intervalos no están en el formato correcto.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }


#else
            float i = 0;
            float f = 0;

            ICalculadora calc = formGrafica.Padre.ObtenerCalculadoraDelUsuario();


            if (calc.ComprobarValidez(intervaloIniTextBox.Text) && calc.ComprobarValidez(intervaloFinTextBox.Text))
            {
                i = (float)calc.EvaluarExpresion(intervaloIniTextBox.Text);
                f = (float)calc.EvaluarExpresion(intervaloFinTextBox.Text);

                if (f >= i)
                {
                    try
                    {
                        calc.EvaluarExpresion(funcionXTextBox.Text);
                        calc.EvaluarExpresion(funcionYTextBox.Text);

                        funcionFinal = new Funcion2D(funcionXTextBox.Text, funcionYTextBox.Text, new Intervalo(i, f), 20, colorPanel.BackColor, (float)grosorNumericUpDown.Value, "x= " + funcionXTextBox.Text + (checkBox1.Checked ? "; y'= " : "; y= ") + funcionYTextBox.Text, true, true, formGrafica.Padre.ObtenerCalculadoraDelUsuario(), checkBox1.Checked ? new Control.MetodoCalculoDelegate(Funcion2D.ObtenerPuntos.DerivadaT) : new Control.MetodoCalculoDelegate(Funcion2D.ObtenerPuntos.Normal));
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El valor de inicio no puede ser mayor que el valor final.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Las expresiones del intervalo no son correctas.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
        }


        private void AgregarForm_Load(object sender, EventArgs e)
        {
            funcionYTextBox.Focus();
        }

        private void AgregarForm_Enter(object sender, EventArgs e)
        {
            funcionYTextBox.Focus();
        }
    }
}
