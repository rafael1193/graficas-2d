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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Graficas2D.Aplicacion.Properties;
using Graficas2D.Control;

namespace Graficas2D.Aplicacion
{
    public partial class OpcionesForm : Form
    {
        Padre padre;


        public OpcionesForm(Padre MDIpadre)
        {
            InitializeComponent();
            padre = MDIpadre;

            CalculadoraInfija calc = (Graficas2D.Control.CalculadoraInfija)padre.ObtenerCalculadoraDelUsuario();

            //padre.ConstantesCalculadora = calc.

            //foreach (KeyValuePair<string,double> pair in padre.ConstantesCalculadora)
            //{
            //    constantesListBox.Items.Add((object)pair);
            //}
        }

        private void aplicarButton_Click(object sender, EventArgs e)
        {
            GuardarPreferencias();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            GuardarPreferencias();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CargarPreferencias()
        {
            barraIconosCheckBox.Checked = padre.VerBarraIconos;
        }

        private void GuardarPreferencias()
        {
            padre.VerBarraIconos = barraIconosCheckBox.Checked;
        }

        private void OpcionesForm_Load(object sender, EventArgs e)
        {
            CargarPreferencias();
        }

        private void constantesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string,double> item  = (KeyValuePair<string,double>)constantesListBox.SelectedItem;

            modificarConstanteTextBox.Text = item.Value.ToString();
        }
    }
}
