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

namespace Graficas2D.Aplicacion
{
    public partial class GaussForm : Form
    {
        Padre padre;

        public GaussForm(Padre padre)
        {
            InitializeComponent();
            this.padre = padre;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = (int)numericUpDown1.Value;
            dataGridView1.ColumnCount = (int)numericUpDown1.Value + 1;
            dataGridView2.ColumnCount = (int)numericUpDown1.Value;
        }

        private void resolverButton_Click(object sender, EventArgs e)
        {
            string[,] matriz = new string[dataGridView1.RowCount, dataGridView1.ColumnCount];
            double[] resultado = new double[1];
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null)
                            dataGridView1.Rows[i].Cells[j].Value = 0;

                        matriz[i, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add();

            try
            {
                Graficas2D.Control.SistemaEcuaciones.ResolverGauss(padre.ObtenerCalculadoraDelUsuario(), matriz, out resultado);

                for (int i = 0; i < resultado.Length; i++)
                {
                    dataGridView2.Rows[0].Cells[i].Value = resultado[i].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GaussForm_Load(object sender, EventArgs e)
        {
            numericUpDown1_ValueChanged(this, new EventArgs());
            dataGridView1.Focus();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = null;
                }
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; i < dataGridView2.Columns.Count; i++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = null;
                }
            }
        }
    }
}
