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
    public partial class DerivadasForm : Form
    {
        Padre padre;
        double pendiente;
        double punto;
        double valor;

        public DerivadasForm()
        {
            InitializeComponent();
            graficarButton.Visible = false;
            graficarButton.Enabled = false;
        }

        public DerivadasForm(Padre MDIPadre)
        {
            InitializeComponent();

            padre = MDIPadre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double res;
            ICalculadora calc = padre.ObtenerCalculadoraDelUsuario();

            if (!calc.Variables.ContainsKey("x"))
            {
                calc.DefinirVariable("x", calc.EvaluarExpresion(textBox2.Text));
                punto = calc.Variables["x"];
            }
            else
            {
                calc.Variables["x"] = calc.EvaluarExpresion(textBox2.Text);
                punto = calc.Variables["x"];
            }

            valor = calc.EvaluarExpresion(textBox1.Text);
            res = calc.EvaluarDerivada1(textBox1.Text, "x");
            pendiente = res;


            if (!double.IsInfinity(res) && !double.IsNaN(res))
            {
                textBox3.Text = Math.Round(res, 6).ToString();
            }
            else
            {
                if (double.IsNaN(res))
                {
                    textBox3.Text = "∄ f(x) → ∄ f'(x)";

                }
                else
                {
                    textBox3.Text = "∄ f'(x)";
                }
            }

            //float res;
            //res = Convert.ToSingle(CalcularDerivada(textBox1.Text, double.Parse(textBox2.Text)));

            //resultado = res;
            //punto = Convert.ToDouble(textBox2.Text);

            //if (!float.IsInfinity(res) && !float.IsNaN(res))
            //{
            //    textBox3.Text = res.ToString();
            //}
            //else
            //{
            //    if (float.IsNaN(res))
            //    {
            //        textBox3.Text = "∄ f(x) → ∄ f'(x)";

            //    }
            //    else
            //    {
            //        textBox3.Text = "∄ f'(x)";
            //    }
            //}
        }

        private void graficarButton_Click(object sender, EventArgs e)
        {
            button1_Click(this, new EventArgs());

            //Graficas2DControl.FuncionSimple primitiva = new Graficas2DControl.FuncionSimple(Graficas2DControl.FuncionSimple.ObtenerPuntos(textBox1.Text, new Graficas2DControl.Intervalo(-20, 20), 50), Color.Blue, 2f, true,"y = " + textBox1.Text);
            Funcion2D primitiva = new Funcion2D("x", textBox1.Text, new Intervalo(-20, 20), 50, Color.Blue, 2f, "x = x" + "; y = " + textBox1.Text, true, true, padre.ObtenerCalculadoraDelUsuario(), Funcion2D.ObtenerPuntos.Normal);

            if (!double.IsNaN(pendiente))
            {
                double n = -(pendiente * punto) + valor;
                string textoFuncion;
                string funcion;

                if (n < 0)
                {
                    funcion = pendiente.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat) + "*x-" + Math.Abs(n).ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                    textoFuncion = Math.Round(pendiente, 6).ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat) + "*x-" + Math.Round(Math.Abs(n), 6).ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                }
                else
                {
                    funcion = pendiente.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat) + "*x+" + n.ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                    textoFuncion = Math.Round(pendiente, 6).ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat) + "*x+" + Math.Round(n, 6).ToString(System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                }
                //Graficas2DControl.FuncionSimple derivada = new Graficas2DControl.FuncionSimple(Graficas2DControl.FuncionSimple.ObtenerPuntos(textoFuncion, new Graficas2DControl.Intervalo(-20, 20), 50), Color.Red, 2f, true, "y = " + textoFuncion);
                Funcion2D derivada = new Funcion2D("x", funcion, new Intervalo(-20, 20), 50, Color.Red, 2f, "x = x" + "; y = " + textoFuncion, true, true, padre.ObtenerCalculadoraDelUsuario(), Funcion2D.ObtenerPuntos.Normal);

                Grafica2Form graf = new Grafica2Form(primitiva, derivada);
                padre.NuevaVentana(graf);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ICalculadora calc = padre.ObtenerCalculadoraDelUsuario();

            try
            {
                Funcion2D primi = new Funcion2D("x", textBox1.Text, new Intervalo(-20, 20), 50, Color.Blue, 2f, "y = " + textBox1.Text, true, true, calc, Funcion2D.ObtenerPuntos.Normal);
                Funcion2D deriv = new Funcion2D("x", textBox1.Text, new Intervalo(-20, 20), 50, Color.Red, 2f, "y' = " + textBox1.Text, true, true, calc, Funcion2D.ObtenerPuntos.DerivadaX);

                Grafica2Form graf = new Grafica2Form(padre ,primi, deriv);
                padre.NuevaVentana(graf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //            try
            //            {
            //                FuncionParametrica primitiva = new FuncionParametrica(textBox1.Text, new Intervalo(-20, 20), 50, Color.Blue, 3f, true, "y = " + textBox1.Text, true);

            //                FuncionParametrica derivada = new FuncionParametrica(textBox1.Text, new Intervalo(-20, 20), 50, Color.Red, 3f, true, "y' = " + textBox1.Text, false);
            //#if muParser
            //                Graficas2D.Control.Funciones.MetodoCalculoDelegate del = new Graficas2D.Control.Funciones.MetodoCalculoDelegate(CalcularFuncionDerivadamuParser);
            //#else
            //                Graficas2D.Control.Funciones.MetodoCalculoDelegate del = new Graficas2D.Control.Funciones.MetodoCalculoDelegate(ObtenerPuntosFuncionDerivada);
            //#endif
            //                derivada.CalcularPuntos(del, "x", textBox1.Text, new Intervalo(-20, 20), (uint)50);

            //                GraficaForm graf = new GraficaForm(primitiva, derivada);
            //                padre.NuevaVentana(graf);
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }
        }
    }
}
