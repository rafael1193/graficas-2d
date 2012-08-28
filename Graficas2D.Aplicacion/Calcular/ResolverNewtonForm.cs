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
using System.Drawing;
using System.Windows.Forms;
using Graficas2D.Control;

namespace Graficas2D.Aplicacion
{
    public partial class ResolverNewtonForm : Form
    {

        Padre padre;

        public ResolverNewtonForm()
        {
            InitializeComponent();
            graficarButton.Visible = false;
            graficarButton.Enabled = false;
        }

        public ResolverNewtonForm(Padre MDIPadre)
        {
            InitializeComponent();

            padre = MDIPadre;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double error;
            string ecuacion = "(" + ecuacionATextBox.Text + ")-(" + ecuacionBTextBox.Text + ")";
            double valInicial = float.Epsilon;
            ICalculadora calc = padre.ObtenerCalculadoraDelUsuario();
            if (calc.ComprobarValidez(textBox1.Text))
            {
                try
                {
                    valInicial = padre.ObtenerCalculadoraDelUsuario().EvaluarExpresion(textBox1.Text);
                    resultadoTextBox.Text = ((float)(ResolverEcuacionNewton(ecuacion, valInicial, new TimeSpan(0, 0, 30), out error))).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //if (!double.IsNaN(error))
            //{
            //    errorTextBox.Text = error.ToString();
            //}
            //else
            //{
            //    errorTextBox.Text = "0";
            //}
        }

        public double ResolverEcuacionNewton(string ecuacion, double valorInicial, TimeSpan tiempoLimite, out double error)
        {
            double resultado = double.Epsilon;
            double resultadoAnterior = valorInicial;
            double derivada = 1;
            DateTime tInicio;

            ICalculadora calc = padre.ObtenerCalculadoraDelUsuario();

            tInicio = DateTime.Now;
            try
            {
                while (resultado != resultadoAnterior)
                {
                    resultadoAnterior = resultado;
                    calc.Variables["x"] = resultadoAnterior;
                    derivada = calc.EvaluarDerivada1(ecuacion, "x");
                    if (derivada != 0)
                    {
                        resultado = calc.Variables["x"] - (calc.EvaluarExpresion(ecuacion) / derivada);
                    }
                    else
                    {
                        derivada = double.Epsilon;
                    }
                    if (DateTime.Now - tInicio > tiempoLimite)
                    {
                        resultado = double.NaN;
                    }

                    if (double.IsNaN(resultado))
                    {
                        throw new Exception("No se ha encuentrado ninguna solución. Prueba a buscar una solución manualmente mirando la gráfica");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                error = Math.Abs(resultado - resultadoAnterior) / Math.Abs(resultado);
            }

            return resultado;
        }

        private void graficarButton_Click(object sender, EventArgs e)
        {
            ICalculadora calc = padre.ObtenerCalculadoraDelUsuario();
            try
            {
                calc.EvaluarExpresion(ecuacionATextBox.Text);
                calc.EvaluarExpresion(ecuacionBTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Funcion2D funA = new Funcion2D("x", ecuacionATextBox.Text, new Intervalo(-20, 20), 50, Color.Blue, 2f, "y = " + ecuacionATextBox.Text, true, true, padre.ObtenerCalculadoraDelUsuario(), Funcion2D.ObtenerPuntos.Normal);
            Funcion2D funB = new Funcion2D("x", ecuacionBTextBox.Text, new Intervalo(-20, 20), 50, Color.Blue, 2f, "y = " + ecuacionBTextBox.Text, true, true, padre.ObtenerCalculadoraDelUsuario(), Funcion2D.ObtenerPuntos.Normal);

            Grafica2Form graf = new Grafica2Form(funA, funB);
            padre.NuevaVentana(graf);
        }
    }
}
