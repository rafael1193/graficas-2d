/* Copyright (C) 2010, 2011  rafael1193
 * 
 * This file is part of Graficas2D.Control
 * 
 * Graficas2D.Control is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * Graficas2D.Control is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *  
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graficas2D.Control
{
    public partial class Papel2 : UserControl
    {
        const float LimiteGDI = 500000f;//1073741951f;

        bool dibEjeX;
        bool dibEjeY;
        bool dibCuad;
        bool dibFunc;
        bool dibEsc;

        Color colorFondo;
        Color colorCuad;
        Color colorEjes;

        List<SetOfPoints> funciones = new List<SetOfPoints>();

        uint pixelesPorUnidad;
        bool zoomRaton = true;
        uint minZoom = 5;
        uint maxZoom = 150;

        Size tamaño;

        bool movRaton = true;
        bool ratonPulsado = false;
        Point puntoPulsadoInicio;
        float velDespRaton = 1f;

        Point centro;

        #region Inicio
        public Papel2()
        {
            InitializeComponent();

            dibEjeX = true;
            dibEjeY = true;
            dibCuad = true;
            dibEsc = true;


            colorFondo = Color.White;
            this.BackColor = colorFondo;
            colorEjes = Color.Black;
            colorCuad = Color.LightBlue;

            pixelesPorUnidad = 50;

            centro = new Point((int)(this.Width / 2), (int)(this.Height / 2));

            tamaño = this.Size;

            dibFunc = true;

            MouseWheel += new MouseEventHandler(Papel_MouseWheel);

            List<PointF> pun = new List<PointF>();

            pun.Add(new PointF(1, 2));

            pun.Add(new PointF(5.6f, 2.3f));
        }

        private void Papel_Load(object sender, EventArgs e)
        {
            centro = new Point((int)(this.Width / 2), (int)(this.Height / 2));
        }

        #endregion

        #region Función
        public List<SetOfPoints> Funciones
        {
            get { return funciones; }
            set { funciones = value; }
        }
        #endregion

        #region Movimiento
        public void MoverPapelDerecha(int pixeles)
        {
            //if (despX == int.MaxValue) despX = 0;
            //despX += -pixeles;
            centro.X += -pixeles;
            OnResize(new EventArgs());
        }

        public void MoverPapelIzquierda(int pixeles)
        {
            //if (despX == int.MaxValue) despX = 0;
            //despX += pixeles;
            centro.X += pixeles;
            OnResize(new EventArgs());
        }

        public void MoverPapelArriba(int pixeles)
        {
            //if (despY == int.MaxValue) despY = 0;
            //despY += pixeles;
            centro.Y += pixeles;
            OnResize(new EventArgs());
        }

        public void MoverPapelAbajo(int pixeles)
        {
            //if (despY == int.MaxValue) despY = 0;
            //despY += -pixeles;
            centro.Y += -pixeles;
            OnResize(new EventArgs());
        }

        public void CentrarEjes()
        {
            centro.X = Size.Width / 2;
            centro.Y = Size.Height / 2;

            //despX = 0;
            //despY = 0;

            OnResize(new EventArgs());
        }

        public void Zoom(uint _pixelesPorUnidad)
        {
            pixelesPorUnidad = _pixelesPorUnidad;

            OnResize(new EventArgs());
        }

        void Papel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (zoomRaton)
            {
                int val = (int)pixelesPorUnidad + e.Delta / 60;
                if (val > 0 && val >= minZoom && val <= maxZoom)
                {
                    Zoom((uint)val);
                }
            }
        }

        private void Papel_Resize(object sender, EventArgs e)
        {
            //despX = despX + ((this.Size.Width - tamaño.Width) / 2);
            //despY = despY + ((this.Size.Height - tamaño.Height) / 2);

            //centro.X = Size.Width / 2 + despX;
            //centro.Y = Size.Height / 2 + despY;

            centro.X = centro.X + ((this.Size.Width - tamaño.Width) / 2);
            centro.Y = centro.Y + ((this.Size.Height - tamaño.Height) / 2);

            tamaño = this.Size;
            Invalidate();



            //if (despX != int.MaxValue && despY != int.MaxValue)
            //{
            //    centro.X = Size.Width / 2 + despX;
            //    centro.Y = Size.Height / 2 + despY;
            //    Invalidate();
            //}
            //else
            //{
            //    despX = 0;
            //    despY = 0;

            //    centro.X = Size.Width / 2;
            //    centro.Y = Size.Height / 2;
            //    Invalidate();
            //}

        }

        private void Papel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ratonPulsado)
            {
                ratonPulsado = true;
                puntoPulsadoInicio = e.Location;
            }
        }

        private void Papel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && movRaton)
            {
                Point ratonPosAhora = e.Location;

                int deltaX = ratonPosAhora.X - puntoPulsadoInicio.X;
                int deltaY = ratonPosAhora.Y - puntoPulsadoInicio.Y;

                centro.X = centro.X + Convert.ToInt32(deltaX * velDespRaton);
                centro.Y = centro.Y + Convert.ToInt32(deltaY * velDespRaton);

                puntoPulsadoInicio = ratonPosAhora;
                Invalidate();
            }
        }

        private void Papel_MouseUp(object sender, MouseEventArgs e)
        {
            ratonPulsado = false;
        }

        public Point Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        public bool MovimientoConRaton
        {
            get { return movRaton; }
            set { movRaton = value; }
        }

        public bool ZoomConRaton
        {
            get { return zoomRaton; }
            set { zoomRaton = value; }
        }

        public uint ZoomMinimo
        {
            get { return minZoom; }
            set { minZoom = value; }
        }

        public uint ZoomMaximo
        {
            get { return maxZoom; }
            set { maxZoom = value; }
        }

        /// <summary>
        /// Sets or gets the mouse moving speed. A value between 0 and 1 is recommended. Values under 0 are truncated to 0.
        /// </summary>
        public float VelocidadDesplazamientoRaton
        {
            get { return velDespRaton; }
            set
            {
                if (value >= 0) { velDespRaton = value; }
                else { velDespRaton = 0; }
            }
        }

        #endregion

        #region Dibujado
        public void Papel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.Clear(colorFondo);

            if (dibCuad) DibujarCuadricula(e.Graphics);
            if (dibEjeX) DibujarEjeX(e.Graphics);
            if (dibEjeY) DibujarEjeY(e.Graphics);
            if (dibEsc) DibujarEscala(e.Graphics);

            if (dibFunc) DibujarFuncion(funciones, e.Graphics);
        }

        private void DibujarFuncion(List<SetOfPoints> funciones, Graphics gr)
        {
            //////////////////////////////////////////
            //Version del codigo de dibujado estable//
            //////////////////////////////////////////

            //try
            //{
            //    if (funciones != null)
            //    {
            //        foreach (Funcion2D fun in funciones)
            //        {
            //            if (fun.Puntos != null)
            //            {
            //                if (fun.Dibujar == true)
            //                {
            //                    if (fun.Puntos.Length > 0)
            //                    {
            //                        Pen pen = new Pen(fun.ColorLinea, fun.Grosor);

            //                        for (int i = 1; i < fun.Puntos.Length - 1; i++)
            //                        {
            //                            if (!float.IsNaN(fun.Puntos[i].Y) && !float.IsNaN(fun.Puntos[i - 1].Y) && !float.IsNaN(fun.Puntos[i].X) && !float.IsNaN(fun.Puntos[i - 1].X))
            //                            {
            //                                if (fun.Puntos[i - 1].Y * (-pixelesPorUnidad) + centro.Y < Size.Height && fun.Puntos[i].Y * (-pixelesPorUnidad) + centro.Y > 0)
            //                                {
            //                                    gr.DrawLine(pen, fun.Puntos[i - 1].X * (pixelesPorUnidad) + centro.X, fun.Puntos[i - 1].Y * (-pixelesPorUnidad) + centro.Y, fun.Puntos[i].X * (pixelesPorUnidad) + centro.X, fun.Puntos[i].Y * (-pixelesPorUnidad) + centro.Y);
            //                                }
            //                                else
            //                                {
            //                                    i++;
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (OverflowException ex)
            //{
            //    //MessageBox.Show("Enhorabuena, acabas de cargarte el programa ¬¬.\nSi estás interesado en lo que acabas de fastidiar, aqui tienes lo que has hecho:\n" + ex.ToString() + " - " + ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            ////////////////////////////////////////////
            //Version del codigo de dibujado de prueba//
            ////////////////////////////////////////////
            unchecked
            {
                int i = 1;
                try
                {
                    if (funciones != null)
                    {
                        foreach (Funcion2D fun in funciones)
                        {
                            if (fun.Puntos != null)
                            {
                                if (fun.Dibujar == true)
                                {
                                    if (fun.Puntos.Length > 0)
                                    {
                                        Pen pen = new Pen(fun.ColorLinea, fun.Grosor);

                                        for (i = 1; i < fun.Puntos.Length - 1; i++)
                                        {
                                            if (ComprobarValidez(fun.Puntos[i].Y) && ComprobarValidez(fun.Puntos[i - 1].Y) && ComprobarValidez(fun.Puntos[i].X) && ComprobarValidez(fun.Puntos[i - 1].X) && ComprobarValidez(fun.Puntos[i].Y * (pixelesPorUnidad)) && ComprobarValidez(fun.Puntos[i - 1].Y * (pixelesPorUnidad)))
                                            {
                                                if ((fun.Puntos[i - 1].X * (pixelesPorUnidad) + centro.X > (-pixelesPorUnidad) && fun.Puntos[i].X * (pixelesPorUnidad) + centro.X < Size.Width))
                                                {
                                                    gr.DrawLine(pen, fun.Puntos[i - 1].X * (pixelesPorUnidad) + centro.X, fun.Puntos[i - 1].Y * (-pixelesPorUnidad) + centro.Y, fun.Puntos[i].X * (pixelesPorUnidad) + centro.X, fun.Puntos[i].Y * (-pixelesPorUnidad) + centro.Y);
                                                }
                                                else
                                                {
                                                    i++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (OverflowException ex)
                {
                    //MessageBox.Show("Enhorabuena, acabas de cargarte el programa ¬¬.\nSi estás interesado en lo que acabas de fastidiar, aqui tienes lo que has hecho:\n" + ex.ToString() + " - " + ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ////Dibujar Puntos sueltos
            //if (conjPuntos != null)
            //{
            //    foreach (ConjuntoPuntos pareja in conjPuntos)
            //    {
            //        try
            //        {
            //            if (pareja.Puntos != null)
            //            {
            //                if (pareja.Dibujar == true)
            //                {
            //                    if (pareja.Puntos.Count > 0)
            //                    {
            //                        SolidBrush sol = new SolidBrush(pareja.Color);

            //                        for (int i = 1; i < pareja.Puntos.Count; i++)
            //                        {
            //                            if (!float.IsNaN(pareja.Puntos[i].Y) && !float.IsNaN(pareja.Puntos[i].X))
            //                            {
            //                                if (pareja.Puntos[i].Y * (pixelesPorUnidad) + centro.Y < LimiteGDI)
            //                                {
            //                                    //if (fun.Puntos[i - 1].Y * (-pixelesPorUnidad) + centro.Y < Size.Height && fun.Puntos[i].Y * (-pixelesPorUnidad) + centro.Y > 0 || fun.Puntos[i - 1].Y * (-pixelesPorUnidad) + centro.Y < 0 && fun.Puntos[i].Y * (-pixelesPorUnidad) + centro.Y > Size.Height)
            //                                    //{
            //                                    gr.FillEllipse(sol, pareja.Puntos[i].X * (pixelesPorUnidad) + centro.X, pareja.Puntos[i].Y * (-pixelesPorUnidad) + centro.Y, pareja.Grosor, pareja.Grosor);

            //                                    //}
            //                                    //else
            //                                    //{
            //                                    //    i++;
            //                                    //}

            //                                }

            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        { }
            //    }
            //}




            ////////////////////////////////////////////
        }

        private bool ComprobarValidez(float numero)
        {
            if (float.IsNaN(numero))
            {
                return false;
            }
            else if (float.IsInfinity(numero))
            {
                return false;
            }
            else if (Math.Abs(numero) > LimiteGDI)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
    
        private void DibujarEjeX(Graphics gr)
        {
            gr.DrawLine(new Pen(colorEjes, 2f), centro.X, 0, centro.X, Size.Height);
        }

        private void DibujarEjeY(Graphics gr)
        {
            gr.DrawLine(new Pen(colorEjes, 2f), 0, centro.Y, Size.Width, centro.Y);
        }

        private void DibujarCuadricula(Graphics gr)
        {
            //Lineas verticales izquierda
            for (int i = centro.X; i > 0; i -= (int)pixelesPorUnidad)
            {
                gr.DrawLine(new Pen(colorCuad), i, 0, i, Size.Height);
            }

            //Lineas verticales derecha
            for (int i = centro.X; i < Size.Width; i += (int)pixelesPorUnidad)
            {
                gr.DrawLine(new Pen(colorCuad), i, 0, i, Size.Height);
            }

            //Lineas horizontales arrriba
            for (int i = centro.Y; i > 0; i -= (int)pixelesPorUnidad)
            {
                gr.DrawLine(new Pen(colorCuad), 0, i, Size.Width, i);
            }

            //Lineas verticales abajo
            for (int i = centro.Y; i < Size.Height; i += (int)pixelesPorUnidad)
            {
                gr.DrawLine(new Pen(colorCuad), 0, i, Size.Width, i);
            }
        }

        private void DibujarEscala(Graphics gr)
        {
            int numero = 0;
            uint espacio = pixelesPorUnidad;
            float tamañoLetra = 10f;
            Pen pen = new Pen(Color.Black, 2);

            //izquierda
            for (int i = centro.X; i > 0 - tamañoLetra * 4; i -= (int)pixelesPorUnidad)
            {
                if (espacio > tamañoLetra * 2.5)
                {
                    gr.DrawString((-numero).ToString(), new System.Drawing.Font("Verdana", tamañoLetra), Brushes.Black, i, centro.Y);
                    if (i != 0) gr.DrawLine(pen, i, centro.Y - 3, i, centro.Y + 3);
                    numero++;
                }
                else
                {
                    if (numero % 5 == 0)
                    {
                        gr.DrawString((-numero).ToString(), new System.Drawing.Font("Verdana", tamañoLetra), Brushes.Black, i, centro.Y);
                        gr.DrawLine(pen, i, centro.Y - 3, i, centro.Y + 3);
                    }
                    numero = numero + 1;
                }
            }
            numero = 1;
            //derecha
            for (int i = centro.X + (int)pixelesPorUnidad; i < Size.Width; i += (int)pixelesPorUnidad)
            {
                if (espacio > tamañoLetra * 2.5)
                {
                    gr.DrawString((numero).ToString(), new System.Drawing.Font("Verdana", tamañoLetra), Brushes.Black, i, centro.Y);
                    gr.DrawLine(pen, i, centro.Y - 3, i, centro.Y + 3);
                    numero++;
                }
                else
                {
                    if (numero % 5 == 0)
                    {
                        gr.DrawString((numero).ToString(), new System.Drawing.Font("Verdana", tamañoLetra), Brushes.Black, i, centro.Y);
                        gr.DrawLine(pen, i, centro.Y - 3, i, centro.Y + 3);
                    }
                    numero = numero + 1;
                }
            }
            numero = 0;
            //arrriba
            for (int i = centro.Y; i > 0 - tamañoLetra * 4; i -= (int)pixelesPorUnidad)
            {
                if (espacio > tamañoLetra * 2.5)
                {
                    gr.DrawString((numero).ToString(), new System.Drawing.Font("Verdana", tamañoLetra), Brushes.Black, centro.X, i);
                    gr.DrawLine(pen, centro.X - 3, i, centro.X + 3, i);
                    numero++;
                }
                else
                {
                    if (numero % 5 == 0)
                    {
                        gr.DrawString((numero).ToString(), new System.Drawing.Font("Verdana", tamañoLetra), Brushes.Black, centro.X, i);
                        gr.DrawLine(pen, centro.X - 3, i, centro.X + 3, i);
                    }
                    numero = numero + 1;
                }
            }
            numero = 1;
            //abajo
            for (int i = centro.Y + (int)pixelesPorUnidad; i < Size.Height + tamañoLetra * 3; i += (int)pixelesPorUnidad)
            {
                if (espacio > tamañoLetra * 2.5)
                {
                    gr.DrawString((-numero).ToString(), new System.Drawing.Font("Verdana", tamañoLetra), Brushes.Black, centro.X, i);
                    gr.DrawLine(pen, centro.X - 3, i, centro.X + 3, i);
                    numero++;
                }
                else
                {
                    if (numero % 5 == 0)
                    {
                        gr.DrawString((-numero).ToString(), new System.Drawing.Font("Verdana", tamañoLetra), Brushes.Black, centro.X, i);
                        gr.DrawLine(pen, centro.X - 3, i, centro.X + 3, i);
                    }
                    numero = numero + 1;
                }
            }
        }

        public void ExportarAImagen(string ruta, System.Drawing.Imaging.ImageFormat formato, bool fondoTransparente, bool dibujarEjes, bool dibujarCuadricula, bool dibujarEscala, bool dibujarBorde)
        {
            Bitmap bit = new Bitmap(Size.Width, Size.Height);
            Graphics gr = Graphics.FromImage(bit);

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (fondoTransparente)
            {
                gr.Clear(Color.Transparent);
            }
            else
            {
                gr.Clear(colorFondo);
            }

            if (dibujarCuadricula)
            {
                DibujarCuadricula(gr);
            }

            if (dibujarEjes)
            {
                DibujarEjeX(gr);
                DibujarEjeY(gr);
            }

            if (dibujarEscala)
                DibujarEscala(gr);       

            DibujarFuncion(funciones, gr);

            if (dibujarBorde)
            {
                gr.DrawRectangle(new Pen(Color.Black, 1f), new Rectangle(0, 0, bit.Width - 1, bit.Height - 1));
            }

            bit.Save(ruta, formato);
        }

        public Color ColorFondo
        {
            get { return colorFondo; }
            set { colorFondo = value; }
        }

        public Color ColorCuadricula
        {
            get { return colorCuad; }
            set { colorCuad = value; }
        }

        public Color ColorEjes
        {
            get { return colorEjes; }
            set { colorEjes = value; }
        }

        public bool MostrarCuadricula
        {
            get { return dibCuad; }
            set { dibCuad = value; }
        }

        public bool MostrarEscala
        {
            get { return dibEsc; }
            set { dibEsc = value; }
        }

        public bool MostrarEjeX
        {
            get { return dibEjeX; }
            set { dibEjeX = value; }
        }

        public bool MostrarEjeY
        {
            get { return dibEjeY; }
            set { dibEjeY = value; }
        }

        #endregion
    }
}
