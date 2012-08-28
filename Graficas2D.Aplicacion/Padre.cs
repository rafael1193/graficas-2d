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
using System.Windows.Forms;

namespace Graficas2D.Aplicacion
{
    delegate void NuevaVentana(Form formulario);

    public partial class Padre : Form
    {
        public Boolean VerBarraIconos
        {
            get { return barraIconosToolStrip.Visible; }
            set { barraIconosToolStrip.Visible = value; }
        }

        public Graficas2D.Control.CalculadoraInfija calculadoraBase;

        public Graficas2D.Control.CalculadoraInfija CalculadoraBase
        {
            get { return calculadoraBase; }
            set { calculadoraBase = value; }
        }

        private int graficachildFormNumber = 1;

        public Graficas2D.Control.ICalculadora ObtenerCalculadoraDelUsuario()
        {
            //Graficas2D.Control.ICalculadora calc;
            //if (modoAlpha)
            //{
            //    calc = new Graficas2D.Control.CalculadoraInfija();
            //}
            //else
            //{
            //    calc = new Graficas2D.Control.CalculadoraRPN();
            //}

            //calc.DefinirVariable("x", 0);
            //calc.DefinirVariable("t", 0);

            return calculadoraBase.Clone();
        }

        public Padre()
        {
            InitializeComponent();

            calculadoraBase = new Control.CalculadoraInfija();

            calculadoraBase.DefinirVariable("x", 0);
            calculadoraBase.DefinirVariable("t", 0);
        }

        public void NuevaVentana(Form formulario)
        {
            formulario.MdiParent = this;
            formulario.FormClosed += new FormClosedEventHandler(formulario_FormClosed);
            formulario.Show();
            RecargarListaFormulariosAñadiendo();
        }

        public void RecargarListaFormularios()
        {
            RecargarListaFormulariosAñadiendo();
        }

        private void RecargarListaFormulariosAñadiendo()
        {
            barraIconosToolStrip.Items.Clear();

            foreach (Form ventana in this.MdiChildren)
            {
                barraIconosToolStrip.Items.Add(ventana.Text, ventana.Icon.ToBitmap(), new EventHandler(toolStrip_OnClick));
            }
        }

        private void RecargarListaFormulariosEliminando(Form eliminandose)
        {
            barraIconosToolStrip.Items.Clear();

            for (int i = 0; i < MdiChildren.Length; i++)
            {
                if (!MdiChildren[i].Equals(eliminandose))
                {
                    barraIconosToolStrip.Items.Add(MdiChildren[i].Text, MdiChildren[i].Icon.ToBitmap(), new EventHandler(toolStrip_OnClick));
                }
            }
        }

        private void AbrirDesdeTxt(string path)
        {
            //System.IO.StreamReader sr = null;

            //List<Control.Funciones.FuncionParametrica> funciones = new List<Control.Funciones.FuncionParametrica>();

            //StringBuilder buffer = new StringBuilder();
            //string[] ambas;
            //char[] separador = new char[1];
            //separador[0] = ';';

            //try
            //{
            //    sr = new System.IO.StreamReader(path);

            //    while (sr.Peek() != -1)
            //    {
            //        buffer.Append(sr.ReadLine());
            //        ambas = buffer.ToString().Split(separador, 2);

            //        if (Graficas2D.Control.Calculos.CalculadorRPN.ComprobarValidez(ambas[0]) == null && Graficas2D.Control.Calculos.CalculadorRPN.ComprobarValidez(ambas[1]) == null)
            //        {
            //            funciones.Add(new Control.Funciones.FuncionParametrica(ambas[0], ambas[1], new Control.Funciones.Intervalo(-20, 20), 50, Color.Blue, 3f, true, "x = " + ambas[0] + "; y = " + ambas[1], true));
            //        }
            //        else
            //        {
            //            MessageBox.Show("Este archivo no es correcto. No se puede abrir", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        ambas = null;
            //        buffer = new StringBuilder();
            //    }

            //    GraficaForm ven = new GraficaForm(this, funciones.ToArray());
            //    ven.Text = path.Substring(path.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1, path.Length - 5 - path.LastIndexOf(System.IO.Path.DirectorySeparatorChar));

            //    NuevaVentana(ven);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    if (sr != null)
            //        sr.Close();
            //}
        }

        //private void ShowNewForm(object sender, EventArgs e)
        //{
        //    Form childForm = new Form();
        //    childForm.MdiParent = this;
        //    childForm.Text = "Ventana " + graficachildFormNumber++;
        //    childForm.Show();
        //}

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void nuevaHojaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafica2Form form = new Grafica2Form(this);

            form.Text = "Gráfica " + graficachildFormNumber++;
            NuevaVentana(form);
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPNForm form = new RPNForm(this);

            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            form.MaximizeBox = true;
            form.MinimizeBox = true;

            NuevaVentana(form);
        }

        private void ecuaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResolverNewtonForm dev = new ResolverNewtonForm(this);
            NuevaVentana(dev);

        }

        private void sistemaDeEcuacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GaussForm form = new GaussForm(this);
            NuevaVentana(form);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (this.MdiChildren.Length != 0)
            //{
            //    if (MessageBox.Show("¿Seguro que quieres salir?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        Application.Exit();
            //    }
            //}
            //else
            //{
            Application.Exit();
            //}
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //#if muParser
            //            MessageBox.Show("Graficas 2D. Versión " + Application.ProductVersion.ToString() + " (muP)" + "\nCopyright (c) 2010-2011 Rafael Bailón-Ruiz.\nTodos los derechos reservados.\nEl intérprete muParser es Copyright (c) 2011 Ingo Berg, disponible bajo licencia MIT", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //#else
            //            MessageBox.Show("Graficas 2D. Versión " + Application.ProductVersion.ToString() + " (RPN)" + "\nCopyright (c) 2010-2011 Rafael Bailón-Ruiz.\nTodos los derechos reservados.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //#endif

            AcercaForm ac = new AcercaForm();
            ac.ShowDialog(this);

        }

        private void derivadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DerivadasForm dev = new DerivadasForm(this);
            NuevaVentana(dev);
        }

        private void limitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimitesForm dev = new LimitesForm(this);
            NuevaVentana(dev);
        }

        private void notasDeLaVersiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotasForm dev = new NotasForm(this);
            NuevaVentana(dev);
        }

        void formulario_FormClosed(object sender, FormClosedEventArgs e)
        {
            RecargarListaFormulariosEliminando((Form)sender);
        }

        private void toolStrip_OnClick(object sender, EventArgs e)
        {
            ToolStripItem s = (ToolStripItem)sender;

            this.MdiChildren[barraIconosToolStrip.Items.IndexOf(s)].Focus();
            RecargarListaFormulariosAñadiendo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Funcion no implementada", "Graficas 2D", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.'));

                switch (ext)
                {
                    case ".txt":
                        AbrirDesdeTxt(openFileDialog.FileName);
                        break;

                    default:
                        MessageBox.Show("¡No se puede abrir este tipo de archivo!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }



            //OpenFileDialog open = new OpenFileDialog();

            //open.DefaultExt = "fml";
            //open.Filter = "Functions Markup Language|*.fml";
            //open.FilterIndex = 0;
            //open.Title = "Abrir funciones...";

            //if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    //try
            //    //{
            //    //    using (XmlReader reader = XmlReader.Create(open.FileName))
            //    //    {
            //    //        reader.ReadToFollowing("Paper");
            //    //        reader.MoveToFirstAttribute();
            //    //        string genre = reader.Value;
            //    //        output.AppendLine("The genre value: " + genre);

            //    //        reader.ReadToFollowing("title");
            //    //        output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString());

            //    //        GraficaMDIForm ventana = new GraficaMDIForm();
            //    //    }
            //    //}
            //    //catch (Exception ex) 
            //    //{

            //    //}             
            //}
        }

        private void MDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                DialogResult res = MessageBox.Show("Hay ventanas abiertas. ¿Seguro que deseas salir?.", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void nuevaHojaV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafica2Form graf = new Grafica2Form(this);
            graf.Text = "Gráfica " + graficachildFormNumber;
            graficachildFormNumber++;
            NuevaVentana(graf);
        }

        private void preferenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NuevaVentana(new OpcionesForm(this));
        }
    }
}
