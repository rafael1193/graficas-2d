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
using Graficas2D.Control;

namespace Graficas2D.Aplicacion
{
    public partial class RPNForm : Form
    {
        CalculadoraRPN calc = new CalculadoraRPN();
        Padre padre;
        Graficas2D.Control.ICalculadora calculadora;

        double ans;

        public RPNForm()
        {
            InitializeComponent();
        }

        public RPNForm(Padre MDIPadre)
        {
            InitializeComponent();
            padre = MDIPadre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                calculadora = padre.ObtenerCalculadoraDelUsuario();
                calculadora.EliminarVariable("x");
                calculadora.EliminarVariable("t");

                calculadora.ModificarVariable("ans", ans);

                double num = calculadora.EvaluarExpresion(textBox1.Text);

                ans = num;

                richTextBox1.Text = textBox1.Text + '\n' + richTextBox1.Text;
                richTextBox1.Text = "-> " + (Math.Round(num,9)).ToString() + '\n' + richTextBox1.Text;
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

        private void RPNForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            string a = "La Notación Polaca Inversa,(en inglés, Reverse polish notation, o RPN), es un método algebraico alternativo de introducción de datos. A diferencia de la notación algebraica, en la notación polaca inversa primero están los operandos y después viene el operador que va a realizar los cálculos sobre ellos. Este tipo de notación no necesitan usar paréntesis para indicar el orden de las operaciones.\n";
            string b = "\nEjemplos:\n";
            string c = "  5 1 2 + 4 * + 3 - = 5+((1+2)*4)-3\n";
            string d = "  4 3 + 2 raiz == √(4+3)\n";
            string f = "\nOperadores:\n";
            string f1 = " x y + = x+y\n";
            string f2 = " x y - = x-y\n";
            string f3 = " x y * = x*y\n";
            string f4 = " x y / = x/y\n";
            string f5 = " x - = -x\n";
            string g = " x sen = sin(x)\n";
            string h = " x cos = cos(x)\n";
            string i = " x tan = tan(x)\n";
            string j = " x asen = asin(x)\n";
            string k = " x acos = acos(x)\n";
            string l = " x atan = atan(x)\n";
            string m = " x y ^ = x^y\n";
            string n = " x y raiz = (y)√(x)\n";
            string o = " x raiz2 = √(x)\n";
            string p = " x raiz3 = (3)√(x)\n";
            string q = " x y log = log(y)de(x)\n";
            string r = " x log10 = log(10)de(x)\n";
            string r2 = " x abs = abs(x)\n";
            string s = " pi = constante π (3,1415926...)\n";
            string t = " e = constante e (2,7182818...)\n";
            string z = " ant = Ans (resultado anterior)\n";

            MessageBox.Show(a + b + c + d + f + f1 + f2 + f3 + f4 + f5 + g + h + i + j + k + l + m + n + o + p + q + r + r2 + s + t + z);

            e.Cancel = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
