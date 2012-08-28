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
using System.Drawing;
using System.Windows.Forms;
using Graficas2D.Control;

namespace Graficas2D.Aplicacion
{
    public partial class Grafica2Form : Form
    {
        Padre padre;

        const int INTERVALOINICIO = -20;
        const int INTERVALOFIN = 20;
        const uint PPU = 20;
        const float GROSOR = 3f;
        readonly Color COLOR = Color.Blue;

        public Padre Padre
        {
            get { return padre; }
        }

        #region Inicio
        public Grafica2Form()
        {
            InitializeComponent();
        }

        public Grafica2Form(Padre MDIpadre)
        {
            InitializeComponent();
            padre = MDIpadre;
        }

        public Grafica2Form(params Funcion2D[] funciones)
        {
            InitializeComponent();
            this.Text = "";

            for (int i = 0; i < funciones.Length; i++)
            {
                this.Text += funciones[i].Nombre + "; ";
                funciones[i].Dibujar = true;
                AgregarFuncion(funciones[i]);
            }

            toolStripTextBox1.Text = this.Text;
        }

        public Grafica2Form(Padre MDIpadre, params Funcion2D[] funciones)
        {
            InitializeComponent();
            padre = MDIpadre;
            this.Text = "";

            for (int i = 0; i < funciones.Length; i++)
            {
                this.Text += funciones[i].Nombre + "; ";
                funciones[i].Dibujar = true;
                AgregarFuncion(funciones[i]);
            }

            toolStripTextBox1.Text = this.Text;
        }

        private void GraficaMDIForm_Load(object sender, EventArgs e)
        {
            papel.MouseWheel += new MouseEventHandler(papel_MouseWheel);
            toolStripTextBox1.Text = this.Text;
        }

        void papel_MouseWheel(object sender, MouseEventArgs e)
        {
            //zoomTrackBar_ValueChanged(this, new EventArgs());
        }
        #endregion

        #region Controles
        private void arribaButton_Click(object sender, EventArgs e)
        {
            papel.MoverPapelArriba(20);
        }

        private void izquierdaButton_Click(object sender, EventArgs e)
        {
            papel.MoverPapelIzquierda(20);
        }

        private void abajoButton_Click(object sender, EventArgs e)
        {
            papel.MoverPapelAbajo(20);
        }

        private void derechaButton_Click(object sender, EventArgs e)
        {
            papel.MoverPapelDerecha(20);
        }

        private void centrarButton_Click(object sender, EventArgs e)
        {
            papel.CentrarEjes();
        }

        private void papel_MouseHover(object sender, EventArgs e)
        {
            //zoomTrackBar.Focus();
        }
        #endregion

        #region Menu
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Ventana
        private void GraficaMDIForm_Activated(object sender, EventArgs e)
        {
            toolStrip1.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
        }

        private void GraficaMDIForm_Deactivate(object sender, EventArgs e)
        {
            toolStrip1.BackColor = System.Drawing.Color.FromArgb(216, 228, 248);
        }
        #endregion

        #region Exportar
        private void GuardarComoImagen()
        {
            exportarImagenSaveFileDialog.FileName = this.Text + ".png";

            if (exportarImagenSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = exportarImagenSaveFileDialog.FileName.Substring(exportarImagenSaveFileDialog.FileName.LastIndexOf('.'));

                if (ext == ".png")
                {
                    papel.ExportarAImagen(exportarImagenSaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png, true, checkBox2.Checked, checkBox1.Checked, checkBox3.Checked ,false);
                }

                if (ext == ".bmp")
                {
                    papel.ExportarAImagen(exportarImagenSaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp, false, checkBox2.Checked, checkBox1.Checked,checkBox3.Checked, false);
                }

                if (ext == ".gif")
                {
                    papel.ExportarAImagen(exportarImagenSaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Gif, false, checkBox2.Checked, checkBox1.Checked,checkBox3.Checked, false);
                }

                if (ext == ".jpg")
                {
                    papel.ExportarAImagen(exportarImagenSaveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg, false, checkBox2.Checked, checkBox1.Checked,checkBox3.Checked, false);
                }
            }
        }

        public void GuardarFuncionesG2D(string path)
        {
            System.IO.StreamWriter sw = null;

            if (papel.Funciones != null)
            {
                if (papel.Funciones.Count > 0)
                {
                    try
                    {
                        sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.Unicode);

                        sw.WriteLine("g2d");
                        sw.WriteLine(papel.Funciones.Count);

                        foreach (Funcion2D fun in papel.Funciones)
                        {
                            sw.WriteLine(fun.Nombre.ToString());
                            sw.WriteLine(fun.ExpresionX.ToString());
                            sw.WriteLine(fun.ExpresionY.ToString());
                            sw.WriteLine(fun.Intervalo.Inicio.ToString());
                            sw.WriteLine(fun.Intervalo.Fin.ToString());
                            sw.WriteLine(fun.ColorLinea.ToArgb());
                            sw.WriteLine(fun.Grosor.ToString());
                            sw.WriteLine(fun.Profundidad.ToString());
                            sw.WriteLine(fun.Dibujar.ToString());
                            sw.WriteLine(fun.MetodoCalculo.Method.Name.ToString());
                            sw.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sw != null)
                            sw.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No hay funciones que guardar :)", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay funciones que guardar :)", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarFuncionesG2D(string path)
        {
            System.IO.StreamReader sr = null;

            try
            {
                sr = new System.IO.StreamReader(path, System.Text.Encoding.Unicode);

                string g2d = sr.ReadLine();
                if (g2d != "g2d")
                {
                    throw new MissingFieldException("El fichero seleccionado no es una archivo de Gráficas 2D");
                }
                int count = int.Parse(sr.ReadLine());

                string nombre;
                string exprX;
                string exprY;
                float interX;
                float interY;
                Color color;
                float grosor;
                uint profundidad;
                bool dibujar;
                string metodo;

                for (int i = 0; i < count; i++)
                {
                    nombre = sr.ReadLine();
                    exprX = sr.ReadLine();
                    exprY = sr.ReadLine();
                    interX = float.Parse(sr.ReadLine());
                    interY = float.Parse(sr.ReadLine());
                    color = Color.FromArgb(int.Parse(sr.ReadLine()));
                    grosor = float.Parse(sr.ReadLine());
                    profundidad = uint.Parse(sr.ReadLine());
                    dibujar = bool.Parse(sr.ReadLine());
                    metodo = sr.ReadLine();
                    sr.ReadLine();

                    Funcion2D fun;
                    if (metodo == "DerivadaX")
                    {
                        fun = new Funcion2D(exprX, exprY, new Intervalo(interX, interY), profundidad, color, grosor, nombre, dibujar, true, padre.ObtenerCalculadoraDelUsuario(), new MetodoCalculoDelegate(Graficas2D.Control.Funcion2D.ObtenerPuntos.DerivadaX));
                    }
                    else 
                    {
                        fun = new Funcion2D(exprX, exprY, new Intervalo(interX, interY), profundidad, color, grosor, nombre, dibujar, true, padre.ObtenerCalculadoraDelUsuario(), new MetodoCalculoDelegate(Graficas2D.Control.Funcion2D.ObtenerPuntos.Normal));
                    }
                    AgregarFuncion(fun);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        private void GuardarComoTexto()
        {
            exportarTextoSaveFileDialog.FileName = this.Text + ".txt";
            if (papel.Funciones != null && papel.Funciones.Count > 0)
            {
                if (exportarTextoSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.StreamWriter sw = null;

                    try
                    {
                        sw = new System.IO.StreamWriter(exportarTextoSaveFileDialog.FileName, false);
                        foreach (Funcion2D fun in papel.Funciones)
                        {
                            sw.WriteLine(fun.ExpresionX + ";" + fun.ExpresionY);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sw != null)
                            sw.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("¡No hay funciones para guardar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        public void AgregarFuncion(Funcion2D funcion)
        {
            if (papel.Funciones == null)
            {
                papel.Funciones = new List<SetOfPoints>();
            }

            papel.Funciones.Add(funcion);
            if (funcion.Dibujar)
            {
                funcionesCheckedListBox.Items.Add(funcion, true);
            }
            else
            {
                funcionesCheckedListBox.Items.Add(funcion, false);
            }
            if (funcion.Dibujar) papel.Invalidate();
        }

        public void MostrarAgregarFuncionForm(string funcionX, string funcionY, Color color, Intervalo interv)
        {
            Agregar2Form agregar = new Agregar2Form(this);

            agregar.colorPanel.BackColor = color;
            agregar.funcionXTextBox.Text = funcionX;
            agregar.funcionYTextBox.Text = funcionY;
            agregar.intervaloIniTextBox.Text = interv.Inicio.ToString();
            agregar.intervaloFinTextBox.Text = interv.Fin.ToString();

            DialogResult res = agregar.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                ICalculadora calc = padre.ObtenerCalculadoraDelUsuario();

                AgregarFuncion(agregar.FuncionCreada);
            }
        }

        private Funcion2D ModificarFuncion(Funcion2D funcion)
        {
            Agregar2Form agregar = new Agregar2Form(this);
            Funcion2D funAnterior = funcion;

            agregar.colorPanel.BackColor = funcion.ColorLinea;
            agregar.grosorNumericUpDown.Value = (decimal)funcion.Grosor;
            agregar.funcionXTextBox.Text = funcion.ExpresionX;
            agregar.funcionYTextBox.Text = funcion.ExpresionY;
            agregar.intervaloIniTextBox.Text = funcion.Intervalo.Inicio.ToString(System.Globalization.CultureInfo.InvariantCulture);
            agregar.intervaloFinTextBox.Text = funcion.Intervalo.Fin.ToString(System.Globalization.CultureInfo.InvariantCulture);

            if (agregar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ICalculadora calc = padre.ObtenerCalculadoraDelUsuario();

                Funcion2D newFun = agregar.FuncionCreada;
                newFun.Dibujar = funAnterior.Dibujar;
                return newFun;
            }
            else
            {
                return funcion;
            }
        }

        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            papel.Zoom((uint)zoomTrackBar.Value);
            zoomLabel.Text = "Zoom: " + zoomTrackBar.Value + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarAgregarFuncionForm("t", "", Color.Blue, new Intervalo(-20, 20));

            //AgregarForm agregar = new AgregarForm();

            //if (agregar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    if (papel.Funciones == null)
            //    {
            //        papel.Funciones = new List<Funcion>();
            //    }

            //    funcionesCheckedListBox.Items.Add(new Funcion(Funcion.ObtenerPuntos(agregar.Funcion, agregar.Intervalo, (uint)50), agregar.Color, 3, false, "y = " + agregar.Funcion));
            //    papel.Funciones.Add(new Funcion(Funcion.ObtenerPuntos(agregar.Funcion, agregar.Intervalo, (uint)50), agregar.Color, 3, false, "y = " + agregar.Funcion));
            //}       
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                Funcion2D fun = (Funcion2D)funcionesCheckedListBox.Items[e.Index];

                fun.Dibujar = false;

                papel.Funciones[e.Index] = fun;

                papel.Invalidate();
            }
            else if (e.CurrentValue == CheckState.Unchecked)
            {
                Funcion2D fun = (Funcion2D)funcionesCheckedListBox.Items[e.Index];

                fun.Dibujar = true;

                papel.Funciones[e.Index] = fun;

                papel.Invalidate();
            }
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            int item = funcionesCheckedListBox.SelectedIndex;

            if (item != -1)
            {
                if (papel.Funciones[item] is Funcion2D)
                {
                    papel.Funciones[item] = ModificarFuncion((Funcion2D)papel.Funciones[item]);

                    funcionesCheckedListBox.Items[item] = papel.Funciones[item];
                    papel.Invalidate();
                }
            }
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            int item = funcionesCheckedListBox.SelectedIndex;

            if (item != -1)
            {
                //if (funcionesCheckedListBox.CheckedIndices.Contains(item))
                //{
                papel.Funciones.RemoveAt(item);
                //}

                funcionesCheckedListBox.Items.RemoveAt(item);
                papel.Invalidate();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                papel.MostrarCuadricula = true;
                papel.Invalidate();
            }
            else
            {
                papel.MostrarCuadricula = false;
                papel.Invalidate();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                papel.MostrarEjeX = true;
                papel.MostrarEjeY = true;
                papel.Invalidate();
            }
            else
            {
                papel.MostrarEjeX = false;
                papel.MostrarEjeY = false;
                papel.Invalidate();
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Graficas 2D v2.\nCopyright (c) 2010 Rafael Bailón-Ruiz.\nTodos los derechos reservados.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = toolStripTextBox1.Text;
            if (padre != null)
            {
                padre.RecargarListaFormularios();
            }
        }

        private void imagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComoImagen();
        }

        private void exportarComoTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComoTexto();
        }

        private void toolStripButton1_ButtonClick(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = this.Text + ".g2d";
            save.DefaultExt = "g2d";
            save.Filter = "Archivo de Graficas 2D (*.g2d)|*.g2d|Todos los Archivos (*.*)|*.*";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GuardarFuncionesG2D(save.FileName);
            }
        }

        private void guardarEnFMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = this.Text + ".g2d";
            save.DefaultExt = "g2d";
            save.Filter = "Archivo de Graficas 2D (*.g2d)|*.g2d|Todos los Archivos (*.*)|*.*";

            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GuardarFuncionesG2D(save.FileName);
            }
        }

        private void funcionesCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (funcionesCheckedListBox.SelectedItem != null)
            {
                PonerDatosEnPanel((Funcion2D)funcionesCheckedListBox.SelectedItem);
            }
        }

        private void PonerDatosEnPanel(Funcion2D funcion)
        {
            XTextBox.Text = funcion.ExpresionX;
            YTextBox.Text = funcion.ExpresionY;
            intervaloIniTextBox.Text = funcion.Intervalo.Inicio.ToString();
            intervaloFinTextBox.Text = funcion.Intervalo.Fin.ToString();
            colorPanel.BackColor = funcion.ColorLinea;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                papel.MostrarEscala = true;
                papel.Invalidate();
            }
            else
            {
                papel.MostrarEscala = false;
                papel.Invalidate();
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".g2d";
            open.Filter = "Archivo de Graficas 2D (*.g2d)|*.g2d|Todos los Archivos (*.*)|*.*";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarFuncionesG2D(open.FileName);
            }
        }
    }
}

